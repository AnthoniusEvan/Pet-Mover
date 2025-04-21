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
    public partial class FrmTransaction : Form
    {
        FrmList frmParent;
        public FrmTransactionDisplay frmDisplay;
        int petTypeCount = 0;
        public FrmTransaction()
        {
            InitializeComponent();
        }

        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            frmParent = (FrmList)this.Owner;
            lblCashier.Text = frmParent.activeUser.Id + " - " + frmParent.activeUser.Name;

            Form activeForm = Application.OpenForms["FrmTransactionDisplay"];
            if (activeForm != null)
            {
                Owner = activeForm;
                frmDisplay = (FrmTransactionDisplay)this.Owner;
            }
            else
            {
                DialogResult dr = MessageBox.Show("Would you like to open the customer order window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    FrmTransactionDisplay f = new FrmTransactionDisplay();
                    Owner = f;
                    f.Show();
                    frmDisplay = (FrmTransactionDisplay)f;
                }
            }

            // Branch
            cbTransactionBranch.DataSource = Branch.Get("", "");
            cbTransactionBranch.DisplayMember = "Name";
            cbTransactionBranch.ValueMember = "Id";
            cbTransactionBranch.SelectedIndex = -1;


            // Service Type
            cbTransactionService.DataSource = ServiceType.Get("", "");
            cbTransactionService.DisplayMember = "Name";
            cbTransactionService.ValueMember = "Id";
            cbTransactionService.SelectedIndex = -1;

            // Client 
            cbTransactionClient.DataSource = Client.Get("", "");
            cbTransactionClient.DisplayMember = "Name";
            cbTransactionClient.ValueMember = "Id";
            cbTransactionClient.SelectedIndex = -1;

            //City
            cbTransactionCity.DataSource = City.Get("", "");
            cbTransactionCity.DisplayMember = "Name";
            cbTransactionCity.ValueMember = "Id";
            cbTransactionCity.SelectedIndex = -1;

            //Type
            foreach(PetType pet in PetType.Get("", ""))
            {
                cbType.Items.Add(pet.Name);
            }
            cbType.Items.Add("Cage");
            cbType.Items.Add("Treatment");
            cbType.SelectedIndex = -1;
            petTypeCount = PetType.Get("", "").Count;
            
            FormatDataGrid();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTransactionBranch.SelectedIndex != -1 && cbTransactionCity.SelectedIndex != -1 && cbTransactionClient.SelectedIndex != -1 && cbTransactionService.SelectedIndex != -1)
            {
                dtpTransactionExpectedArrival_ValueChanged(sender, e);
                

                if (cbType.SelectedIndex < petTypeCount)
                {
                    cbDescription.Visible = false;
                    txtDescription.Visible = true;
                    txtDescription.Text = "Name: ";
                    txtDescription.SelectionStart = txtDescription.Text.Length;
                    txtDescription.Focus();
                }
                else if (cbType.SelectedIndex == petTypeCount)
                {
                    cbDescription.Visible = true;
                    txtDescription.Visible = false;
                    cbDescription.Focus();
                    cbDescription.DataSource = Cage.Get("", "");
                    cbDescription.DisplayMember = "Name";
                    cbDescription.ValueMember = "Id";
                }
                else if (cbType.SelectedIndex == petTypeCount + 1)
                {
                    cbDescription.Visible = true;
                    txtDescription.Visible = false;
                    cbDescription.Focus();
                    cbDescription.DataSource = TreatmentRate.Get("", "");
                }
                cbDescription.SelectedIndex = -1;
            }
            else
            {
                cbType.SelectedIndex = -1;
                MessageBox.Show("Please fill in the transaction header first!", "Fill out requirements", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cbDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                List<PetType> pet = PetType.Get("Name", cbType.SelectedItem.ToString());
                if (pet.Count > 0)
                {
                    string criteria = Client.Get("Id", cbTransactionClient.SelectedValue.ToString())[0].City.Id + " " + cbTransactionCity.SelectedValue + " " + cbTransactionService.SelectedValue;
                    List<TransportRate> rate = TransportRate.Get("Id", criteria);
                    if (rate.Count < 1)
                    {
                        MessageBox.Show("Unit item not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbType.SelectedIndex = -1;
                        cbDescription.SelectedIndex = -1;
                        txtDescription.Text = "";
                        lblPrice.Text = "";
                        nudQuantity.Value = 0;
                        return;
                    }
                    lblPrice.Text = rate[0].Rate.ToString();
                    nudQuantity.Value = 1;
                    nudQuantity.Focus();
                }
                else
                {
                    MessageBox.Show("Unit item not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbType.SelectedIndex = -1;
                    cbDescription.SelectedIndex = -1;
                    txtDescription.Text = "";
                    lblPrice.Text = "";
                    nudQuantity.Value = 0;
                }
            }
        }

        private void cbDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                
                if (cbType.SelectedIndex == petTypeCount)
                {
                    if (cbDescription.SelectedValue==null)
                    {
                        MessageBox.Show("There is no " + cbType.Text + " called " + cbDescription.Text + "!", "Item not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }    
                    List<Cage> cage = Cage.Get("Id", cbDescription.SelectedValue.ToString());
                    if (cage.Count > 0)
                    {
                        string criteria = cbDescription.SelectedValue + ";" + cbTransactionService.SelectedValue;
                        List<CageRate> rate = CageRate.Get("Id", criteria);
                        lblPrice.Text = rate[0].Rate.ToString();
                        nudQuantity.Value = 1;
                        nudQuantity.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Unit item not Found!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        cbType.SelectedIndex = -1;
                        cbDescription.SelectedIndex = -1;
                        txtDescription.Text = "";
                        lblPrice.Text = "";
                        nudQuantity.Value = 0;
                    }
                }
                else if (cbType.SelectedIndex == petTypeCount + 1)
                {
                    if (cbDescription.SelectedIndex == -1)
                    {
                        MessageBox.Show("There is no " + cbType.Text + " called " + cbDescription.Text + "!", "Item not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TreatmentRate tr = (TreatmentRate)cbDescription.SelectedItem;
                    if (tr != null)
                    {
                        lblPrice.Text = tr.DailyRate.ToString();
                        nudQuantity.Value = 1;
                        nudQuantity.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Unit item not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbType.SelectedIndex = -1;
                        cbDescription.SelectedIndex = -1;
                        txtDescription.Text = "";
                        lblPrice.Text = "";
                        nudQuantity.Value = 0;
                    }
                }
            }
        }

        private void nudQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!int.TryParse(lblPrice.Text, out int price)) return;
                int subtotal = price * (int)nudQuantity.Value;
                int total = int.Parse(lblGrandTotal.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
                total += subtotal;
                lblGrandTotal.Text = total.ToString("C2");

                bool transactionShown = false;
                if (frmDisplay != null) transactionShown = true;

                if (txtDescription.Visible)
                {
                    dgvProducts.Rows.Add(cbType.Text, txtDescription.Text, price.ToString("C2"), nudQuantity.Value, subtotal);
                    if (transactionShown)
                    {
                        frmDisplay.dgvProducts.Rows.Add(cbType.Text, txtDescription.Text, price.ToString("C2"), nudQuantity.Value, subtotal);
                    }
                }
                else
                {
                    dgvProducts.Rows.Add(cbType.Text, cbDescription.Text, price.ToString("C2"), nudQuantity.Value, subtotal);
                    if (transactionShown)
                        frmDisplay.dgvProducts.Rows.Add(cbType.Text, cbDescription.Text, price.ToString("C2"), nudQuantity.Value, subtotal);
                }

                if (transactionShown)
                {
                    frmDisplay.lblGrandTotal.Text = "TOTAL:     " + total.ToString("C2");
                    frmDisplay.lblGrandTotal.Visible = true;
                    if (frmDisplay.lblTitle.Text != "Hi "+cbTransactionClient.Text+"! Here are your orders: ") frmDisplay.lblTitle.Text = "Hi " + cbTransactionClient.Text + "! Here are your orders: ";
                }

                cbType.SelectedIndex = -1;
                cbDescription.SelectedIndex = -1;
                txtDescription.Text = "";
                lblPrice.Text = "";
                nudQuantity.Value = 0;
                if (dgvProducts.Columns.Contains("btnRemove") != true)
                {
                    DataGridViewButtonColumn colRemove = new DataGridViewButtonColumn();
                    colRemove.HeaderText = "Action";
                    colRemove.Text = "Remove";
                    colRemove.Name = "btnRemove";
                    colRemove.UseColumnTextForButtonValue = true;
                    dgvProducts.Columns.Add(colRemove);
                }

                cbType.Focus();
            }
        }

        private void FormatDataGrid()
        {
            dgvProducts.Columns.Clear();
            if (frmDisplay != null) frmDisplay.dgvProducts.Columns.Clear();

                dgvProducts.Columns.Add("Type", "Type");
            dgvProducts.Columns.Add("Description", "Description");
            dgvProducts.Columns.Add("Price", "Unit Price");
            dgvProducts.Columns.Add("Quantity", "Qty");
            dgvProducts.Columns.Add("SubTotal", "Sub Total");

            dgvProducts.Columns["Price"].DefaultCellStyle.Padding = new Padding(22, 0, 2, 0);
            dgvProducts.Columns["Quantity"].DefaultCellStyle.Padding = new Padding(16, 0, 16, 0);
            dgvProducts.Columns["SubTotal"].DefaultCellStyle.Padding = new Padding(22, 0, 2, 0);

            dgvProducts.Columns["Price"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns["Quantity"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns["SubTotal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProducts.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["Quantity"].DefaultCellStyle.Format = "#.###";
            dgvProducts.Columns["SubTotal"].DefaultCellStyle.Format = "C2";

            dgvProducts.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProducts.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProducts.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProducts.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProducts.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
            if (frmDisplay != null)
            {
                foreach (DataGridViewColumn dgvc in dgvProducts.Columns)
                {
                    frmDisplay.dgvProducts.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                }

                frmDisplay.tlpInfo.Visible = true;
                frmDisplay.splitContainer2.Visible = false;
            }

            dgvProducts.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProducts.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProducts.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            dgvProducts.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmParent.btnSearch_Click(sender, e);
            this.Close();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.Columns["btnRemove"]!=null && e.ColumnIndex == dgvProducts.Columns["btnRemove"].Index && e.RowIndex >= 0)
            {
                int total = int.Parse(lblGrandTotal.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
                total -= (int)dgvProducts.Rows[e.RowIndex].Cells["SubTotal"].Value;
                dgvProducts.Rows.RemoveAt(e.RowIndex);
                lblGrandTotal.Text = total.ToString("C2");
                if (frmDisplay != null) 
                {
                    frmDisplay.dgvProducts.Rows.RemoveAt(e.RowIndex);
                    frmDisplay.lblGrandTotal.Text = "TOTAL:     "+ total.ToString("C2");
                }
            }
        }
        Transaction transaction;
        public int amountPaid=0;
        public TaskCompletionSource<bool> tcs = null;
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count < 1)
            {
                MessageBox.Show("Please add atleast one product before recording the transaction!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // object ref
            Branch b = new Branch((int)cbTransactionBranch.SelectedValue);
            ServiceType st = new ServiceType((int)cbTransactionService.SelectedValue);
            Client c = new Client((int)cbTransactionClient.SelectedValue);
            Staff s = new Staff(frmParent.activeUser.Id);
            City ci = new City((int)cbTransactionCity.SelectedValue);

            int id = Transaction.GetUnusedId(b.Id);

            transaction = new Transaction(b, id, dtpTransactionDate.Value, c, s, st, txtTransactionAddress.Text, ci, dtpTransactionExpectedArrival.Value);
            int rowsAffected;
            if (!frmParent.isEditing)
            {
                for (int i = 0; i < dgvProducts.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvProducts.Rows[i];
                    string productCode = row.Cells[0].Value.ToString();
                    string name = row.Cells[1].Value.ToString();
                    string desc = row.Cells["Description"].Value.ToString();
                    int price = int.Parse(row.Cells["Price"].Value.ToString(), NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
                    int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());

                    PetType p = null;
                    Cage ca = null;
                    Treatment t = null;
                    if (productCode == "Cage")
                    {
                        ca = new Cage(Cage.Get("Name", name)[0].Id);
                    }
                    else if (productCode == "Treatment")
                    {
                        t = new Treatment(Treatment.Get("Name", name.Split()[1])[0].Id);
                    }
                    else
                    {
                        p = new PetType(PetType.Get("Name", productCode)[0].Id);
                    }

                    TransactionDetail td = new TransactionDetail(transaction.Id, (Branch)cbTransactionBranch.SelectedItem, p, ca, t, desc, quantity, price);
                    transaction.AddDetail(td);
                }

                if (frmDisplay != null)
                {
                    tcs = new TaskCompletionSource<bool>();

                    FrmPayment f = new FrmPayment();
                    f.Owner = this;
                    f.ShowDialog();

                    await tcs.Task;
                }

                rowsAffected = Transaction.Add(transaction);
                if (rowsAffected > 0)
                {
                    if (frmDisplay != null)
                    {
                        frmDisplay.pnlPay.Visible = true;
                        frmDisplay.lblTotalPay.Text = lblGrandTotal.Text;
                        frmDisplay.lblPay.Text = amountPaid.ToString("C2");
                        frmDisplay.lblChange.Text = (amountPaid - int.Parse(lblGrandTotal.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.Currency)).ToString("C2");
                    }

                    MessageBox.Show("Succesfully added a new transaction!", "Information");
                    frmParent.listCount++;
                    dgvProducts.Rows.Clear();
                    cbTransactionCity.SelectedIndex = -1;
                    txtDescription.Text = "";
                    cbTransactionClient.SelectedIndex = -1;
                    cbTransactionService.SelectedIndex = -1;
                    txtTransactionAddress.Text = "";
                    cbType.SelectedIndex = -1;
                    cbDescription.SelectedIndex = -1;
                    txtDescription.Text = "";
                    lblPrice.Text = "";
                    nudQuantity.Value = 0;
                    lblGrandTotal.Text = "Rp0,00";

                    txtDescription.Focus();
                }
                else
                {
                    MessageBox.Show("Failed to add a transaction! UNKNOWN ERROR!");
                }
            }
            else
            {
                rowsAffected = Transaction.Edit(transaction);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Succesfully updated a transaction!", "Information");
                }
                else
                {
                    MessageBox.Show("Failed to update a transaction! UNKNOWN ERROR!");
                }
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(sender, e);
                if (frmDisplay!=null)
                    await tcs.Task;
                string fileName = "Transaction_" + cbTransactionBranch.Text + "_Id#" + transaction.Id + ".pdf";
                Transaction t = Transaction.Get("Id", cbTransactionBranch.SelectedValue + " " + transaction.Id)[0];

                    Transaction.Print(t, fileName, new Font("Courier New", 12), out string path);

                    MessageBox.Show("Transaction has been printed succesfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void lblPrice_TextChanged(object sender, EventArgs e)
        {
            if (lblPrice.Text == "") nudQuantity.Minimum = 0;
            else nudQuantity.Minimum = 1;
        }

        private void dgvProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void cbTransactionCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTransactionCity.SelectedIndex!=-1 && frmDisplay != null && txtTransactionAddress.Text != "")
            {
                frmDisplay.lblTAddress.Visible = true;
                frmDisplay.lblAddress.Text = txtTransactionAddress.Text + ", " + cbTransactionCity.Text + ", " + ((City)cbTransactionCity.SelectedItem).Province;
                frmDisplay.lblAddress.Visible = true;
            }
        }

        private void cbTransactionService_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dtpTransactionExpectedArrival_ValueChanged(object sender, EventArgs e)
        {
            if (frmDisplay != null)
            {
                frmDisplay.lblTDate.Visible = true;
                frmDisplay.lblArrivalDate.Text = dtpTransactionExpectedArrival.Value.ToLongDateString();
                frmDisplay.lblArrivalDate.Visible = true;
            }
        }

        private void dtpTransactionExpectedArrival_Enter(object sender, EventArgs e)
        {
            dtpTransactionExpectedArrival_ValueChanged(sender, e);
        }

        private void cbTransactionService_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbTransactionService.SelectedIndex != -1 && frmDisplay != null)
            {
                frmDisplay.lblTService.Visible = true;
                frmDisplay.lblServiceType.Text = cbTransactionService.Text;
                frmDisplay.lblServiceType.Visible = true;
            }
        }

        private void cbTransactionClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (frmDisplay!=null)
            {
                frmDisplay.lblTitle.Text = "Hi " + cbTransactionClient.Text + "! Here are your orders: ";
                frmDisplay.lblTitle2.Text = "Hi " + cbTransactionClient.Text + "! Here are your orders: ";
            }
        }

        private void FrmTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmDisplay != null) frmDisplay.pnlPay_DoubleClick(sender, e);
        }

        private void txtTransactionAddress_Leave(object sender, EventArgs e)
        {
            if (frmDisplay != null && txtTransactionAddress.Text != "")
            {
                if (frmDisplay.dgvProducts.ColumnCount < 1)
                    FormatDataGrid();
                frmDisplay.lblTAddress.Visible = true;

                if (cbTransactionCity.SelectedIndex != -1)
                {
                    frmDisplay.lblAddress.Text = txtTransactionAddress.Text + ", " + cbTransactionCity.Text + ", " + ((City)cbTransactionCity.SelectedItem).Province;
                }
                else frmDisplay.lblAddress.Text = txtTransactionAddress.Text;

                frmDisplay.lblAddress.Visible = true;
            }
        }
    }
}
