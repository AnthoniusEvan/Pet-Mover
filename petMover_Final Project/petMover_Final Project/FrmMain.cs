using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbSalesPurchasing;
using petMover_Final_Project.Properties;
namespace petMover_Final_Project
{
    public partial class FrmMain : Form
    {
        public Staff activeUser;
        bool isCollapsed = false;
        int pnlTabOldWidth;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            pnlTabOldWidth = pnlTab.Width;
            lblShowTransaction.Text = "Display\nTransaction";
            foreach (Control c in pnlSubMaster.Controls)
            {
                c.MouseLeave += new EventHandler(pnlMaster_MouseLeave);
                if (c is Panel)
                {
                    foreach (Control childC in c.Controls)
                    {
                        childC.MouseLeave += new EventHandler(pnlMaster_MouseLeave);
                    }
                }
            }
            foreach (Control c in pnlHeaderDetails.Controls)
            {
                c.MouseLeave += new EventHandler(pnlTransaction_MouseLeave);
                if (c is Panel)
                {
                    foreach (Control childC in c.Controls)
                    {
                        childC.MouseLeave += new EventHandler(pnlTransaction_MouseLeave);
                    }
                }
            }
            foreach (Control c in pnlSubReport.Controls)
            {
                c.MouseLeave += new EventHandler(pnlSubReport_MouseLeave);
                if (c is Panel)
                {
                    foreach (Control childC in c.Controls)
                    {
                        childC.MouseLeave += new EventHandler(pnlSubReport_MouseLeave);
                    }
                }
            }

            foreach (Control c in pnlCage.Controls)
            {
                c.Click += new EventHandler(pnlCage_Click);
            }
            foreach (Control c in pnlCity.Controls)
            {
                c.Click += new EventHandler(pnlCity_Click);
            }

            foreach (Control c in pnlPetType.Controls)
            {
                c.Click += new EventHandler(pnlPetType_Click);
            }

            foreach (Control c in pnlServiceType.Controls)
            {
                c.Click += new EventHandler(pnlServiceType_Click);
            }

            foreach (Control c in pnlTreatment.Controls)
            {
                c.Click += new EventHandler(pnlTreatment_Click);
            }

            // Milestone 2
            foreach (Control c in pnlBranch.Controls)
            {
                c.Click += new EventHandler(pnlBranch_Click);
            }
            foreach (Control c in pnlClient.Controls)
            {
                c.Click += new EventHandler(pnlClient_Click);
            }
            foreach (Control c in pnlCageRate.Controls)
            {
                c.Click += new EventHandler(pnlCageRate_Click);
            }
            foreach (Control c in pnlStaff.Controls)
            {
                c.Click += new EventHandler(pnlStaff_Click);
            }
            foreach (Control c in pnlTransportRate.Controls)
            {
                c.Click += new EventHandler(pnlTransportRate_Click);
            }
            foreach(Control c in pnlTransaction.Controls)
            {
                c.Click += new EventHandler(pnlTransaction_Click);
            }
            foreach (Control c in pnlTreatmentRate.Controls)
            {
                c.Click += new EventHandler(pnlTreatmentRate_Click);
            }


            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                {
                    c.BackColor = Color.Thistle;
                    break;
                }
            }

            this.WindowState = FormWindowState.Maximized;
            try
            {
                FrmLogin fLogin = new FrmLogin();
                fLogin.Owner = this;

                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    lblWelcome.Text = "Welcome, " + activeUser.Name;
                    dbConnection dbCon = new dbConnection(db.Default.DbServer, db.Default.DbName, db.Default.DbUsername, db.Default.DbPassword);
                    //MessageBox.Show("Succesfully connect to " + db.Default.DbName, "Information");
                }
                else
                {
                    MessageBox.Show("User authentication failed! No username or password provided!", "Closing Application", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to " + db.Default.DbName + ". " + ex.Message);
            }
        }
        public string title;
        public string transactionId;
        public void OpenMdiChildForm()
        {
            bool isFormOpened = false;
            Form activeForm=new Form();
            FrmList nf = new FrmList();
            nf.Tag = "notnull";
            if (title == "Transaction Logs") nf.Tag = title + " " + transactionId;

            foreach (Form f in Application.OpenForms)
            {
                if ((string)f.Tag == (string)title || (string)f.Tag == (string)nf.Tag)
                {
                    activeForm = f;
                    isFormOpened = true;
                    break;
                }
            }
            if (activeForm == null || !isFormOpened)
            {
                nf.MdiParent = this;
                nf.Tag = title;
                nf.lblTitle.Text = title;
                nf.Text = "List of " + title;
                if (title == "Transaction Logs") nf.Tag = title + " " + transactionId;
                nf.Show();
            }
            else
            {
                activeForm.Show();
                activeForm.BringToFront();
            }
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            isCollapsed = !isCollapsed;
            if (isCollapsed)
            {
                pnlTab.Width = lblTransaction.Left + lblTransaction.Width;
            }
            else
            {
                pnlTab.Width = pnlTabOldWidth;
            }
        }

