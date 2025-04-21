using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petMover_Final_Project
{
    public partial class FrmTransactionDisplay : Form
    {
        public FrmTransactionDisplay()
        {
            InitializeComponent();
        }

        private void tmrMovingText_Tick(object sender, EventArgs e)
        {
            if (lblTitle.Left + lblTitle.Width < 0)
            {
                lblTitle.Visible = false;
                lblTitle.Left = Width;
            }

            if (lblTitle2.Left + lblTitle2.Width < 0)
            {
                lblTitle2.Visible = false;
                lblTitle2.Left = Width;
            }

            if (lblTitle.Left + lblTitle.Width / 2 < 0)
            {
                if (!lblTitle2.Visible)
                {
                    lblTitle2.Visible = true;
                    lblTitle2.Text = lblTitle.Text;
                    lblTitle2.Left = Width;
                }
            }

            if (lblTitle2.Left + lblTitle2.Width / 2 < 0)
            {
                if (!lblTitle.Visible)
                {
                    lblTitle.Visible = true;
                    lblTitle.Left = Width;
                }
            }

            if (lblTitle2.Visible)
                lblTitle2.Left -= 1;
            if (lblTitle.Visible)
                lblTitle.Left-=1;

            if (enableFormControls) interval++;

            if (interval == 5)
            {
                interval = 0;
                enableFormControls = false;
                pnlFormControls.Visible = true;
            }
        }

        private void dgvProducts_Resize(object sender, EventArgs e)
        {
            //dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        bool enableFormControls = false;
        int interval = 0;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pnlTitle_MouseLeave(object sender, EventArgs e)
        {
            if (!lblTitle.Bounds.Contains(pnlTitle.PointToClient(Cursor.Position))&& !lblTitle2.Bounds.Contains(pnlTitle.PointToClient(Cursor.Position)) && !pnlFormControls.Bounds.Contains(pnlTitle.PointToClient(Cursor.Position)))
                pnlFormControls.Visible = false;
        }

        private void pnlTitle_MouseEnter(object sender, EventArgs e)
        {
            interval = 0;
            enableFormControls = true;
        }

        private void lblTitle_MouseEnter(object sender, EventArgs e)
        {

        }

        private void FrmTransactionDisplay_Load(object sender, EventArgs e)
        {
            pnlPay.Left = Width / 2 - pnlPay.Width / 2;
            pnlPay.Top = Height / 2 - pnlPay.Height / 2;

            Form activeForm = Application.OpenForms["FrmTransaction"];
            if (activeForm != null)
            {
                FrmTransaction f = (FrmTransaction)activeForm;
                if (f.frmDisplay == null)
                {
                    f.frmDisplay = this;
                }
            }
        }

        public void pnlPay_DoubleClick(object sender, EventArgs e)
        {
            pnlPay.Visible = false;
            lblTAddress.Visible = false;
            lblAddress.Visible = false;
            lblTDate.Visible = false;
            lblArrivalDate.Visible = false;
            lblTService.Visible = false;
            lblServiceType.Visible = false;
            tlpInfo.Visible = false;

            splitContainer2.Visible = true;
            lblGrandTotal.Visible = false;
            dgvProducts.Columns.Clear();
            lblTitle.Text = "Welcome to Pet Shippers! Want to move or travel somewhere with your lovely pet? Don't worry we got you covered!";
            lblTitle2.Text = lblTitle.Text;

            lblTitle.Left = 40;
            lblTitle.Visible = true;

            lblTitle2.Left = Width;
            lblTitle2.Visible = false;
        }

        private void tmrVisibility_Tick(object sender, EventArgs e)
        {
            pnlPay_DoubleClick(sender, e);
            tmrVisibility.Stop();
        }

        private void pnlPay_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlPay.Visible) tmrVisibility.Start();
        }
    }
}
