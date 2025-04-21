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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Staff s = Staff.ValidateLogin(txtUsername.Text, txtPassword.Text);
                if (s != null)
                {
                    FrmMain f = (FrmMain)this.Owner;
                    f.activeUser = s;

                    MessageBox.Show("Welcome back, " + s.Name +"!", "Login Succesful", MessageBoxButtons.OK);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to DB. Error: " + ex.Message, "Error");
            }
        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowPassword.Checked) txtPassword.PasswordChar = '\0';
            else txtPassword.PasswordChar = '*';
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            foreach(Control c in this.Controls)
            {
                c.KeyDown += new KeyEventHandler(FrmLogin_KeyDown);
                foreach (Control c2 in c.Controls)
                {
                    c2.KeyDown += new KeyEventHandler(FrmLogin_KeyDown);
                }
            }
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
