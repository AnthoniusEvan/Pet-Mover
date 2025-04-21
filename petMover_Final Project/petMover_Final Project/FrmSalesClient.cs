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
    public partial class FrmSalesClient : Form
    {
        List<Transaction> listOfTransactions = new List<Transaction>();
        public FrmSalesClient()
        {
            InitializeComponent();
        }

        private void FrmSalesClient_Load(object sender, EventArgs e)
        {
            cbClient.DataSource = Client.Get("", "");
            cbClient.DisplayMember = "Name";
            cbClient.ValueMember = "Id";
            cbClient_SelectedIndexChanged(sender, e);
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlReport.Visible = false;
            btnPrint.Text = "Export to Excel";
            btnReport.Text = "View Report";

            listOfTransactions = Transaction.Get("client", cbClient.SelectedValue.ToString());
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
                cbClient_SelectedIndexChanged(sender, e);
            }
        }

        private void GenerateReport()
        {
            int clientId = (int)cbClient.SelectedValue;
            lblReportTitle.Text = "Sales Performance for " + Client.Get("Id", clientId.ToString())[0].Name;
            // Highest Spending
            lblHighestAmount.Text = Transaction.GetHighestAmount(clientId).ToString("C2");

            // Revenue Monthly Average
            lblRevenueMonthlyAverage.Text = Transaction.GetRevenueMonthlyAverage("t.ClientId", clientId, false).ToString("C2");

            // Revenue Yearly Average
            lblRevenueYearlyAverage.Text = Transaction.GetRevenueYearlyAverage("t.ClientId", clientId, false).ToString("C2");

            // Total Revenue
            lblTotalRevenue.Text = "TOTAL : " + Transaction.CalculateTotalRevenue("t.ClientId", clientId, false).ToString("C2");

            // Transaction Monthly Average
            lblTransactionMonthlyAvg.Text = Transaction.GetMonthlyAverageNumber("t.ClientId", clientId, false).ToString();

            // Transaction Yearly Average
            lblTransactionYearlyAvg.Text = Transaction.GetYearlyAverageNumber("t.ClientId", clientId, false).ToString();

            // Total Transaction Number
            lblTotalTransaction.Text = "TOTAL : " + Transaction.CalculateTotalNumber("t.ClientId", clientId, false).ToString();

            // Common Pet Types
            lblPetTypeOwned.Text = Transaction.GetCommonPetTypes("t.ClientId", clientId, false);

            // Common Service Types
            lblCommonServiceType.Text = Transaction.GetCommonService("t.ClientId", clientId, false);

            // Common Treatment
            lblCommonTreatment.Text = Transaction.GetCommonTreatment("t.ClientId", clientId, false);

            lblRank.Text = "RANK : #" + Transaction.GetClientRank("t.ClientId", clientId);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (pnlReport.Visible)
            {
                int clientId = (int)cbClient.SelectedValue;
                bool res = Transaction.PrintClientReport("ReportClient" + clientId + ".pdf", new Font("Courier New", 12), cbClient.Text, lblHighestAmount.Text, lblRevenueMonthlyAverage.Text, lblRevenueYearlyAverage.Text, lblTotalRevenue.Text, lblTransactionMonthlyAvg.Text, lblTransactionYearlyAvg.Text, lblTotalTransaction.Text, lblPetTypeOwned.Text, lblCommonServiceType.Text, lblCommonTreatment.Text, lblRank.Text, out string path);

                if (res)
                {
                    DialogResult dr = MessageBox.Show("Sales performance report for client " + cbClient.Text + " has been printed succesfully! Would you like to view the report?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                string fileName = "Sales-From-" + cbClient.Text;

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
                string fileName = "Transaction_"+t.Branch.Name+"_Id#" + t.Id + ".pdf";

                bool res = Transaction.Print(t, fileName, new Font("Courier New", 12), out string path);

                if (res)
                {
                    DialogResult dr = MessageBox.Show("Transaction has been printed succesfully! Would you like to view the report?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                        System.Diagnostics.Process.Start(path);
                }
            }
        }

        private void FrmSalesClient_Resize(object sender, EventArgs e)
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
