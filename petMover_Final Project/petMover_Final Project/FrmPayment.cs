using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petMover_Final_Project
{
    public partial class FrmPayment : Form
    {
        FrmTransaction frmParent;
        public FrmPayment()
        {
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            frmParent = (FrmTransaction)this.Owner;
            lblTotal.Text = "TOTAL : " + frmParent.lblGrandTotal.Text;
            nudPay.Value = int.Parse(frmParent.lblGrandTotal.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
            nudPay.Minimum = nudPay.Value;
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            frmParent.amountPaid = (int)nudPay.Value;
            frmParent.tcs?.TrySetResult(true);
            this.Close();
        }

        private void FrmPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