        private void btnCollapse_MouseEnter(object sender, EventArgs e)
        {
            btnCollapse.Image = Resources.menuHover;
        }

        private void btnCollapse_MouseLeave(object sender, EventArgs e)
        {
            btnCollapse.Image = Resources.menu;
        }

        private void pnlMaster_MouseEnter(object sender, EventArgs e)
        {
            btnMaster.Image = Resources.databaseHover;
            lblMaster.ForeColor = Color.Orange;
            pnlSubMaster.Visible = true;
            pnlSubMaster.Top = pnlMaster.Top;
            pnlSubMaster.Left = pnlTab.Right;
        }

        private void pnlMaster_MouseLeave(object sender, EventArgs e)
        {
            if (!pnlSubMaster.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                btnMaster.Image = Resources.database;
                lblMaster.ForeColor = Color.Black;
                pnlSubMaster.Visible = false;
            }
        }

        private void btnMaster_MouseEnter(object sender, EventArgs e)
        {
            pnlMaster_MouseEnter(sender, e);
        }

        private void btnMaster_MouseLeave(object sender, EventArgs e)
        {
            pnlMaster_MouseLeave(sender, e);
        }

        private void lblMaster_MouseEnter(object sender, EventArgs e)
        {
            pnlMaster_MouseEnter(sender, e);
        }

        private void lblMaster_MouseLeave(object sender, EventArgs e)
        {
            pnlMaster_MouseLeave(sender, e);
        }

        private void pnlTransaction_MouseEnter(object sender, EventArgs e)
        {
            btnTransaction.Image = Resources.transactionHover;
            lblTransaction.ForeColor = Color.Orange;

            //pnlHeaderDetails.Visible = true;
            //pnlHeaderDetails.Top = pnlTransaction.Top;
            //pnlHeaderDetails.Left = pnlTab.Right;
        }

        private void pnlTransaction_MouseLeave(object sender, EventArgs e)
        {
            if (!pnlHeaderDetails.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                btnTransaction.Image = Resources.transaction;
                lblTransaction.ForeColor = Color.Black;
                //pnlHeaderDetails.Visible = false;
            }
        }

        private void btnTransaction_MouseEnter(object sender, EventArgs e)
        {
            pnlTransaction_MouseEnter(sender, e);
        }

        private void btnTransaction_MouseLeave(object sender, EventArgs e)
        {
            pnlTransaction_MouseLeave(sender, e);
        }

        private void lblTransaction_MouseEnter(object sender, EventArgs e)
        {
            pnlTransaction_MouseEnter(sender, e);
        }

        private void lblTransaction_MouseLeave(object sender, EventArgs e)
        {
            pnlTransaction_MouseLeave(sender, e);
        }

        private void btnReport_MouseEnter(object sender, EventArgs e)
        {
            pnlReport_MouseEnter(sender, e);
        }

        private void btnReport_MouseLeave(object sender, EventArgs e)
        {
            pnlReport_MouseLeave(sender, e);
        }

        private void pnlReport_MouseEnter(object sender, EventArgs e)
        {
            btnReport.Image = Resources.reportHover;
            lblReport.ForeColor = Color.Orange;
            pnlSubReport.Top = pnlReport.Top;
            pnlSubReport.Left = pnlTab.Right;
            pnlSubReport.Visible = true;
        }

