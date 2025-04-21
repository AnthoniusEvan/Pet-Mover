using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petMover_Final_Project
{
    public partial class FrmTransactionReport : Form
    {
        List<Transaction> listOfTransactions = new List<Transaction>();
        string period = "";
        public FrmTransactionReport()
        {
            InitializeComponent();
        }

        private void dtpLogTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
            if (rdbDay.Checked) rdbDay_CheckedChanged(sender, e);
            if (rdbMonth.Checked) rdbMonth_CheckedChanged(sender, e);
            if (rdbYear.Checked) rdbYear_CheckedChanged(sender, e);
        }
        private void EmptyReport()
        {
            txt1.Text = "-";
            txt2.Text = "-";
            txt3.Text = "-";
            txt4.Text = "-";
            txt5.Text = "-";
            txt6.Text = "-";
            txt7.Text = "-";
            txt8.Text = "-";
            txt9.Text = "-";
        }
        private void FrmTransactionReport_Load(object sender, EventArgs e)
        {
            cbBranch.DataSource = Branch.Get("", "");
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";

            cbBranch.SelectedIndex = 0;

            rdbDay.Checked = true;
            Height = 620;
        }
        private void RefreshData()
        {
            string criteria = cbBranch.SelectedValue + ";" + dtpDate.Value.ToString("yyyy-MM-dd");
            if (chbAllBranch.Checked && chbAllPeriod.Checked)
            {
                listOfTransactions = Transaction.Get("", "");
            }
            else if (chbAllPeriod.Checked)
            {
                listOfTransactions = Transaction.Get("branch", cbBranch.SelectedValue.ToString());
            }
            else if (chbAllBranch.Checked)
            {
                if (rdbDay.Checked)
                    listOfTransactions = Transaction.Get("date", dtpDate.Value.ToString("yyyy-MM-dd"));
                else if (rdbMonth.Checked)
                    listOfTransactions = Transaction.Get("date", dtpDate.Value.ToString("yyyy-MM") + "-__");
                else if (rdbYear.Checked)
                    listOfTransactions = Transaction.Get("date", dtpDate.Value.ToString("yyyy")+"-__-__");
            }
            else if (rdbDay.Checked)
            {
                listOfTransactions = Transaction.Get("date;b;" + cbBranch.SelectedValue, dtpDate.Value.ToString("yyyy-MM-dd"));
            }
            else if (rdbMonth.Checked)
            {
                listOfTransactions = Transaction.Get("datemonth;b;" + cbBranch.SelectedValue, dtpDate.Value.ToString("yyyy-MM"));
            }
            else if (rdbYear.Checked)
            {
                listOfTransactions = Transaction.Get("dateyear;b;" + cbBranch.SelectedValue, dtpDate.Value.ToString("yyyy"));
            }

            if (listOfTransactions.Count > 0)
            {
                dgvData.DataSource = listOfTransactions;
                if (!dgvData.Columns.Contains("btnPrint"))
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.HeaderText = "Print";
                    col.Text = "Print";
                    col.Name = "btnPrint";
                    col.UseColumnTextForButtonValue = true;
                    dgvData.Columns.Add(col);
                }
                lblNotFound.Visible = false;
                dgvData.DataSource = listOfTransactions;
                lblNotFound.Visible = false;
                btnPrint.Visible = true;
            }
            else
            {
                dgvData.DataSource = null;
                dgvData.Columns.Clear();
                pnlReport.Visible = false;
                btnGenerate.Text = "Generate";
                lblNotFound.Visible = true;
                btnPrint.Visible = false;
                if (chbAllPeriod.Checked && chbAllBranch.Checked)
                    lblNotFound.Text = string.Format("There are no transactions created in any branch yet!");
                else if (chbAllBranch.Checked)
                    lblNotFound.Text = string.Format("There are no transaction records found on {0}!", dtpDate.Value.ToString("D"));
                else if (chbAllPeriod.Checked)
                    lblNotFound.Text = string.Format("There are no transactions found at {0}!", cbBranch.SelectedItem);
                else
                    lblNotFound.Text = string.Format("There are no transactions found at {0} on {1}!", cbBranch.SelectedItem, dtpDate.Value.ToString("D"));
            }
        }
        private void cbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDescription(sender, e);
        }

        private void chbAllPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAllPeriod.Checked)
            {
                dtpDate.Enabled = false;
                rdbDay.Enabled = false;
                rdbMonth.Enabled = false;
                rdbYear.Enabled = false;
            }
            else
            {
                dtpDate.Enabled = true;
                rdbDay.Enabled = true;
                rdbMonth.Enabled = true;
                rdbYear.Enabled = true;
            }
            UpdateDescription(sender, e);
        }

        private void chbAllBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAllBranch.Checked)
            {
                cbBranch.Enabled = false;
            }
            else
            {
                cbBranch.Enabled = true;
            }
            UpdateDescription(sender, e);
        }
        
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns["btnPrint"] != null && e.ColumnIndex == dgvData.Columns["btnPrint"].Index && e.RowIndex >= 0)
            {
                string selectedCode = dgvData.CurrentRow.Cells["Id"].Value.ToString();
                string selectedBranch = dgvData.CurrentRow.Cells["Branch"].Value.ToString();
                string fileName = "Transaction_" + selectedBranch + "_Id#" + selectedCode + ".pdf";
                //int branchId = Branch.Get("Name", dgvData.Rows[e.RowIndex].Cells["Branch"].Value.ToString())[0].Id;
                Branch b = (Branch)dgvData.Rows[e.RowIndex].Cells["Branch"].Value;

                bool res = Transaction.Print("Id", b.Id + " " + dgvData.Rows[e.RowIndex].Cells["Id"].Value, fileName, new Font("Courier New", 12), out string path);

                if (res)
                {
                    DialogResult dr = MessageBox.Show("Transaction has been printed succesfully! Would you like to view the file?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (btnGenerate.Text == "Generate" && listOfTransactions.Count>0)
            {
                pnlReport.Size = dgvData.Size;
                btnGenerate.Text = "Back to Data";
                btnPrint.Text = "Print Report to PDF";
                btnPrint.Tag = "pdf";
                if (chbAllPeriod.Checked && chbAllBranch.Checked)
                {
                    AdjustReport("overall");
                    GenerateOverallReport();
                }
                else if (chbAllBranch.Checked)
                {
                    if (rdbDay.Checked)
                    {
                        AdjustReport("specific");
                        GenerateSpecificReport();
                    }
                    else if (rdbMonth.Checked)
                    {
                        AdjustReport("specific");
                        GenerateSpecificReport();
                    }
                    else if (rdbYear.Checked)
                    {
                        AdjustReport("specific");
                        GenerateSpecificReport();
                    }
                }
                else if (chbAllPeriod.Checked)
                {
                    AdjustReport("overall");
                    GenerateReport(false);
                }
                else if (rdbDay.Checked)
                {
                    AdjustReport("perbranch");
                    GenerateSpecificReport();
                }
                else if (rdbMonth.Checked)
                {
                    AdjustReport("perbranch");
                    GenerateSpecificReport();
                }
                else if (rdbYear.Checked)
                {
                    AdjustReport("perbranch");
                    GenerateSpecificReport();
                }

                if (listOfTransactions.Count > 0)
                    pnlReport.Visible = true;
            }
            else if (btnGenerate.Text == "Back to Data")
            {
                btnGenerate.Text = "Generate";
                btnPrint.Text = "Export to Excel";
                pnlReport.Visible = false;
                cbBranch_SelectedIndexChanged(sender, e);
            }
        }
        private void AdjustReport(string type)
        {
            if (type == "overall")
            {
                lblCol1Row1.Visible = true;
                lblCol1Row2.Visible = true;
                lblCol1Row3.Visible = true;
                lblCol1Row4.Visible = true;
                lblCol2Row1.Visible = true;
                lblCol2Row2.Visible = true;
                lblCol2Row3.Visible = true;
                lblCol2Row4.Visible = true;
                lblCol3Row1.Visible = true;
                lblCol3Row2.Visible = true;
                lblCol3Row3.Visible = true;
                lblCol3Row4.Visible = true;

                txt1.Visible = true;
                txt2.Visible = true;
                txt3.Visible = true;
                txt4.Visible = true;
                txt5.Visible = true;
                txt6.Visible = true;
                txt7.Visible = true;
                txt8.Visible = true;
                txt9.Visible = true;

                lblCol1Row1.Text = "Daily Average";
                lblCol1Row2.Text = "Monthly Average";
                lblCol1Row3.Text = "Yearly Average";
                //lblCol1Row4.Text = "";
                lblCol2Row1.Text = "Daily Average";
                lblCol2Row2.Text = "Monthly Average";
                lblCol2Row3.Text = "Yearly Average";
                //lblCol2Row4.Text = "";
                lblCol3Row1.Text = "Common Pet Type";
                lblCol3Row2.Text = "Common Service Type";
                lblCol3Row3.Text = "Most Treatment Used";
                //lblCol3Row4.Text = "";
                lblTitle2.Text = "Number of Transactions";
                lblTitle3.Text = "Additional Information";
            }
            else if (type == "specific")
            {
                lblCol1Row1.Visible = true;
                lblCol1Row2.Visible = true;
                lblCol1Row3.Visible = true;
                lblCol1Row4.Visible = true;
                lblCol2Row1.Visible = true;
                lblCol2Row2.Visible = true;
                lblCol2Row3.Visible = true;
                lblCol2Row4.Visible = true;
                lblCol3Row1.Visible = true;
                lblCol3Row2.Visible = true;
                lblCol3Row3.Visible = true;
                lblCol3Row4.Visible = false;

                txt1.Visible = true;
                txt2.Visible = true;
                txt3.Visible = true;
                txt4.Visible = true;
                txt5.Visible = true;
                txt6.Visible = true;
                txt7.Visible = true;
                txt8.Visible = true;
                txt9.Visible = false;

                lblCol1Row1.Text = "Average Among Branches";
                lblCol1Row2.Text = "Lowest";
                lblCol1Row3.Text = "Highest";
                //lblCol1Row4.Text = "";
                lblCol2Row1.Text = "Average Among Branches";
                lblCol2Row2.Text = "Lowest";
                lblCol2Row3.Text = "Highest";
                //lblCol2Row4.Text = "";
                lblCol3Row1.Text = "Sales Changes (in %)";
                lblCol3Row2.Text = "Revenue Changes (in %)";
                lblCol3Row3.Text = "Comparison done with\n previous ";
                if (rdbDay.Checked) lblCol3Row3.Text += "day";
                else if (rdbMonth.Checked) lblCol3Row3.Text += "month";
                else if (rdbYear.Checked) lblCol3Row3.Text += "year";
                //lblCol3Row4.Text = "";
                lblTitle2.Text = "Number of Transactions";
                lblTitle3.Text = "Sales Comparison";
            }
            else if (type == "perbranch")
            {
                lblCol1Row1.Visible = true;
                lblCol1Row2.Visible = true;
                lblCol1Row3.Visible = true;
                lblCol1Row4.Visible = true;
                lblCol2Row1.Visible = true;
                lblCol2Row2.Visible = true;
                lblCol2Row3.Visible = true;
                lblCol2Row4.Visible = true;
                lblCol3Row1.Visible = true;
                lblCol3Row2.Visible = true;
                lblCol3Row3.Visible = true;
                lblCol3Row4.Visible = false;

                txt1.Visible = true;
                txt2.Visible = true;
                txt3.Visible = true;
                txt4.Visible = true;
                txt5.Visible = true;
                txt6.Visible = false;
                txt7.Visible = true;
                txt8.Visible = true;
                txt9.Visible = true;

                lblCol1Row1.Text = "Total from Pets";
                lblCol1Row2.Text = "Total from Cages";
                lblCol1Row3.Text = "Total from Treatments";
                //lblCol1Row4.Text = "";
                lblCol2Row1.Text = "Sales Changes (in %)";
                lblCol2Row2.Text = "Revenue Changes (in %)";
                lblCol2Row3.Text = "Compared with\nprevious ";
                if (rdbDay.Checked) lblCol2Row3.Text += "day";
                else if (rdbMonth.Checked) lblCol2Row3.Text += "month";
                else if (rdbYear.Checked) lblCol2Row3.Text += "year";
                //lblCol2Row4.Text = "";
                lblCol3Row1.Text = "Common Pet Type";
                lblCol3Row2.Text = "Common Service Type";
                lblCol3Row3.Text = "Most Treatment Used";
                //lblCol3Row4.Text = "";
                lblTitle2.Text = "Sales Comparison";
                lblTitle3.Text = "Additional Information";
            }
        }
        string branchTransLowest = "", branchTransHighest = "", branchRevLowest = "", branchRevHighest = "";
        private void GenerateSpecificReport()
        {
            if (chbAllBranch.Checked)
            {
                lblReportTitle.Text = "Sales Performance of All Branches";
                if (rdbDay.Checked)
                    lblReportTitle.Text += " on " + period;
                else
                    lblReportTitle.Text += " in " + period;

                double totalRev = 0;
                int totalTrans = 0;
         
                if (rdbDay.Checked)
                {
                    txt1.Text = Transaction.GetAverageRevenue(true, (int)cbBranch.SelectedValue, "day", dtpDate.Value, out totalRev).ToString("C2");
                    txt2.Text = Transaction.GetLowestRevenue("day", dtpDate.Value, out branchRevLowest).ToString("C2");
                    txt3.Text = Transaction.GetHighestRevenue("day", dtpDate.Value, out branchRevHighest).ToString("C2");

                    
                    txt4.Text = Transaction.GetAverageTransaction("day", dtpDate.Value, out totalTrans).ToString();
                    txt5.Text = Transaction.GetLowestTransaction("day", dtpDate.Value, out branchTransLowest).ToString();
                    txt6.Text = Transaction.GetHighestTransaction("day", dtpDate.Value, out branchTransHighest).ToString();

                    double increaseSale = Transaction.GetIncreaseSales("day", dtpDate.Value);
                    if (increaseSale == 0)
                        txt7.Text = "-";
                    else
                        txt7.Text = increaseSale.ToString("P2");

                    double increaseRevenue = Transaction.GetIncreaseRevenue("day", dtpDate.Value);
                    if (increaseRevenue == 0)
                        txt8.Text = "-";
                    else
                        txt8.Text = increaseRevenue.ToString("P2");
                }
                else if (rdbMonth.Checked)
                {
                    txt1.Text = Transaction.GetAverageRevenue(true, (int)cbBranch.SelectedValue, "month", dtpDate.Value, out totalRev).ToString("C2");
                    txt2.Text = Transaction.GetLowestRevenue("month", dtpDate.Value, out branchRevLowest).ToString("C2");
                    txt3.Text = Transaction.GetHighestRevenue("month", dtpDate.Value, out branchRevHighest).ToString("C2");
                    

                    txt4.Text = Transaction.GetAverageTransaction("month", dtpDate.Value, out totalTrans).ToString();
                    txt5.Text = Transaction.GetLowestTransaction("month", dtpDate.Value, out branchTransLowest).ToString();
                    txt6.Text = Transaction.GetHighestTransaction("month", dtpDate.Value, out branchTransHighest).ToString();
                    if (Transaction.GetIncreaseSales("month", dtpDate.Value) == 0)
                        txt7.Text = "-";
                    else
                        txt7.Text = Transaction.GetIncreaseSales("month", dtpDate.Value).ToString("P2");

                    if (Transaction.GetIncreaseRevenue("month", dtpDate.Value) == 0)
                        txt8.Text = "-";
                    else
                        txt8.Text = Transaction.GetIncreaseRevenue("month", dtpDate.Value).ToString("P2");
                }
                else if (rdbYear.Checked)
                {
                    txt1.Text = Transaction.GetAverageRevenue(true, (int)cbBranch.SelectedValue, "year", dtpDate.Value, out totalRev).ToString("C2");
                    txt2.Text = Transaction.GetLowestRevenue("year", dtpDate.Value, out branchRevLowest).ToString("C2");
                    txt3.Text = Transaction.GetHighestRevenue("year", dtpDate.Value, out  branchRevHighest).ToString("C2");


                    txt4.Text = Transaction.GetAverageTransaction("year", dtpDate.Value, out totalTrans).ToString();
                    txt5.Text = Transaction.GetLowestTransaction("year", dtpDate.Value, out branchTransLowest).ToString();
                    txt6.Text = Transaction.GetHighestTransaction("year", dtpDate.Value, out branchTransHighest).ToString();
                    if (Transaction.GetIncreaseSales("year", dtpDate.Value) == 0)
                        txt7.Text = "-";
                    else
                        txt7.Text = Transaction.GetIncreaseSales("year", dtpDate.Value).ToString("P2");

                    if (Transaction.GetIncreaseRevenue("year", dtpDate.Value) == 0)
                        txt8.Text = "-";
                    else
                        txt8.Text = Transaction.GetIncreaseRevenue("year", dtpDate.Value).ToString("P2");
                }

                lblCol1Row4.Text = "TOTAL : " + totalRev.ToString("C2");
                lblCol2Row4.Text = "TOTAL : " + totalTrans;
            }
            else
            {
                lblReportTitle.Text = "Sales Performance of " + cbBranch.Text;
                if (rdbDay.Checked)
                    lblReportTitle.Text += " on " + period;
                else
                    lblReportTitle.Text += " in " + period;

                string type = "";
                if (rdbDay.Checked)
                {
                    type = "day";
                }
                else if (rdbMonth.Checked)
                {
                    type = "month";
                }
                else if (rdbYear.Checked)
                {
                    type = "year";
                }
                double totalRev = Transaction.GetTotalOfItems(type, dtpDate.Value, (int)cbBranch.SelectedValue, out double totalPet, out double totalCage, out double totalTreatment, out double total);
                txt1.Text = totalPet.ToString("C2");
                txt2.Text = totalCage.ToString("C2");
                txt3.Text = totalTreatment.ToString("C2");

                double s1 = Transaction.GetIncreaseSales(type, dtpDate.Value, (int)cbBranch.SelectedValue);

                double s2 = Transaction.GetIncreaseRevenue(type, dtpDate.Value, (int)cbBranch.SelectedValue);
                if (s1 == 0)
                    txt4.Text = "-";
                else
                    txt4.Text = s1.ToString("P2");

                if (s2 == 0)
                    txt5.Text = "-";
                else
                    txt5.Text = s2.ToString("P2");


                txt7.Text = Transaction.GetCommonPetTypes(type, (int)cbBranch.SelectedValue, dtpDate.Value);
                txt8.Text = Transaction.GetCommonService(type, (int)cbBranch.SelectedValue, dtpDate.Value);
                txt9.Text = Transaction.GetCommonTreatment(type, (int)cbBranch.SelectedValue, dtpDate.Value);

                lblCol1Row4.Text = "TOTAL : " + totalRev.ToString("C2");
                lblCol2Row4.Text = "TOTAL TRANSACTION: " + total;
            }
        }
        private void GenerateReport(bool allTransaction)
        {
            int branchId = (int)cbBranch.SelectedValue;

            if (!allTransaction)
            {
                lblReportTitle.Text = "Sales Performance of " + Branch.Get("Id", branchId.ToString())[0].Name;
                if (rdbDay.Checked)
                    lblReportTitle.Text += " on " + period;
                else
                    lblReportTitle.Text += " in " + period;
            }
            else
                lblReportTitle.Text = "Overall Sales Performance of All Branches";

            // Revenue Daily Average
            txt1.Text = Transaction.GetRevenueDailyAverage("t.BranchId", branchId, allTransaction).ToString("C2");

            // Revenue Monthly Average
            txt2.Text = Transaction.GetRevenueMonthlyAverage("t.BranchId", branchId, allTransaction).ToString("C2");

            // Revenue Yearly Average
            txt3.Text = Transaction.GetRevenueYearlyAverage("t.BranchId", branchId, allTransaction).ToString("C2");

            // Total Revenue
            lblCol1Row4.Text = "TOTAL : " + Transaction.CalculateTotalRevenue("t.BranchId", branchId, allTransaction).ToString("C2");

            // Transaction Daily Average
            txt4.Text = Transaction.GetDailyAverageNumber("t.BranchId", branchId, allTransaction).ToString();

            // Transaction Monthly Average
            txt5.Text = Transaction.GetMonthlyAverageNumber("t.BranchId", branchId, allTransaction).ToString();

            // Transaction Yearly Average
            txt6.Text = Transaction.GetYearlyAverageNumber("t.BranchId", branchId, allTransaction).ToString();

            // Total Transaction Number
            lblCol2Row4.Text = "TOTAL : " + Transaction.CalculateTotalNumber("t.BranchId", branchId, allTransaction).ToString();

            // Common Pet Types
            txt7.Text = Transaction.GetCommonPetTypes("t.BranchId", branchId, allTransaction);

            // Common Service Types
            txt8.Text = Transaction.GetCommonService("t.BranchId", branchId, allTransaction);

            // Common Treatment
            txt9.Text = Transaction.GetCommonTreatment("t.BranchId", branchId, allTransaction);

            if (!allTransaction)
                lblCol3Row4.Text = "RANK : #" + Transaction.GetCityRank("t.BranchId", branchId);
        }

        private void GenerateOverallReport()
        {
            GenerateReport(true);
            // change font size
            lblCol3Row4.Text = "More details on printed report";
        }

        private void rdbDay_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDescription(sender, e);
        }

        private void rdbMonth_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDescription(sender, e);
        }

        private void rdbYear_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDescription(sender, e);
        }

        private void UpdateDescription(object sender, EventArgs e)
        {
            if (btnGenerate.Text == "Back to Data")
            {
                pnlReport.Visible = false;
                btnGenerate.Text = "Generate";
                btnPrint.Text = "Export to Excel";
                btnPrint.Tag = "excel";
            }
            else
            {
                btnPrint.Text = "Export to Excel";
                btnPrint.Tag = "excel";
            }

            if (chbAllBranch.Checked)
            {
                if (chbAllPeriod.Checked)
                    lblDesc.Text = "Generating report for all branches:\nOverall time frame";
                else
                {
                    DayMonthOrYear();
                    string preposition = "";
                    if (rdbDay.Checked) preposition = "on";
                    else preposition = "in";
                    lblDesc.Text = "Generating report for all branches "+preposition+":\n";
                    lblDesc.Text += period;
                }
            }
            else
            {
                if (chbAllPeriod.Checked)
                {
                    lblDesc.Text = "Generating overall report for:\n" + cbBranch.Text;
                }
                else
                {
                    DayMonthOrYear();
                }
            }
            RefreshData();
        }

        private void DayMonthOrYear()
        {
            if (rdbDay.Checked)
            {
                period = dtpDate.Value.ToString("dd MMMM yyyy");
                lblDesc.Text = "Generating report " + cbBranch.Text + " for date:\n" + period;
            }
            else if (rdbMonth.Checked)
            {
                period = dtpDate.Value.ToString("Y");
                lblDesc.Text = "Generating report " + cbBranch.Text + " for month:\n" + period;
            }
            else
            {
                period = dtpDate.Value.ToString("yyyy");
                lblDesc.Text = "Generating report " + cbBranch.Text + " for year:\n" + period;
            }
        }

        private void FrmTransactionReport_Click(object sender, EventArgs e)
        {
            Text = this.Size.ToString();
        }

        private void lblCol1Row4_TextChanged(object sender, EventArgs e)
        {
            while (lblCol1Row4.Width < System.Windows.Forms.TextRenderer.MeasureText(lblCol1Row4.Text,
     new Font(lblCol1Row4.Font.FontFamily, lblCol1Row4.Font.Size, lblCol1Row4.Font.Style)).Width)
            {
                lblCol1Row4.Font = new Font(lblCol1Row4.Font.FontFamily, lblCol1Row4.Font.Size - 0.5f, lblCol1Row4.Font.Style);
            }
        }

        private void lblCol3Row4_TextChanged(object sender, EventArgs e)
        {
            while (lblCol3Row4.Width < System.Windows.Forms.TextRenderer.MeasureText(lblCol3Row4.Text,
     new Font(lblCol3Row4.Font.FontFamily, lblCol3Row4.Font.Size, lblCol3Row4.Font.Style)).Width)
            {
                lblCol3Row4.Font = new Font(lblCol3Row4.Font.FontFamily, lblCol3Row4.Font.Size - 0.5f, lblCol3Row4.Font.Style);
            }
        }

        private void lblCol2Row4_TextChanged(object sender, EventArgs e)
        {
            while (lblCol2Row4.Width < System.Windows.Forms.TextRenderer.MeasureText(lblCol2Row4.Text,
     new Font(lblCol2Row4.Font.FontFamily, lblCol2Row4.Font.Size, lblCol2Row4.Font.Style)).Width)
            {
                lblCol2Row4.Font = new Font(lblCol2Row4.Font.FontFamily, lblCol2Row4.Font.Size - 0.5f, lblCol2Row4.Font.Style);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ((string)btnPrint.Tag == "pdf")
            {
                string fileName = "Report-From-";
                string branch = "";
                if (chbAllBranch.Checked)
                {
                    fileName += "AllBranch-";
                    branch = "all branch";
                }
                else
                {
                    fileName += cbBranch.Text + "-";
                    branch = "branch " + cbBranch.Text;
                }

                if (chbAllPeriod.Checked)
                    fileName += "AllPeriod";
                else
                    fileName += period;

                fileName += ".pdf";
                string preposition = "";
                if (rdbDay.Checked) preposition = "on";
                else preposition = "in";

                if ((chbAllBranch.Checked && chbAllPeriod.Checked) || chbAllPeriod.Checked)
                {
                    string type = "";
                    if (chbAllBranch.Checked && chbAllPeriod.Checked)
                        type = "all/period";
                    else type = "all/period;allPeriod";
                        bool res = Transaction.PrintBranchReport(type, fileName, new Font("Courier New", 12), lblReportTitle.Text, lblTitle1.Text, lblTitle2.Text, lblTitle3.Text, txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, txt7.Text, txt8.Text, txt9.Text, lblCol1Row4.Text, lblCol2Row4.Text, lblCol3Row4.Text, out string path);

                    if (res)
                    {
                       DialogResult dr = MessageBox.Show("Sales performance overall report for " + branch + " has been printed succesfully! Would you like to view the file?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                            System.Diagnostics.Process.Start(path);
                    }
                }
                else if (chbAllBranch.Checked)
                {
                    string lowestRev = txt2.Text + " (" + branchRevLowest + ")";
                    string highestRev = txt3.Text + " (" + branchRevHighest + ")";
                    string lowestTrans = txt5.Text + " (" + branchTransLowest + ")";
                    string highestTrans = txt6.Text + " (" + branchTransHighest + ")";
                    bool res = Transaction.PrintBranchReport("allBranch", fileName, new Font("Courier New", 12), lblReportTitle.Text, lblTitle1.Text, lblTitle2.Text, lblTitle3.Text, txt1.Text,lowestRev, highestRev, txt4.Text,lowestTrans, highestTrans, txt7.Text, txt8.Text, txt9.Text, lblCol1Row4.Text, lblCol2Row4.Text, lblCol3Row4.Text,out string path);

                    if (res)
                    {
                        DialogResult dr = MessageBox.Show("Sales performance report for all branch " + preposition + " " + period + " has been printed succesfully! Would you like to view the report?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                            System.Diagnostics.Process.Start(path);
                    }
                }
                else
                {
                    bool res = Transaction.PrintBranchReport("branch", fileName, new Font("Courier New", 12), lblReportTitle.Text, lblTitle1.Text, lblTitle2.Text, lblTitle3.Text, txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, txt7.Text, txt8.Text, txt9.Text, lblCol1Row4.Text, lblCol2Row4.Text, lblCol3Row4.Text, out string path);

                    if (res)
                    {
                        DialogResult dr = MessageBox.Show("Sales performance report for " + branch + " " + preposition + " " + period + " has been printed succesfully! Would you like to view the report?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                            System.Diagnostics.Process.Start(path);
                    }
                }
            }
            else if ((string)btnPrint.Tag == "excel")
            {
               Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("Excel Application not found!");
                }

                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();

                xlWorkbook.Worksheets.Add();
                Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];

                Microsoft.Office.Interop.Excel.Range rng = xlWorksheet.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range;

                rng.EntireRow.Font.Bold = true;

                xlWorksheet.Cells[1, 1] = "Branch";
                xlWorksheet.Cells[1, 2] = "Transaction ID";
                xlWorksheet.Cells[1, 3] = "Transaction Date";
                xlWorksheet.Cells[1, 4] = "Client";
                xlWorksheet.Cells[1, 5] = "Created By";
                xlWorksheet.Cells[1, 6] = "Service Type";
                xlWorksheet.Cells[1, 7] = "Destination Address";
                xlWorksheet.Cells[1, 8] = "Destination City";
                xlWorksheet.Cells[1, 9] = "Expected Arrival";

                for (int i = 0; i < listOfTransactions.Count; i++)
                {
                    xlWorksheet.Cells[i + 2, 1] = listOfTransactions[i].Branch.Name;
                    xlWorksheet.Cells[i + 2, 2] = listOfTransactions[i].Id;
                    xlWorksheet.Cells[i + 2, 3] = listOfTransactions[i].TransactionDate;
                    xlWorksheet.Cells[i + 2, 4] = listOfTransactions[i].Client.Name;
                    xlWorksheet.Cells[i + 2, 5] = listOfTransactions[i].CreatedBy.Name;
                    xlWorksheet.Cells[i + 2, 6] = listOfTransactions[i].Service.Name;
                    xlWorksheet.Cells[i + 2, 7] = listOfTransactions[i].DestinationAddress;
                    xlWorksheet.Cells[i + 2, 8] = listOfTransactions[i].DestinationCity.Name;
                    xlWorksheet.Cells[i + 2, 9] = listOfTransactions[i].ExpectedArrival;
                }

                xlWorksheet.Columns.AutoFit();

                string fileName = "Sales-From-";
                if (chbAllBranch.Checked)
                    fileName += "AllBranch-";
                else
                    fileName += cbBranch.Text + "-";

                if (chbAllPeriod.Checked)
                    fileName += "AllPeriod";
                else
                    fileName += period;

                fileName += ".xlsx";
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);

                string filePath = xlWorkbook.Path;
                DialogResult dr = MessageBox.Show("Data succesfully exported to excel! Would you like to view the excel file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                if (dr == DialogResult.Yes)
                    System.Diagnostics.Process.Start    (filePath+"\\"+fileName);
            }
        }

        private void FrmTransactionReport_Resize(object sender, EventArgs e)
        {
            pnlReport.Size = dgvData.Size;
        }
    }
}
