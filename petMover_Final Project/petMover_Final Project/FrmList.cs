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
    public partial class FrmList : Form
    {
        FrmMain mdiParent;
        public Staff activeUser;
        string tag;
        public int listCount = 0, selectedCity = -1, selectedCity2 = -1, selectedCage = -1, selectedServiceType = -1, selectedBranch = -1, selectedClient = -1, selectedTreatment = -1, selectedPetType = -1;
        public string selectedStaff = "";
        public bool isEditing = false;
        List<City> listOfCities = new List<City>();
        List<Cage> listOfCages = new List<Cage>();
        List<PetType> listOfPetTypes = new List<PetType>();
        List<ServiceType> listOfServiceTypes = new List<ServiceType>();
        List<Treatment> listOfTreatments = new List<Treatment>();
        List<Branch> listOfBranches = new List<Branch>();
        List<CageRate> listOfCageRates = new List<CageRate>();
        List<Client> listOfClients = new List<Client>();
        List<Staff> listOfStaffs = new List<Staff>();
        List<TransportRate> listOfTransportRates = new List<TransportRate>();
        List<Transaction> listOfTransactions = new List<Transaction>();
        List<TransactionLog> listOfTransactionLogs = new List<TransactionLog>();
        List<TreatmentRate> listOfTreatmentRates = new List<TreatmentRate>();
        public FrmList()
        {
            InitializeComponent();
        }

        private void FrmList_Load(object sender, EventArgs e)
        {
            mdiParent = (FrmMain)this.MdiParent;
            activeUser = mdiParent.activeUser;
            tag = (string)this.Tag;
            if (tag == "Cities")
            {
                listOfCities = City.Get("", "");
                listCount = listOfCities.Count;
            }
            else if (tag == "Cages")
            {
                listOfCages = Cage.Get("", "");
                listCount = listOfCages.Count;
            }
            else if (tag == "Pet Types")
            {
                listOfPetTypes = PetType.Get("", "");
                listCount = listOfPetTypes.Count;
            }
            else if (tag == "Service Types")
            {
                listOfServiceTypes = ServiceType.Get("", "");
                listCount = listOfServiceTypes.Count;
            }
            else if (tag == "Treatments")
            {
                listOfTreatments = Treatment.Get("", "");
                listCount = listOfTreatments.Count;
            }
            else if (tag == "Branches")
            {
                listOfBranches = Branch.Get("", "");
                listCount = listOfBranches.Count;
            }
            else if (tag == "Cage Rates")
            {
                listOfCageRates = CageRate.Get("", "");
                listCount = listOfCageRates.Count;
            }
            else if (tag == "Clients")
            {
                listOfClients = Client.Get("", "");
                listCount = listOfClients.Count;
            }
            else if (tag == "Staffs")
            {
                listOfStaffs = Staff.Get("", "");
                listCount = listOfStaffs.Count;
            }
            else if (tag == "Transport Rates")
            {
                listOfTransportRates = TransportRate.Get("", "");
                listCount = listOfTransportRates.Count;
            }
            else if (tag == "Transactions")
            {
                listOfTransactions = Transaction.Get("", "");
                listCount = listOfTransactions.Count;
            }
            else if (tag.Split()[1] == "Logs")
            {
                string criteria = tag.Split()[2] + " " + tag.Split()[3];
                listOfTransactionLogs = TransactionLog.Get("any", criteria);
                listCount = listOfTransactionLogs.Count;

                this.Height = Height + lblTransactionInfo.Height;

                lblTransactionInfo.Visible = true;
                lblTransactionInfo.Top = pnlTitle.Bottom + 10;
                lblTransactionInfo.Text = "Transaction ID: " + tag.Split()[3] + "\nBranch: " + Branch.Get("Id", tag.Split()[2])[0].Name;
                pnlSearch.Top = lblTransactionInfo.Bottom + 10;
                btnAdd.Top = lblTransactionInfo.Bottom + 10;
                btnViewAll.Top = lblTransactionInfo.Bottom + 10;
                dgvData.Top = pnlSearch.Bottom + 15;
            }
            else if (tag == "Treatment Rates")
            {
                listOfTreatmentRates = TreatmentRate.Get("", "");
                listCount = listOfTreatmentRates.Count;
            }

            RefreshData();
        }
        private void RefreshData()
        {
            bool allowedEdit = true;
            if (listCount > 0)
            {
                if (tag == "Cities") dgvData.DataSource = listOfCities;
                else if (tag == "Cages") dgvData.DataSource = listOfCages;
                else if (tag == "Pet Types") dgvData.DataSource = listOfPetTypes;
                else if (tag == "Service Types") dgvData.DataSource = listOfServiceTypes;
                else if (tag == "Treatments") dgvData.DataSource = listOfTreatments;
                else if (tag == "Branches") dgvData.DataSource = listOfBranches;
                else if (tag == "Cage Rates") dgvData.DataSource = listOfCageRates;
                else if (tag == "Clients") dgvData.DataSource = listOfClients;
                else if (tag == "Staffs") dgvData.DataSource = listOfStaffs;
                else if (tag == "Transport Rates") dgvData.DataSource = listOfTransportRates;
                else if (tag == "Transactions") dgvData.DataSource = listOfTransactions;
                else if (tag.Split()[1] == "Logs")
                {
                    dgvData.DataSource = listOfTransactionLogs;
                    dgvData.Columns["Branch"].Visible = false;
                    dgvData.Columns["Id"].Visible = false;
                    allowedEdit = false;
                }
                else if (tag == "Treatment Rates") dgvData.DataSource = listOfTreatmentRates;

                if (!dgvData.Columns.Contains("btnEdit") && allowedEdit)
                {
                    DataGridViewButtonColumn colEdit = new DataGridViewButtonColumn();
                    colEdit.HeaderText = "Edit Data";
                    colEdit.Text = "Edit";
                    colEdit.Name = "btnEdit";
                    colEdit.UseColumnTextForButtonValue = true;
                    dgvData.Columns.Add(colEdit);
                    dgvData.Columns["btnEdit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if (tag == "Transactions")
                {
                    if (!dgvData.Columns.Contains("btnViewLogs"))
                    {
                        DataGridViewButtonColumn colLogs = new DataGridViewButtonColumn();
                        colLogs.HeaderText = "View Logs";
                        colLogs.Text = "View";
                        colLogs.Name = "btnViewLogs";
                        colLogs.UseColumnTextForButtonValue = true;
                        dgvData.Columns.Insert(0, colLogs);
                        dgvData.Columns["btnViewLogs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    if (!dgvData.Columns.Contains("btnPrint"))
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.HeaderText = "Print";
                        col.Text = "Print";
                        col.Name = "btnPrint";
                        col.UseColumnTextForButtonValue = true;
                        dgvData.Columns.Add(col);
                        dgvData.Columns["btnPrint"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
            else
            {
                dgvData.DataSource = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditing = false;
            FrmDetails f = new FrmDetails();
            f.Owner = this;
            f.lblTitle.Text = "ADD NEW " + tag.ToUpper();
            f.Text = "Add New " + tag;
            f.Tag = tag;
            if (tag == "Treatments" || tag == "Pet Types" || tag == "Service Types")
            {     
                f.pnlIdName.Visible = true;
                f.pnlIdName.Controls["txtId"].Text = "" + (listCount + 1);
                //f.pnlIdName.Controls["txtName"].Text = "";
                f.pnlIdName.Controls["txtId"].Enabled = true;
                f.pnlIdName.Controls["txtName"].Select();
            }
            else if (tag == "Cages")
            {
                f.pnlCage.Visible = true;
                //f.pnlCage.Controls["txtCageId"].Text = "";
                f.pnlCage.Controls["txtCageId"].Text = "" + (listCount + 1);
                f.pnlCage.Controls["txtCageId"].Enabled = true;
                f.pnlCage.Controls["txtCageName"].Select();
            }
            else if (tag == "Cities")
            {
                f.pnlCity.Visible = true;
                f.pnlCity.Controls["txtCityId"].Enabled = true;
                f.pnlCity.Controls["txtCityId"].Text = (listCount + 1).ToString();
                f.pnlCity.Controls["txtCityName"].Select();
            }
            else if (tag == "Branches")
            {
                f.pnlBranch.Visible = true;
                f.pnlBranch.Controls["txtBranchId"].Enabled = true;
                f.pnlBranch.Controls["txtBranchId"].Text = (listCount + 1).ToString();
                f.pnlBranch.Controls["txtBranchName"].Select();
            }
            else if (tag == "Cage Rates")
            {
                f.pnlCageRate.Visible = true;
                f.pnlCageRate.Controls["cbCage"].Enabled = true;
                f.pnlCageRate.Controls["cbServiceType"].Enabled = true;
                f.pnlCageRate.Controls["txtCageRate"].Select();
            }
            else if (tag == "Clients")
            {
                f.pnlClient.Visible = true;
                f.pnlClient.Controls["txtClientId"].Enabled = true;
                f.pnlClient.Controls["txtClientId"].Text = (listCount + 1).ToString();
                f.pnlClient.Controls["txtClientName"].Select();
            }
            else if (tag == "Staffs")
            {
                f.pnlStaff.Visible = true;
                f.pnlStaff.Controls["txtStaffId"].Enabled = true;
                f.pnlStaff.Controls["txtStaffId"].Text = (listCount + 1).ToString();
                f.pnlStaff.Controls["txtStaffName"].Select();
            }
            else if (tag == "Transport Rates")
            {
                f.pnlTransportRate.Visible = true;
                //f.pnlTransportRate.Controls["txtStaffId"].Enabled = true;
                //f.pnlTransportRate.Controls["txtStaffId"].Text = (listCount + 1).ToString();
                f.pnlTransportRate.Controls["txtTRate"].Select();
            }
            else if (tag == "Transactions")
            {
                Form activeForm = Application.OpenForms["FrmTransaction"];
                if (activeForm == null)
                {
                    FrmTransaction form = new FrmTransaction();
                    form.Owner = this;
                    form.Show();
                }
                else
                {
                    activeForm.Show();
                    activeForm.BringToFront();
                }
            }
            else if (tag.Split()[1] == "Logs")
            {
                f.pnlTransactionLog.Visible = true;
                f.lblTitle.Text = "ADD NEW " + tag.Split()[0].ToUpper() + " " +tag.Split()[1].ToUpper();
                f.Text = "Add New " + tag.Split()[0] + " " + tag.Split()[1];
                f.Tag = tag.Split()[1] +" "+ tag.Split()[2] +" "+ tag.Split()[3];
            }
            else if (tag == "Treatment Rates")
            {
                f.pnlTreatmentRate.Visible = true;
                f.pnlTreatmentRate.Controls["cbTreatment"].Enabled = true;
                f.pnlTreatmentRate.Controls["cbPetType"].Enabled = true;
                f.pnlTreatmentRate.Controls["txtTreatmentRate"].Select();
            }
            if (tag != "Transactions") f.ShowDialog();
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (txtSearch.Text != "") btnViewAll.Visible = true;

            if (tag.Split().Count() > 1 && tag.Split()[1] == "Logs")
            {
                if (txtSearch.Text == "")
                {
                    string criteria = tag.Split()[2] + " " + tag.Split()[3];
                    listOfTransactionLogs = TransactionLog.Get("any", criteria);
                }
                else
                {
                    SearchData(txtSearch.Text);
                }
            }
            else SearchData(txtSearch.Text);

            RefreshData();
        }
        DataGridView initDataSource;
        int formOldHeight = 0;
        private void chbEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEdit.Checked)
            {
                DialogResult dr = MessageBox.Show("CAUTION! Edit directly at your own risk! Not to worry, error in changes will be informed to you without directly updating the central database. To edit the data, double click the cell. There are some cells that will not be editable, these cells represents the identity of each record. Are you sure you would like to edit directly from the table?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.No)
                {
                    chbEdit.Checked = false;
                    return;
                }

                formOldHeight = 0;
                formOldHeight += Height;
                dgvData.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                if (tag.Contains("Logs"))
                {
                    //Height += 100;
                    btnSave.Top += 60;
                }
                btnSave.Visible = true;
                dgvData.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                btnSave.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);

                CopyDataGridView();

                dgvData.ReadOnly = false;

                string id = "";
                if (tag == "Cities")
                {
                    id = "Id";
                }
                else if (tag == "Cages")
                {
                    id = "Id";
                }
                else if (tag == "Pet Types")
                {
                    id = "Id";
                }
                else if (tag == "Service Types")
                {
                    id = "Id";
                }
                else if (tag == "Treatments")
                {
                    id = "Id";
                }
                else if (tag == "Branches")
                {
                    id = "Id";
                }
                else if (tag == "Cage Rates")
                {
                    id = "Cage";
                    dgvData.Columns["ServiceType"].ReadOnly = true;
                }
                else if (tag == "Clients")
                {
                    id = "Id";
                }
                else if (tag == "Staffs")
                {
                    id = "Id";
                    dgvData.Columns["Password"].ReadOnly = true;
                    for (int i = 0; i < dgvData.RowCount; i++)
                    {
                        if (dgvData.Rows[i].Cells["Id"].Value.ToString() != activeUser.Id)
                        {
                            dgvData.Rows[i].Cells["Name"].ReadOnly = true;
                            dgvData.Rows[i].Cells["Branch"].ReadOnly = true;
                        }
                    }
                }
                else if (tag == "Transport Rates")
                {
                    id = "CityOrigin";
                    dgvData.Columns["CityDestination"].ReadOnly = true;
                    dgvData.Columns["ServiceType"].ReadOnly = true;
                }
                else if (tag == "Transactions")
                {
                    id = "Id";
                    dgvData.Columns["Branch"].ReadOnly = true;
                }
                else if (tag.Split()[1] == "Logs")
                {
                    id = "LogTime";
                    //Height += 100;
                    //btnSave.Top += 60;
                    
                }
                else if (tag == "Treatment Rates")
                {
                    id = "Treatment";
                    dgvData.Columns["PetType"].ReadOnly = true;
                }
                if (dgvData.Columns[id] != null)
                    dgvData.Columns[id].ReadOnly = true;
            }
            else
            {
                dgvData.ReadOnly = true;
                dgvData.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                btnSave.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                // bugs if clicked on maximized

                btnSave.Visible = false;
                Height = formOldHeight;
                dgvData.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                if (tag.Split()[1] == "Logs")
                {
                    //Height += 100;
                    btnSave.Top -= 60;
                }
            }
        }

        private void FrmList_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = new DialogResult();
            
            if (initDataSource!=null)
            {
                bool isNotChanged = true;
                for (int i = 0; i < initDataSource.ColumnCount; i++)
                {
                    for (int j = 0; j < initDataSource.RowCount; j++)
                    {
                        if (dgvData.Columns[i].Name == "Password")
                            continue;

                        if (!initDataSource.Rows[j].Cells[i].Value.Equals(dgvData.Rows[j].Cells[i].Value))
                        {
                            isNotChanged = false;
                            break;
                        }
                    }
                    if (!isNotChanged) break;
                }

                if (!isNotChanged)
                {
                    res = MessageBox.Show("You have unsaved changes! Would you like to save your changes before exiting?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }

            if (res == DialogResult.Yes)
            {
                e.Cancel = true;
                btnSave_Click(sender, e);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbItems.Visible)
                {
                    int col = int.Parse(cbItems.Tag.ToString().Split(';')[0]);
                    int row = int.Parse(cbItems.Tag.ToString().Split(';')[1]);
                    if (dgvData.Rows[row].Cells[col].Value.ToString() != cbItems.Text)
                    {
                        dgvData.Rows[row].Cells[col].Value = cbItems.SelectedItem;
                    }
                    cbItems.Visible = false;
                }

                if (initDataSource != null)
                {
                    bool isNotChanged = true;
                    for (int i = 0; i < initDataSource.ColumnCount; i++)
                    {
                        for (int j = 0; j < initDataSource.RowCount; j++)
                        {
                            if (dgvData.Rows[j].Cells[i].Value == null) continue;

                            if (!initDataSource.Rows[j].Cells[i].Value.Equals(dgvData.Rows[j].Cells[i].Value))
                            {
                                isNotChanged = false;
                                break;
                            }
                        }
                        if (!isNotChanged) break;
                    }

                    if (isNotChanged)
                    {
                        return;
                    }
                }
                int rowsAffected = 0;
                if (tag == "Cities")
                {
                    foreach (int row in rowIndices)
                    {
                        City c = (City)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = City.Edit(c);
                    }
                }
                else if (tag == "Cages")
                {
                    foreach (int row in rowIndices)
                    {
                        Cage c = (Cage)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = Cage.Edit(c);
                    }
                }
                else if (tag == "Pet Types")
                {
                    foreach (int row in rowIndices)
                    {
                        PetType c = (PetType)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = PetType.Edit(c);
                    }
                }
                else if (tag == "Service Types")
                {
                    foreach (int row in rowIndices)
                    {
                        ServiceType c = (ServiceType)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = ServiceType.Edit(c);
                    }
                }
                else if (tag == "Treatments")
                {
                    foreach (int row in rowIndices)
                    {
                        Treatment c = (Treatment)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = Treatment.Edit(c);
                    }
                }
                else if (tag == "Branches")
                {
                    foreach (int row in rowIndices)
                    {
                        Branch c = (Branch)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = Branch.Edit(c);
                    }
                }
                else if (tag == "Cage Rates")
                {
                    foreach (int row in rowIndices)
                    {
                        CageRate c = (CageRate)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = CageRate.Edit(c);
                    }
                }
                else if (tag == "Clients")
                {
                    foreach (int row in rowIndices)
                    {
                        Client c = (Client)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = Client.Edit(c);
                    }
                }
                else if (tag == "Staffs")
                {
                    foreach (int row in rowIndices)
                    {
                        Staff c = (Staff)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = Staff.Edit(c);
                    }
                }
                else if (tag == "Transport Rates")
                {
                    foreach (int row in rowIndices)
                    {
                        TreatmentRate c = (TreatmentRate)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = TreatmentRate.Edit(c);
                    }
                }
                else if (tag == "Transactions")
                {
                    foreach (int row in rowIndices)
                    {
                        Transaction c = (Transaction)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = Transaction.Edit(c);
                    }
                }
                else if (tag.Split()[1] == "Logs")
                {
                    foreach (int row in rowIndices)
                    {
                        TransactionLog c = (TransactionLog)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = TransactionLog.Edit(c);
                    }
                }
                else if (tag == "Treatment Rates")
                {
                    foreach (int row in rowIndices)
                    {
                        TreatmentRate c = (TreatmentRate)dgvData.Rows[row].DataBoundItem;
                        rowsAffected = TreatmentRate.Edit(c);
                    }
                }

                if (rowsAffected > 0)
                    MessageBox.Show("Succesfully saved all changes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Unknown error! Could not save changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CopyDataGridView();
                rowIndices.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }
        List<int> rowIndices = new List<int>();
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!rowIndices.Contains(e.RowIndex))
                rowIndices.Add(e.RowIndex);
            
            /*string id = "";
            if (tag == "Cities")
            {
                id = "Id";
            }
            else if (tag == "Cages")
            {
                id = "Id";
            }
            else if (tag == "Pet Types")
            {
                id = "Id";
            }
            else if (tag == "Service Types")
            {
                id = "Id";
            }
            else if (tag == "Treatments")
            {
                id = "Id";
            }
            else if (tag == "Branches")
            {
                id = "Id";
            }
            else if (tag == "Cage Rates")
            {
                id = "Cage";
                dgvData.Columns["ServiceType"].ReadOnly = true;
            }
            else if (tag == "Clients")
            {
                id = "Id";
            }
            else if (tag == "Staffs")
            {
                id = "Id";
                dgvData.Columns["Password"].ReadOnly = true;
            }
            else if (tag == "Transport Rates")
            {
                id = "CityOrigin";
                dgvData.Columns["CityDestination"].ReadOnly = true;
                dgvData.Columns["ServiceType"].ReadOnly = true;
            }
            else if (tag == "Transactions")
            {
                id = "Id";
                dgvData.Columns["Branch"].ReadOnly = true;
            }
            else if (tag.Split()[1] == "Logs")
            {
                return;
            }
            else if (tag == "Treatment Rates")
            {
                id = "Treatment";
                dgvData.Columns["PetType"].ReadOnly = true;
            }*/
        }
        private void CopyDataGridView()
        {
            initDataSource = new DataGridView();
            foreach (DataGridViewColumn dgvc in dgvData.Columns)
            {
                initDataSource.Columns.Add(dgvc.Clone() as DataGridViewColumn);
            }

            DataGridViewRow row = new DataGridViewRow();

            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                row = (DataGridViewRow)dgvData.Rows[i].Clone();
                int intColIndex = 0;
                foreach (DataGridViewCell cell in dgvData.Rows[i].Cells)
                {
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }
                initDataSource.Rows.Add(row);
            }
            initDataSource.AllowUserToAddRows = false;
            initDataSource.Refresh();
        }

        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string name = dgvData.Columns[e.ColumnIndex].Name;

            if (tag == "Branches")
            {
                if (name == "City")
                {
                    string cbTag = e.ColumnIndex + ";" + e.RowIndex;
                    cbItems.Tag = cbTag;
                    UseComboBoxToEdit(e);

                    cbItems.DataSource = City.Get("", "");
                    cbItems.DisplayMember = "Name";
                    cbItems.ValueMember = "Id";

                    for (int i = 0; i < cbItems.Items.Count; i++)
                    {
                        cbItems.SelectedIndex = i;
                        if (dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && cbItems.Text == dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        {
                            break;
                        }
                    }

                    cbItems.Select();
                }
            }
            else if (tag == "Clients")
            {
                if (name == "City")
                {
                    string cbTag = e.ColumnIndex + ";" + e.RowIndex;
                    cbItems.Tag = cbTag;
                    UseComboBoxToEdit(e);

                    cbItems.DataSource = City.Get("", "");
                    cbItems.DisplayMember = "Name";
                    cbItems.ValueMember = "Id";

                    for (int i = 0; i < cbItems.Items.Count; i++)
                    {
                        cbItems.SelectedIndex = i;
                        if (dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && cbItems.Text == dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        {
                            break;
                        }
                    }

                    cbItems.Select();
                }
            }
            else if (tag == "Staffs")
            {
                if (name == "Branch")
                {
                    string cbTag = e.ColumnIndex + ";" + e.RowIndex;
                    cbItems.Tag = cbTag;
                    UseComboBoxToEdit(e);

                    cbItems.DataSource = Branch.Get("", "");
                    cbItems.DisplayMember = "Name";
                    cbItems.ValueMember = "Id";

                    for (int i = 0; i < cbItems.Items.Count; i++)
                    {
                        cbItems.SelectedIndex = i;
                        if (dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && cbItems.Text == dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        {
                            break;
                        }
                    }

                    cbItems.Select();
                }
            }
            else if (tag == "Transactions")
            {
                if (name == "CreatedBy" || name == "Client" || name == "Service" || name == "DestinationCity")
                {
                    string cbTag = e.ColumnIndex + ";" + e.RowIndex;
                    cbItems.Tag = cbTag;
                    UseComboBoxToEdit(e);

                    if (name == "CreatedBy")
                    {
                        cbItems.DataSource = Staff.Get("", "");
                        cbItems.DisplayMember = "Name";
                        cbItems.ValueMember = "Id";
                    }
                    else if (name == "Client")
                    {
                        cbItems.DataSource = Client.Get("", "");
                        cbItems.DisplayMember = "Name";
                        cbItems.ValueMember = "Id";
                    }
                    else if (name == "Service")
                    {
                        cbItems.DataSource = ServiceType.Get("", "");
                        cbItems.DisplayMember = "Name";
                        cbItems.ValueMember = "Id";
                    }
                    else if (name == "DestinationCity")
                    {
                        cbItems.DataSource = City.Get("", "");
                        cbItems.DisplayMember = "Name";
                        cbItems.ValueMember = "Id";
                    }

                    for (int i = 0; i < cbItems.Items.Count;i++)
                    {
                        cbItems.SelectedIndex = i;
                        if (dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null && cbItems.Text == dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        {
                            break;
                        }
                    }

                    cbItems.Select();
                }
                else if (name == "ExpectedArrival" || name == "TransactionDate")
                {
                    string dtpTag = e.ColumnIndex + ";" + e.RowIndex;
                    dtpHelper.Tag = dtpTag;
                    UseDateTimePickerToEdit(e);

                    dtpHelper.Focus();
                }
            }
            else if (tag.Contains(' ') && tag.Split()[1] == "Logs")
            {
                if (name == "Staff" || name == "City")
                {
                    string cbTag = e.ColumnIndex + ";" + e.RowIndex;
                    cbItems.Tag = cbTag;
                    UseComboBoxToEdit(e);

                    if (name == "Staff")
                    {
                        cbItems.DataSource = Staff.Get("", "");
                        cbItems.DisplayMember = "Name";
                        cbItems.ValueMember = "Id";
                    }
                    else if (name == "City")
                    {
                        cbItems.DataSource = City.Get("", "");
                        cbItems.DisplayMember = "Name";
                        cbItems.ValueMember = "Id";
                    }

                    for (int i = 0; i < cbItems.Items.Count; i++)
                    {
                        cbItems.SelectedIndex = i;
                        if (dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && cbItems.Text == dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        {
                            break;
                        }
                    }

                    cbItems.Select();
                }
            }
        }
        private void UseComboBoxToEdit(DataGridViewCellCancelEventArgs e)
        {
            cbItems.Size = dgvData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;
            cbItems.Location = PointToClient(dgvData.PointToScreen(dgvData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location));
            cbItems.Visible = true;
        }
        private void UseDateTimePickerToEdit(DataGridViewCellCancelEventArgs e)
        {
            dtpHelper.Size = dgvData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;
            dtpHelper.Location = PointToClient(dgvData.PointToScreen(dgvData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location));
            dtpHelper.Visible = true;
            dtpHelper.Value = (DateTime)dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
        private void dgvData_SizeChanged(object sender, EventArgs e)
        {
            if (cbItems.Visible)
            {
                int col = int.Parse(cbItems.Tag.ToString().Split(';')[0]);
                int row = int.Parse(cbItems.Tag.ToString().Split(';')[1]);
                cbItems.Size = dgvData.GetCellDisplayRectangle(col,row, false).Size;
                cbItems.Location = PointToClient(dgvData.PointToScreen(dgvData.GetCellDisplayRectangle(col,row, false).Location));
            }
            if (dtpHelper.Visible)
            {
                int col = int.Parse(dtpHelper.Tag.ToString().Split(';')[0]);
                int row = int.Parse(dtpHelper.Tag.ToString().Split(';')[1]);
                dtpHelper.Size = dgvData.GetCellDisplayRectangle(col, row, false).Size;
                dtpHelper.Location = PointToClient(dgvData.PointToScreen(dgvData.GetCellDisplayRectangle(col, row, false).Location));
            }
        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cbItems.Tag != null && (e.ColumnIndex.ToString() != cbItems.Tag.ToString().Split()[0] || e.RowIndex.ToString() != cbItems.Tag.ToString().Split()[1]))
            {
                int col = int.Parse(cbItems.Tag.ToString().Split(';')[0]);
                int row = int.Parse(cbItems.Tag.ToString().Split(';')[1]);
                if (dgvData.RowCount > row && dgvData.Rows[row].Cells[col].Value.ToString() != cbItems.Text)
                {
                    dgvData.Rows[row].Cells[col].Value = cbItems.SelectedItem;
                }
                cbItems.Visible = false;
            }
            if (dtpHelper.Tag != null && (e.ColumnIndex.ToString() != dtpHelper.Tag.ToString().Split()[0] || e.RowIndex.ToString() != dtpHelper.Tag.ToString().Split()[1]))
            {
                dtpHelper.Visible = false;
            }
        }

        private void cbItems_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpHelper_ValueChanged(object sender, EventArgs e)
        {
            int col = int.Parse(dtpHelper.Tag.ToString().Split(';')[0]);
            int row = int.Parse(dtpHelper.Tag.ToString().Split(';')[1]);
            dgvData.Rows[row].Cells[col].Value = dtpHelper.Value;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void SearchData(string searchValue)
        {
            if (tag == "Cities") listOfCities = City.Get("any", searchValue);
            else if (tag == "Cages") listOfCages = Cage.Get("any", searchValue);
            else if (tag == "Pet Types") listOfPetTypes = PetType.Get("any", searchValue);
            else if (tag == "Service Types") listOfServiceTypes = ServiceType.Get("any", searchValue);
            else if (tag == "Treatments") listOfTreatments = Treatment.Get("any", searchValue);
            else if (tag == "Branches") listOfBranches = Branch.Get("any", searchValue);
            else if (tag == "Cage Rates") listOfCageRates = CageRate.Get("any", searchValue);
            else if (tag == "Clients") listOfClients = Client.Get("any", searchValue);
            else if (tag == "Staffs") listOfStaffs = Staff.Get("any", searchValue);
            else if (tag == "Transport Rates") listOfTransportRates = TransportRate.Get("any", searchValue);
            else if (tag == "Transactions") listOfTransactions = Transaction.Get("any", searchValue);
            else if (tag.Split()[1] == "Logs") 
            {
                searchValue = tag.Split()[2] + " " + tag.Split()[3] + " " + searchValue;
                listOfTransactionLogs = TransactionLog.Get("search", searchValue);
            }
            else if (tag == "Treatment Rates") listOfTreatmentRates = TreatmentRate.Get("any", searchValue);
        }

        private void pnlBgBtnSearch_MouseEnter(object sender, EventArgs e)
        {
            pnlBgBtnSearch.BackColor = Color.Orange;
        }

        private void pnlBgBtnSearch_MouseLeave(object sender, EventArgs e)
        {
            pnlBgBtnSearch.BackColor = Color.Coral;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            pnlBgBtnSearch.BackColor = Color.Orange;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns["btnEdit"] != null && e.ColumnIndex == dgvData.Columns["btnEdit"].Index && e.RowIndex!=-1)
            {
                string selectedCode="";
                if (tag != "Cage Rates" && tag != "Transport Rates" && tag != "Transactions" && tag != "Treatment Rates")
                    selectedCode = dgvData.CurrentRow.Cells["Id"].Value.ToString();
                isEditing = true;
                FrmDetails f = new FrmDetails();
                f.Owner = this;
                f.lblTitle.Text = "EDIT " + tag.ToUpper();
                f.Text = "Edit " + tag;
                f.Tag = tag;
                f.btnDelete.Visible = true;

                if (tag == "Cities")
                {
                    City city = City.GetByCode(selectedCode);

                    if (city != null)
                    {
                        f.pnlCity.Visible = true;
                        f.pnlCity.Controls["txtCityId"].Enabled = false;

                        f.pnlCity.Controls["txtCityId"].Text = city.Id.ToString();
                        f.pnlCity.Controls["txtCityName"].Text = city.Name;
                        f.pnlCity.Controls["txtProvince"].Text = city.Province;
                        f.pnlCity.Controls["txtCityName"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Cages")
                {
                    Cage cage = Cage.GetByCode(selectedCode);

                    if (cage != null)
                    {
                        f.pnlCage.Visible = true;
                        f.pnlCage.Controls["txtCageId"].Enabled = false;

                        f.pnlCage.Controls["txtCageId"].Text = cage.Id.ToString();
                        f.pnlCage.Controls["txtCageName"].Text = cage.Name;
                        f.pnlCage.Controls["txtDimensions"].Text = cage.Dimensions;
                        f.pnlCage.Controls["txtCageName"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Pet Types")
                {
                    PetType petType = PetType.GetByCode(selectedCode);

                    if (petType != null)
                    {
                        f.pnlIdName.Visible = true;
                        f.pnlIdName.Controls["txtId"].Enabled = false;

                        f.pnlIdName.Controls["txtId"].Text = petType.Id.ToString();
                        f.pnlIdName.Controls["txtName"].Text = petType.Name;
                        f.pnlIdName.Controls["txtName"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Service Types")
                {
                    ServiceType serviceType = ServiceType.GetByCode(selectedCode);

                    if (serviceType != null)
                    {
                        f.pnlIdName.Visible = true;
                        f.pnlIdName.Controls["txtId"].Enabled = false;

                        f.pnlIdName.Controls["txtId"].Text = serviceType.Id.ToString();
                        f.pnlIdName.Controls["txtName"].Text = serviceType.Name;
                        f.pnlIdName.Controls["txtName"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Treatments")
                {
                    Treatment treatment = Treatment.GetByCode(selectedCode);

                    if (treatment != null)
                    {
                        f.pnlIdName.Visible = true;
                        f.pnlIdName.Controls["txtId"].Enabled = false;

                        f.pnlIdName.Controls["txtId"].Text = treatment.Id.ToString();
                        f.pnlIdName.Controls["txtName"].Text = treatment.Name;
                        f.pnlIdName.Controls["txtName"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Branches")
                {
                    Branch branch = Branch.GetByCode(selectedCode);

                    if (branch != null)
                    {
                        selectedCity = branch.City.Id;

                        f.pnlBranch.Visible = true;
                        f.pnlBranch.Controls["txtBranchId"].Enabled = false;

                        f.pnlBranch.Controls["txtBranchId"].Text = branch.Id.ToString();
                        f.pnlBranch.Controls["txtBranchName"].Text = branch.Name;
                        f.pnlBranch.Controls["txtAddress"].Text = branch.Address;
                        f.pnlBranch.Controls["txtPhoneNumber"].Text = branch.PhoneNumber;
                        f.pnlBranch.Controls["txtBranchName"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Cage Rates")
                {
                    selectedCode = dgvData.CurrentRow.Cells["Cage"].Value.ToString();
                    string selectedCode2 = dgvData.CurrentRow.Cells["ServiceType"].Value.ToString();
                    // Not reliable if there is multiple cage/service type with the same name
                    foreach (CageRate c in listOfCageRates)
                    {
                        if (c.Cage.Name == selectedCode && c.ServiceType.Name == selectedCode2)
                        {
                            selectedCode = c.Cage.Id + " " + c.ServiceType.Id;
                            break;
                        }
                    }
                    CageRate cageRate = CageRate.GetByCode(selectedCode);

                    if (cageRate != null)
                    {
                        selectedCage = cageRate.Cage.Id;
                        selectedServiceType = cageRate.ServiceType.Id;

                        f.pnlCageRate.Visible = true;
                        f.pnlCageRate.Controls["cbCage"].Enabled = false;
                        f.pnlCageRate.Controls["cbServiceType"].Enabled = false;
                        f.pnlCageRate.Controls["txtCageRate"].Text = cageRate.Rate.ToString();
                        f.pnlCageRate.Controls["txtCageRate"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Clients")
                {
                    Client client = Client.GetByCode(selectedCode);

                    if (client != null)
                    {
                        selectedCity = client.City.Id;

                        f.pnlClient.Visible = true;
                        f.pnlClient.Controls["txtClientId"].Enabled = false;

                        f.pnlClient.Controls["txtClientId"].Text = client.Id.ToString();
                        f.pnlClient.Controls["txtClientName"].Text = client.Name;
                        f.pnlClient.Controls["txtClientAddress"].Text = client.Address;
                        f.pnlClient.Controls["txtClientPhoneNumber"].Text = client.PhoneNumber;
                        f.pnlClient.Controls["txtClientName"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Staffs")
                {
                    if (dgvData.Rows[e.RowIndex].Cells["Id"].Value.ToString() != activeUser.Id)
                    {
                        MessageBox.Show("You can not edit other staff's account! If you insist, please sign-in to the account which you would like to modify!", "Forbidden Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Staff staff = Staff.GetByCode(selectedCode);

                    if (staff != null)
                    {
                        selectedBranch = staff.Branch.Id;

                        f.pnlStaff.Visible = true;
                        f.pnlStaff.Controls["txtStaffId"].Enabled = false;

                        f.pnlStaff.Controls["txtStaffId"].Text = staff.Id.ToString();
                        f.pnlStaff.Controls["txtStaffName"].Text = staff.Name;
                        f.pnlStaff.Controls["txtStaffName"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Transport Rates")
                {
                    selectedCode = dgvData.CurrentRow.Cells["CityOrigin"].Value.ToString();
                    string selectedCode2 = dgvData.CurrentRow.Cells["CityDestination"].Value.ToString();
                    string selectedCode3 = dgvData.CurrentRow.Cells["ServiceType"].Value.ToString();
                    foreach (TransportRate c in listOfTransportRates)
                    {
                        if (c.CityOrigin.Name == selectedCode && c.CityDestination.Name == selectedCode2 && c.ServiceType.Name == selectedCode3)
                        {
                            selectedCode = c.CityOrigin.Id + " " + c.CityDestination.Id + " " + c.ServiceType.Id;
                            break;
                        }
                    }
                    TransportRate transportRate = TransportRate.GetByCode(selectedCode);

                    if (transportRate != null)
                    {
                        selectedCity = transportRate.CityOrigin.Id;
                        selectedCity2 = transportRate.CityDestination.Id;
                        selectedServiceType = transportRate.ServiceType.Id;

                        f.pnlTransportRate.Visible = true;
                        f.pnlTransportRate.Controls["cbCityOrigin"].Enabled = false;
                        f.pnlTransportRate.Controls["cbCityDestination"].Enabled = false;
                        f.pnlTransportRate.Controls["cbTRServiceType"].Enabled = false;
                        f.pnlTransportRate.Controls["txtTRate"].Text = transportRate.Rate.ToString();
                        f.pnlTransportRate.Controls["txtTRate"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Transactions")
                {
                    selectedCode = dgvData.CurrentRow.Cells["Id"].Value.ToString();
                    string selectedCode2 = dgvData.CurrentRow.Cells["Branch"].Value.ToString();
                    // Not reliable if there is multiple cage/service type with the same name
                    foreach (Transaction c in listOfTransactions)
                    {
                        if (c.Id.ToString() == selectedCode && c.Branch.Name == selectedCode2)
                        {
                            selectedCode = c.Branch.Id + " " + c.Id;
                            break;
                        }
                    }
                    Transaction transaction = Transaction.GetByCode(selectedCode);

                    if (transaction != null)
                    {
                        selectedBranch = transaction.Branch.Id;
                        selectedServiceType = transaction.Service.Id;
                        selectedClient = transaction.Client.Id;
                        selectedStaff = transaction.CreatedBy.Id;
                        selectedCity = transaction.DestinationCity.Id;
                        f.pnlTransaction.Visible = true;
                        f.pnlTransaction.Controls["cbTransactionBranch"].Enabled = false;
                        f.pnlTransaction.Controls["txtTransactionId"].Enabled = false;
                        f.pnlTransaction.Controls["txtTransactionId"].Text = selectedCode.Split()[1];
                        f.dtpTransactionDate.Value = transaction.TransactionDate;
                        f.pnlTransaction.Controls["txtTransactionAddress"].Text = transaction.DestinationAddress;
                        f.pnlTransaction.Controls["txtTransactionAddress"].Focus();

                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
                else if (tag == "Treatment Rates")
                {
                    selectedCode = dgvData.CurrentRow.Cells["Treatment"].Value.ToString();
                    string selectedCode2 = dgvData.CurrentRow.Cells["PetType"].Value.ToString();
                    // Not reliable if there is multiple cage/service type with the same name
                    foreach (TreatmentRate c in listOfTreatmentRates)
                    {
                        if (c.Treatment.Name == selectedCode && c.PetType.Name == selectedCode2)
                        {
                            selectedCode = c.Treatment.Id + " " + c.PetType.Id;
                            break;
                        }
                    }
                    TreatmentRate treatmentRate = TreatmentRate.GetByCode(selectedCode);

                    if (treatmentRate != null)
                    {
                        selectedTreatment = treatmentRate.Treatment.Id;
                        selectedPetType = treatmentRate.PetType.Id;

                        f.pnlTreatmentRate.Visible = true;
                        f.pnlTreatmentRate.Controls["cbTreatment"].Enabled = false;
                        f.pnlTreatmentRate.Controls["cbPetType"].Enabled = false;
                        f.pnlTreatmentRate.Controls["txtTreatmentRate"].Text = treatmentRate.DailyRate.ToString();
                        f.pnlTreatmentRate.Controls["txtTreatmentRate"].Select();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ooops, something went wrong!");
                    }
                }
            }
            else if (dgvData.Columns["btnViewLogs"] != null && e.ColumnIndex == dgvData.Columns["btnViewLogs"].Index && e.RowIndex != -1)
            {
                mdiParent.title = "Transaction Logs";
                int branchId = Branch.Get("Name", dgvData.Rows[e.RowIndex].Cells["Branch"].Value.ToString())[0].Id;
                int transactionId = (int)dgvData.Rows[e.RowIndex].Cells["Id"].Value;
                mdiParent.transactionId = branchId + " " + transactionId;
                mdiParent.OpenMdiChildForm();
            }
            else if (dgvData.Columns["btnPrint"] != null && e.ColumnIndex == dgvData.Columns["btnPrint"].Index && e.RowIndex >= 0)
            {
                string selectedCode = dgvData.CurrentRow.Cells["Id"].Value.ToString();
                string selectedBranch = dgvData.CurrentRow.Cells["Branch"].Value.ToString();
                string fileName = "Transaction_" + selectedBranch + "_Id#" + selectedCode + ".pdf";
                //int branchId = Branch.Get("Name", dgvData.Rows[e.RowIndex].Cells["Branch"].Value.ToString())[0].Id;
                Branch b = (Branch)dgvData.Rows[e.RowIndex].Cells["Branch"].Value;

                bool res = Transaction.Print("Id", b.Id + " " + dgvData.Rows[e.RowIndex].Cells["Id"].Value, fileName, new Font("Courier New", 12), out string path);

                if (res)
                {
                    DialogResult dr = MessageBox.Show("Transaction has been printed succesfully! Would you like to view the report?", "Print Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                }
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            btnViewAll.Visible = false;
            txtSearch.Text = "";
            btnSearch_Click(sender, e);
            RefreshData();
        }
    }
}
