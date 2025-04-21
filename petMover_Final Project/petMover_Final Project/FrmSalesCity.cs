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
    public partial class FrmSalesCity : Form
    {
        List<Transaction> listOfTransactions = new List<Transaction>();
        public FrmSalesCity()
        {
            InitializeComponent();
        }

        private void FrmSalesCity_Load(object sender, EventArgs e)
        {
            cbCity.DataSource = City.Get("", "");
            cbCity.DisplayMember = "Name";
            cbCity.ValueMember = "Id";
            cbCity_SelectedIndexChanged(sender, e);
        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlReport.Visible = false;
            btnPrint.Text = "Export to Excel";
            btnReport.Text = "View Report";

            listOfTransactions = Transaction.Get("city", cbCity.SelectedValue.ToString());

            if (pnlReport.Visible)
            {
                GenerateReport();
            }
            else
            {
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
                    /*
                    dgvData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvData.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns["btnPrint"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;*/
                }
                else
                {
                    dgvData.DataSource = null;
                    dgvData.Columns.Clear();
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (btnReport.Text == "View Report")
            {
                pnlReport.Size = dgvData.Size;
                btnReport.Text = "Back to Data";
                pnlReport.Visible = true;
                btnPrint.Text = "Print Report to PDF";
                GenerateReport();
            }
            else
            {
                btnReport.Text = "View Report";
                pnlReport.Visible = false;
                btnPrint.Text = "Export to Excel";
                cbCity_SelectedIndexChanged(sender, e);
            }

        }

        private void GenerateReport()
        {
            int cityId = (int)cbCity.SelectedValue;
            lblReportTitle.Text = "Sales Performance in " + City.Get("Id", cityId.ToString())[0].Name;
            // Revenue Daily Average
            lblRevenueDailyAverage.Text = Transaction.GetRevenueDailyAverage("c.Id", cityId, false).ToString("C2");

            // Revenue Monthly Average
            lblRevenueMonthlyAverage.Text = Transaction.GetRevenueMonthlyAverage("c.Id", cityId, false).ToString("C2");

            // Revenue Yearly Average
            lblRevenueYearlyAverage.Text = Transaction.GetRevenueYearlyAverage("c.Id", cityId, false).ToString("C2");

            // Total Revenue
            lblTotalRevenue.Text = "TOTAL : "+Transaction.CalculateTotalRevenue("c.Id", cityId, false).ToString("C2");

            // Transaction Daily Average
            lblTransactionDailyAvg.Text = Transaction.GetDailyAverageNumber("c.Id", cityId, false).ToString();

            // Transaction Monthly Average
            lblTransactionMonthlyAvg.Text = Transaction.GetMonthlyAverageNumber("c.Id", cityId, false).ToString();

            // Transaction Yearly Average
            lblTransactionYearlyAvg.Text = Transaction.GetYearlyAverageNumber("c.Id", cityId, false).ToString();

            // Total Transaction Number
            lblTotalTransaction.Text = "TOTAL : "+ Transaction.CalculateTotalNumber("c.Id", cityId, false).ToString();

            // Common Pet Types
            lblCommonPetType.Text = Transaction.GetCommonPetTypes("c.Id", cityId, false);

            // Common Service Types
            lblCommonServiceType.Text = Transaction.GetCommonService("c.Id", cityId, false);

            // Common Treatment
            lblCommonTreatment.Text = Transaction.GetCommonTreatment("c.Id", cityId, false);

            lblRank.Text = "RANK : #" + Transaction.GetCityRank("c.Id", cityId);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (pnlReport.Visible)
            {
                int cityId = (int)cbCity.SelectedValue;
                bool res = Transaction.PrintCityReport("ReportCity" + cityId + ".pdf", new Font("Courier New", 12), cbCity.Text, lblRevenueDailyAverage.Text, lblRevenueMonthlyAverage.Text, lblRevenueYearlyAverage.Text, lblTotalRevenue.Text, lblTransactionDailyAvg.Text, lblTransactionMonthlyAvg.Text, lblTransactionYearlyAvg.Text, lblTotalTransaction.Text, lblCommonPetType.Text, lblCommonServiceType.Text, lblCommonTreatment.Text, lblRank.Text, out string path);

                if (res)
                {
                    DialogResult dr = MessageBox.Show("Sales performance report for city " + cbCity.Text + " has been printed succesfully! Would you like to view the report?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                        System.Diagnostics.Process.Start(path);
                }
            }
            else
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

                string fileName = "Sales-From-" + cbCity.Text;

                fileName += ".xlsx";
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);

                string filePath = xlWorkbook.Path;
                DialogResult dr = MessageBox.Show("Data succesfully exported to excel! Would you like to view the excel file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                if (dr == DialogResult.Yes)
                    System.Diagnostics.Process.Start(filePath + "\\" + fileName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns["btnPrint"] != null && e.ColumnIndex == dgvData.Columns["btnPrint"].Index && e.RowIndex != -1)
            {
                Transaction t = listOfTransactions[e.RowIndex];
                string fileName = "Transaction_" + t.Branch.Name + "_Id#" + t.Id + ".pdf";

                bool res = Transaction.Print(t, fileName, new Font("Courier New", 12), out string path);

                if (res)
                {
                    DialogResult dr = MessageBox.Show("Transaction has been printed succesfully! Would you like to view the report?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                        System.Diagnostics.Process.Start(path);
                }
            }
        }

        private void FrmSalesCity_Resize(object sender, EventArgs e)
        {
            pnlReport.Size = dgvData.Size;
        }

        private void lblTotalRevenue_TextChanged(object sender, EventArgs e)
        {
            while (lblTotalRevenue.Width < System.Windows.Forms.TextRenderer.MeasureText(lblTotalRevenue.Text,
     new Font(lblTotalRevenue.Font.FontFamily, lblTotalRevenue.Font.Size, lblTotalRevenue.Font.Style)).Width)
            {
                lblTotalRevenue.Font = new Font(lblTotalRevenue.Font.FontFamily, lblTotalRevenue.Font.Size - 0.5f, lblTotalRevenue.Font.Style);
            }
        }

        private void lblTotalTransaction_TextChanged(object sender, EventArgs e)
        {
            while (lblTotalTransaction.Width < System.Windows.Forms.TextRenderer.MeasureText(lblTotalTransaction.Text,
     new Font(lblTotalTransaction.Font.FontFamily, lblTotalTransaction.Font.Size, lblTotalTransaction.Font.Style)).Width)
            {
                lblTotalTransaction.Font = new Font(lblTotalTransaction.Font.FontFamily, lblTotalTransaction.Font.Size - 0.5f, lblTotalTransaction.Font.Style);
            }
        }
    }
}