        private void pnlReport_MouseLeave(object sender, EventArgs e)
        {
            if (!pnlSubReport.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                btnReport.Image = Resources.report;
                lblReport.ForeColor = Color.Black;
                pnlSubReport.Visible = false;
            }
        }

        private void lblReport_MouseEnter(object sender, EventArgs e)
        {
            pnlReport_MouseEnter(sender, e);
        }

        private void lblReport_MouseLeave(object sender, EventArgs e)
        {
            pnlReport_MouseLeave(sender, e);
        }

        private void pnlExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.Image = Resources.exitHover;
            lblExit.ForeColor = Color.FromArgb(212,16,2);
        }

        private void pnlExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.Image = Resources.exit;
            lblExit.ForeColor = Color.Black;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            pnlExit_MouseEnter(sender, e);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            pnlExit_MouseLeave(sender, e);
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            pnlExit_MouseEnter(sender, e);
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            pnlExit_MouseLeave(sender, e);
        }

        private void pnlCage_MouseEnter(object sender, EventArgs e)
        {
            btnCage.Image = Resources.cageHover;
            lblCage.ForeColor = Color.Orange;
        }

        private void pnlCage_MouseLeave(object sender, EventArgs e)
        {
            btnCage.Image = Resources.cage;
            lblCage.ForeColor = Color.Black;
        }

        private void lblCage_MouseEnter(object sender, EventArgs e)
        {
            pnlCage_MouseEnter(sender, e);
        }

        private void lblCage_MouseLeave(object sender, EventArgs e)
        {
            pnlCage_MouseLeave(sender, e);
        }

        private void btnCage_MouseEnter(object sender, EventArgs e)
        {
            pnlCage_MouseEnter(sender, e);
        }

        private void btnCage_MouseLeave(object sender, EventArgs e)
        {
            pnlCage_MouseLeave(sender, e);
        }

        private void pnlCity_MouseEnter(object sender, EventArgs e)
        {
            btnCity.Image = Resources.cityHover;
            lblCity.ForeColor = Color.Orange;
        }

        private void pnlCity_MouseLeave(object sender, EventArgs e)
        {
            btnCity.Image = Resources.city;
            lblCity.ForeColor = Color.Black;
        }

        private void lblCity_MouseEnter(object sender, EventArgs e)
        {
            pnlCity_MouseEnter(sender, e);
        }

        private void lblCity_MouseLeave(object sender, EventArgs e)
        {
            pnlCity_MouseLeave(sender, e);
        }

        private void btnCity_MouseEnter(object sender, EventArgs e)
        {
            pnlCity_MouseEnter(sender, e);
        }

        private void btnCity_MouseLeave(object sender, EventArgs e)
        {
            pnlCity_MouseLeave(sender, e);
        }

        private void pnlPetType_MouseEnter(object sender, EventArgs e)
        {
            btnPetType.Image = Resources.pettypeHover;
            lblPetType.ForeColor = Color.Orange;
        }

        private void pnlPetType_MouseLeave(object sender, EventArgs e)
        {
            btnPetType.Image = Resources.pettype;
            lblPetType.ForeColor = Color.Black;
        }

        private void lblPetType_MouseEnter(object sender, EventArgs e)
        {
            pnlPetType_MouseEnter(sender, e);
        }

        private void lblPetType_MouseLeave(object sender, EventArgs e)
        {
            pnlPetType_MouseLeave(sender, e);
        }

        private void btnPetType_MouseEnter(object sender, EventArgs e)
        {
            pnlPetType_MouseEnter(sender, e);
        }

        private void btnPetType_MouseLeave(object sender, EventArgs e)
        {
            pnlPetType_MouseLeave(sender, e);
        }

        private void pnlServiceType_MouseEnter(object sender, EventArgs e)
        {
            btnServiceType.Image = Resources.servicetypeHover;
            lblServiceType.ForeColor = Color.Orange;
        }

        private void pnlServiceType_MouseLeave(object sender, EventArgs e)
        {
            btnServiceType.Image = Resources.servicetype;
            lblServiceType.ForeColor = Color.Black;
        }

        private void lblServiceType_MouseEnter(object sender, EventArgs e)
        {
            pnlServiceType_MouseEnter(sender, e);
        }

        private void lblServiceType_MouseLeave(object sender, EventArgs e)
        {
            pnlServiceType_MouseLeave(sender, e);
        }

        private void btnServiceType_MouseEnter(object sender, EventArgs e)
        {
            pnlServiceType_MouseEnter(sender, e);
        }

        private void btnServiceType_MouseLeave(object sender, EventArgs e)
        {
            pnlServiceType_MouseLeave(sender, e);
        }

        private void pnlTreatment_MouseEnter(object sender, EventArgs e)
        {
            btnTreatment.Image = Resources.treatmentHover;
            lblTreatment.ForeColor = Color.Orange;
        }

        private void pnlTreatment_MouseLeave(object sender, EventArgs e)
        {
            btnTreatment.Image = Resources.treatment;
            lblTreatment.ForeColor = Color.Black;
        }

        private void lblTreatment_MouseEnter(object sender, EventArgs e)
        {
            pnlTreatment_MouseEnter(sender, e);
        }

        private void lblTreatment_MouseLeave(object sender, EventArgs e)
        {
            pnlTreatment_MouseLeave(sender, e);
        }

        private void btnTreatment_MouseEnter(object sender, EventArgs e)
        {
            pnlTreatment_MouseEnter(sender, e);
        }

        private void btnTreatment_MouseLeave(object sender, EventArgs e)
        {
            pnlTreatment_MouseLeave(sender, e);
        }

        private void pnlSubMaster_MouseLeave(object sender, EventArgs e)
        {
            pnlMaster_MouseLeave(sender, e);
        }

        private void pnlCage_Click(object sender, EventArgs e)
        {
            title = "Cages";
            OpenMdiChildForm();
        }

        private void pnlCity_Click(object sender, EventArgs e)
        {
            title = "Cities";
            OpenMdiChildForm();
        }

        private void pnlPetType_Click(object sender, EventArgs e)
        {
            title = "Pet Types";
            OpenMdiChildForm();
        }

        private void pnlServiceType_Click(object sender, EventArgs e)
        {
            title = "Service Types";
            OpenMdiChildForm();
        }

        private void pnlTreatment_Click(object sender, EventArgs e)
        {
            title = "Treatments";
            OpenMdiChildForm();
        }

        private void pnlExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlBranch_Click(object sender, EventArgs e)
        {
            title = "Branches";
            OpenMdiChildForm();
        }

        private void pnlCageRate_Click(object sender, EventArgs e)
        {
            title = "Cage Rates";
            OpenMdiChildForm();
        }

        private void pnlClient_Click(object sender, EventArgs e)
        {
            title = "Clients";
            OpenMdiChildForm();
        }

        private void pnlStaff_Click(object sender, EventArgs e)
        {
            title = "Staffs";
            OpenMdiChildForm();
        }

        private void pnlTransportRate_Click(object sender, EventArgs e)
        {
            title = "Transport Rates";
            OpenMdiChildForm();
        }

        private void pnlBranch_MouseEnter(object sender, EventArgs e)
        {
            btnBranch.Image = Resources.branchHover;
            lblBranch.ForeColor = Color.Orange;
        }

        private void pnlBranch_MouseLeave(object sender, EventArgs e)
        {
            btnBranch.Image = Resources.branch;
            lblBranch.ForeColor = Color.Black;
        }

        private void lblBranch_MouseEnter(object sender, EventArgs e)
        {
            pnlBranch_MouseEnter(sender, e);
        }

        private void lblBranch_MouseLeave(object sender, EventArgs e)
        {
            pnlBranch_MouseLeave(sender, e);
        }

        private void btnBranch_MouseEnter(object sender, EventArgs e)
        {
            pnlBranch_MouseEnter(sender, e);
        }

        private void btnBranch_MouseLeave(object sender, EventArgs e)
        {
            pnlBranch_MouseLeave(sender, e);
        }

        private void pnlCageRate_MouseEnter(object sender, EventArgs e)
        {
            btnCageRate.Image = Resources.cagerateHover;
            lblCageRate.ForeColor = Color.Orange;
        }

        private void pnlCageRate_MouseLeave(object sender, EventArgs e)
        {
            btnCageRate.Image = Resources.cagerate;
            lblCageRate.ForeColor = Color.Black;
        }

        private void lblCageRate_MouseEnter(object sender, EventArgs e)
        {
            pnlCageRate_MouseEnter(sender, e);
        }

        private void lblCageRate_MouseLeave(object sender, EventArgs e)
        {
            pnlCageRate_MouseLeave(sender, e);
        }

        private void btnCageRate_MouseEnter(object sender, EventArgs e)
        {
            pnlCageRate_MouseEnter(sender, e);
        }

        private void btnCageRate_MouseLeave(object sender, EventArgs e)
        {
            pnlCageRate_MouseLeave(sender, e);
        }

        private void pnlClient_MouseEnter(object sender, EventArgs e)
        {
            btnClient.Image = Resources.clientHover;
            lblClient.ForeColor = Color.Orange;
        }

        private void pnlClient_MouseLeave(object sender, EventArgs e)
        {
            btnClient.Image = Resources.client;
            lblClient.ForeColor = Color.Black;
        }

        private void lblClient_MouseEnter(object sender, EventArgs e)
        {
            pnlClient_MouseEnter(sender, e);
        }

        private void lblClient_MouseLeave(object sender, EventArgs e)
        {
            pnlClient_MouseLeave(sender, e);
        }

        private void btnClient_MouseEnter(object sender, EventArgs e)
        {

            pnlClient_MouseEnter(sender, e);
        }

        private void btnClient_MouseLeave(object sender, EventArgs e)
        {
            pnlClient_MouseLeave(sender, e);
        }

        private void pnlStaff_MouseEnter(object sender, EventArgs e)
        {
            btnStaff.Image = Resources.staffHover;
            lblStaff.ForeColor = Color.Orange;
        }

        private void pnlStaff_MouseLeave(object sender, EventArgs e)
        {
            btnStaff.Image = Resources.staff;
            lblStaff.ForeColor = Color.Black;
        }

        private void lblStaff_MouseEnter(object sender, EventArgs e)
        {
            pnlStaff_MouseEnter(sender, e);
        }

        private void lblStaff_MouseLeave(object sender, EventArgs e)
        {
            pnlStaff_MouseLeave(sender, e);
        }

        private void btnStaff_MouseEnter(object sender, EventArgs e)
        {
            pnlStaff_MouseEnter(sender, e);
        }

        private void btnStaff_MouseLeave(object sender, EventArgs e)
        {
            pnlStaff_MouseLeave(sender, e);
        }

        private void pnlTransportRate_MouseEnter(object sender, EventArgs e)
        {
            btnTransportRate.Image = Resources.transportrateHover;
            lblTransportRate.ForeColor = Color.Orange;
        }

        private void pnlTransportRate_MouseLeave(object sender, EventArgs e)
        {
            btnTransportRate.Image = Resources.transportrate;
            lblTransportRate.ForeColor = Color.Black;
        }

        private void lblTransportRate_MouseEnter(object sender, EventArgs e)
        {
            pnlTransportRate_MouseEnter(sender, e);
        }

        private void lblTransportRate_MouseLeave(object sender, EventArgs e)
        {
            pnlTransportRate_MouseLeave(sender, e);
        }

        private void btnTransportRate_MouseEnter(object sender, EventArgs e)
        {
            pnlTransportRate_MouseEnter(sender, e);
        }

        private void btnTransportRate_MouseLeave(object sender, EventArgs e)
        {
            pnlTransportRate_MouseLeave(sender, e);
        }

        private void pnlTransactionList_MouseEnter(object sender, EventArgs e)
        {
            lblTransactionList.ForeColor = Color.Orange;
            btnTransactionList.Image = Resources.transactionListHover;
        }

        private void pnlTransactionList_MouseLeave(object sender, EventArgs e)
        {
            lblTransactionList.ForeColor = Color.Black;
            btnTransactionList.Image = Resources.transactionList;
        }

        private void btnTransactionList_MouseEnter(object sender, EventArgs e)
        {
            pnlTransactionList_MouseEnter(sender, e);
        }

        private void btnTransactionList_MouseLeave(object sender, EventArgs e)
        {
            pnlTransactionList_MouseLeave(sender, e);
        }

        private void lblTransactionList_MouseEnter(object sender, EventArgs e)
        {
            pnlTransactionList_MouseEnter(sender, e);
        }

        private void lblTransactionList_MouseLeave(object sender, EventArgs e)
        {
            pnlTransactionList_MouseLeave(sender, e);
        }

        private void pnlTransactionLog_MouseEnter(object sender, EventArgs e)
        {
            lblTransactionLog.ForeColor = Color.Orange;
            btnTransactionLog.Image = Resources.transactionLogHover;
        }

        private void pnlTransactionLog_MouseLeave(object sender, EventArgs e)
        {
            lblTransactionLog.ForeColor = Color.Black;
            btnTransactionLog.Image = Resources.transactionLog;
        }

        private void btnTransactionLog_MouseEnter(object sender, EventArgs e)
        {
            pnlTransactionLog_MouseEnter(sender, e);
        }

        private void btnTransactionLog_MouseLeave(object sender, EventArgs e)
        {
            pnlTransactionLog_MouseLeave(sender, e);
        }

        private void lblTransactionLog_MouseEnter(object sender, EventArgs e)
        {
            pnlTransactionLog_MouseEnter(sender, e);
        }

        private void lblTransactionLog_MouseLeave(object sender, EventArgs e)
        {
            pnlTransactionLog_MouseLeave(sender, e);
        }

        private void pnlTransactionList_Click(object sender, EventArgs e)
        {
            //title = "Transactions";
            //OpenMdiChildForm();
        }

        private void pnlTransactionLog_Click(object sender, EventArgs e)
        {
            //title = "Transaction Logs";
            //OpenMdiChildForm();
        }
        private void pnlTransaction_Click(object sender, EventArgs e)
        {
            title = "Transactions";
            OpenMdiChildForm();
        }

        private void pnlSubReport_MouseLeave(object sender, EventArgs e)
        {
            pnlReport_MouseLeave(sender, e);
        }
        private void pnlReportTransactions_Click(object sender, EventArgs e)
        {
            Form activeForm = Application.OpenForms["FrmTransactionReport"];
            if (activeForm == null)
            {
                FrmTransactionReport f = new FrmTransactionReport();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                activeForm.Show();
                activeForm.BringToFront();
            }
        }
        private void lblReportTransactions_Click(object sender, EventArgs e)
        {
            pnlReportTransactions_Click(sender, e);
        }

        private void pnlSalesClient_Click(object sender, EventArgs e)
        {
            Form activeForm = Application.OpenForms["FrmSalesClient"];
            if (activeForm == null)
            {
                FrmSalesClient f = new FrmSalesClient();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                activeForm.Show();
                activeForm.BringToFront();
            }
        }

        private void lblSalesClient_Click(object sender, EventArgs e)
        {
            pnlSalesClient_Click(sender, e);
        }

        private void pnlSalesCity_Click(object sender, EventArgs e)
        {
            Form activeForm = Application.OpenForms["FrmSalesCity"];
            if (activeForm == null)
            {
                FrmSalesCity f = new FrmSalesCity();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                activeForm.Show();
                activeForm.BringToFront();
            }
        }

        private void lblSalesCity_Click(object sender, EventArgs e)
        {
            pnlSalesCity_Click(sender, e);
        }

        private void pnlReportTransactions_MouseEnter(object sender, EventArgs e)
        {
            lblReportTransactions.ForeColor = Color.Orange;
        }

        private void pnlReportTransactions_MouseLeave(object sender, EventArgs e)
        {
            lblReportTransactions.ForeColor = Color.Black;
            pnlReport_MouseLeave(sender, e);
        }

        private void lblReportTransactions_MouseEnter(object sender, EventArgs e)
        {
            pnlReportTransactions_MouseEnter(sender, e);
        }

        private void lblReportTransactions_MouseLeave(object sender, EventArgs e)
        {
            pnlReportTransactions_MouseLeave(sender, e);
        }

        private void pnlSalesClient_MouseEnter(object sender, EventArgs e)
        {
            lblSalesClient.ForeColor = Color.Orange;
        }

        private void pnlSalesClient_MouseLeave(object sender, EventArgs e)
        {
            lblSalesClient.ForeColor = Color.Black;
            pnlReport_MouseLeave(sender, e);
        }

        private void lblSalesClient_MouseEnter(object sender, EventArgs e)
        {
            pnlSalesClient_MouseEnter(sender, e);
        }

        private void lblSalesClient_MouseLeave(object sender, EventArgs e)
        {
            pnlSalesClient_MouseLeave(sender, e);
        }

        private void pnlSalesCity_MouseEnter(object sender, EventArgs e)
        {
            lblSalesCity.ForeColor = Color.Orange;
        }

        private void pnlSalesCity_MouseLeave(object sender, EventArgs e)
        {
            lblSalesCity.ForeColor = Color.Black;
            pnlReport_MouseLeave(sender, e);
        }

        private void lblSalesCity_MouseEnter(object sender, EventArgs e)
        {
            pnlSalesCity_MouseEnter(sender, e);
        }

        private void lblSalesCity_MouseLeave(object sender, EventArgs e)
        {
            pnlSalesCity_MouseLeave(sender, e);
        }

        private void pnlTreatmentRate_Click(object sender, EventArgs e)
        {
            title = "Treatment Rates";
            OpenMdiChildForm();
        }

        private void pnlTreatmentRate_MouseEnter(object sender, EventArgs e)
        {
            btnTreatmentRate.BackgroundImage = Resources.treatmentHover;
            lblTreatmentRate.ForeColor = Color.Orange;
        }

        private void pnlTreatmentRate_MouseLeave(object sender, EventArgs e)
        {
            btnTreatmentRate.BackgroundImage = Resources.treatment;
            lblTreatmentRate.ForeColor = Color.Black;
        }

        private void lblTreatmentRate_MouseEnter(object sender, EventArgs e)
        {
            pnlTreatmentRate_MouseEnter(sender, e);
        }

        private void lblTreatmentRate_MouseLeave(object sender, EventArgs e)
        {
            pnlTreatment_MouseLeave(sender, e);
        }

        private void btnTreatmentRate_MouseEnter(object sender, EventArgs e)
        {
            pnlTreatmentRate_MouseEnter(sender, e);
        }

        private void btnTreatmentRate_MouseLeave(object sender, EventArgs e)
        {
            pnlTreatment_MouseLeave(sender, e);
        }
        
        private void pnlShowTransaction_Click(object sender, EventArgs e)
        {
            Form activeForm = Application.OpenForms["FrmTransactionDisplay"];
            if (activeForm == null)
            {
                FrmTransactionDisplay ftd = new FrmTransactionDisplay();
                ftd.Show();
            }
            else
            {
                activeForm.Show();
                activeForm.BringToFront();
            }
        }

        private void btnShowTransaction_Click(object sender, EventArgs e)
        {
            pnlShowTransaction_Click(sender, e);
        }

        private void lblShowTransaction_Click(object sender, EventArgs e)
        {
            pnlShowTransaction_Click(sender, e);
        }

        private void pnlShowTransaction_MouseEnter(object sender, EventArgs e)
        {
            btnShowTransaction.Image = Resources.showTransactionHover;
            lblShowTransaction.ForeColor = Color.Orange;
        }

        private void pnlShowTransaction_MouseLeave(object sender, EventArgs e)
        {
            btnShowTransaction.Image = Resources.showTransaction;
            lblShowTransaction.ForeColor = Color.Black;
        }

        private void btnShowTransaction_MouseEnter(object sender, EventArgs e)
        {
            pnlShowTransaction_MouseEnter(sender, e);
        }

        private void btnShowTransaction_MouseLeave(object sender, EventArgs e)
        {
            pnlShowTransaction_MouseLeave(sender, e);
        }

        private void lblShowTransaction_MouseEnter(object sender, EventArgs e)
        {
            pnlShowTransaction_MouseEnter(sender, e);
        }

        private void lblShowTransaction_MouseLeave(object sender, EventArgs e)
        {
            pnlShowTransaction_MouseLeave(sender, e);
        }
    }
}
