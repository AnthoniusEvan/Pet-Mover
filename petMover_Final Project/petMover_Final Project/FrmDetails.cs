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
    public partial class FrmDetails : Form
    {
        FrmList frmParent;
        string tag;
        public FrmDetails()
        {
            InitializeComponent();
        }

        private void FrmDetails_Load(object sender, EventArgs e)
        {
            tag = (string)Tag;
            frmParent = (FrmList)this.Owner;
            if (tag == "Branches")
            {
                cbBranchCity.DataSource = City.Get("", "");
                cbBranchCity.DisplayMember = "Name";
                cbBranchCity.ValueMember = "Id";

                if (frmParent.selectedCity != -1)
                    cbBranchCity.SelectedValue = frmParent.selectedCity;
                else cbBranchCity.SelectedIndex = 0;
            }
            else if (tag == "Cage Rates")
            {
                cbCage.DataSource = Cage.Get("", "");
                cbCage.DisplayMember = "Name";
                cbCage.ValueMember = "Id";

                if (frmParent.selectedCage != -1)
                    cbCage.SelectedValue = frmParent.selectedCage;
                else cbCage.SelectedIndex = 0;

                cbServiceType.DataSource = ServiceType.Get("", "");
                cbServiceType.DisplayMember = "Name";
                cbServiceType.ValueMember = "Id";

                if (frmParent.selectedServiceType != -1)
                    cbServiceType.SelectedValue = frmParent.selectedServiceType;
                else cbServiceType.SelectedIndex = 0;
            }
            else if (tag == "Clients")
            {
                cbClientCity.DataSource = City.Get("", "");
                cbClientCity.DisplayMember = "Name";
                cbClientCity.ValueMember = "Id";

                if (frmParent.selectedCity != -1)
                    cbClientCity.SelectedValue = frmParent.selectedCity;
                else cbClientCity.SelectedIndex = 0;
            }
            else if (tag == "Staffs")
            {
                cbStaffBranch.DataSource = Branch.Get("", "");
                cbStaffBranch.DisplayMember = "Name";
                cbStaffBranch.ValueMember = "Id";

                if (frmParent.selectedBranch != -1)
                    cbStaffBranch.SelectedValue = frmParent.selectedBranch;
                else cbStaffBranch.SelectedIndex = 0;
            } 
            else if (tag == "Transport Rates")
            {
                cbCityOrigin.DataSource = City.Get("", "");
                cbCityOrigin.DisplayMember = "Name";
                cbCityOrigin.ValueMember = "Id";

                if (frmParent.selectedCity != -1)
                    cbCityOrigin.SelectedValue = frmParent.selectedCity;
                else cbCityOrigin.SelectedIndex = 0;

                cbCityDestination.DataSource = City.Get("", "");
                cbCityDestination.DisplayMember = "Name";
                cbCityDestination.ValueMember = "Id";

                if (frmParent.selectedCity2 != -1)
                    cbCityDestination.SelectedValue = frmParent.selectedCity2;
                else cbCityDestination.SelectedIndex = 0;

                cbTRServiceType.DataSource = ServiceType.Get("", "");
                cbTRServiceType.DisplayMember = "Name";
                cbTRServiceType.ValueMember = "Id";

                if (frmParent.selectedServiceType != -1)
                    cbTRServiceType.SelectedValue = frmParent.selectedServiceType;
                else cbTRServiceType.SelectedIndex = 0;
            }
            else if (tag == "Transactions")
            {
                // Branch
                cbTransactionBranch.DataSource = Branch.Get("", "");
                cbTransactionBranch.DisplayMember = "Name";
                cbTransactionBranch.ValueMember = "Id";

                if (frmParent.selectedBranch != -1)
                    cbTransactionBranch.SelectedValue = frmParent.selectedBranch;
                else cbTransactionBranch.SelectedIndex = -1;
                

                // Service Type
                cbTransactionService.DataSource = ServiceType.Get("", "");
                cbTransactionService.DisplayMember = "Name";
                cbTransactionService.ValueMember = "Id";

                if (frmParent.selectedServiceType != -1)
                    cbTransactionService.SelectedValue = frmParent.selectedServiceType;
                else cbTransactionService.SelectedIndex = -1;

                // Client 
                cbTransactionClient.DataSource = Client.Get("", "");
                cbTransactionClient.DisplayMember = "Name";
                cbTransactionClient.ValueMember = "Id";

                if (frmParent.selectedClient != -1)
                    cbTransactionClient.SelectedValue = frmParent.selectedClient;
                else cbTransactionClient.SelectedIndex = -1;

                //Staff
                cbTransactionStaff.DataSource = Staff.Get("", "");
                cbTransactionStaff.DisplayMember = "Name";
                cbTransactionStaff.ValueMember = "Id";

                if (frmParent.selectedStaff != "")
                    cbTransactionStaff.SelectedValue = frmParent.selectedStaff;
                else cbTransactionStaff.SelectedIndex = -1;

                //City
                cbTransactionCity.DataSource = City.Get("", "");
                cbTransactionCity.DisplayMember = "Name";
                cbTransactionCity.ValueMember = "Id";

                if (frmParent.selectedCity != -1)
                    cbTransactionCity.SelectedValue = frmParent.selectedCity;
                else cbTransactionCity.SelectedIndex = -1;
            }
            else if (tag.Split()[0] == "Logs")
            {
                cbLogCity.DataSource = City.Get("", "");
                cbLogCity.DisplayMember = "Name";
                cbLogCity.ValueMember = "Id";
                cbLogCity.SelectedIndex = -1;

                cbLogStaff.DataSource = Staff.Get("", "");
                cbLogStaff.DisplayMember = "Name";
                cbLogStaff.ValueMember = "Id";
                cbLogStaff.SelectedIndex = -1;
            }
            else if (tag == "Treatment Rates")
            {
                cbTreatment.DataSource = Treatment.Get("", "");
                cbTreatment.DisplayMember = "Name";
                cbTreatment.ValueMember = "Id";

                if (frmParent.selectedTreatment != -1)
                    cbTreatment.SelectedValue = frmParent.selectedTreatment;
                else cbTreatment.SelectedIndex = 0;

                cbPetType.DataSource = PetType.Get("", "");
                cbPetType.DisplayMember = "Name";
                cbPetType.ValueMember = "Id";

                if (frmParent.selectedPetType != -1)
                    cbPetType.SelectedValue = frmParent.selectedPetType;
                else cbPetType.SelectedIndex = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearInputData()
        {
            if (tag == "Pet Types" || tag == "Service Types" || tag == "Treatments")
            {
                txtId.Text = (int.Parse(txtId.Text) + 1).ToString();
                txtName.Text = "";
                txtName.Focus();
            }
            else if (tag == "Branches")
            {
                txtBranchId.Text = (int.Parse(txtBranchId.Text) + 1).ToString();
                txtBranchName.Text = "";
                txtPhoneNumber.Text = "";
                txtAddress.Text = "";
                txtBranchName.Focus();
            }
            else if (tag == "Cages")
            {
                txtCageId.Text = (int.Parse(txtCageId.Text) + 1).ToString();
                txtCageName.Text = "";
                txtDimensions.Text = "";
                txtCageName.Focus();
            }
            else if (tag == "Cage Rates")
            {
                txtCageRate.Text = "";
                txtCageRate.Focus();
            }
            else if (tag == "Cities")
            {
                txtCityId.Text = (int.Parse(txtCityId.Text) + 1).ToString();
                txtProvince.Text = "";
                txtCityName.Text = "";
                txtCityName.Focus();
            }
            else if (tag == "Clients")
            {
                txtClientId.Text = (int.Parse(txtClientId.Text) + 1).ToString();
                txtClientName.Text = "";
                txtClientAddress.Text = "";
                txtClientPhoneNumber.Text = "";
                txtClientName.Focus();
            }
            else if (tag == "Staffs")
            {
                txtStaffId.Text = (int.Parse(txtStaffId.Text) + 1).ToString();
                txtStaffName.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtStaffName.Focus();
            }
            else if (tag == "Transport Rates")
            {
                txtTRate.Text = "";
                txtTRate.Focus();
            }
            else if (tag == "Transactions")
            {
                cbTransactionCity.SelectedIndex = -1;
                cbTransactionClient.SelectedIndex = -1;
                cbTransactionService.SelectedIndex = -1;
                cbTransactionStaff.SelectedIndex = -1;
                txtTransactionAddress.Text = "";
                txtTransactionAddress.Focus();
            }
            else if (tag.Split()[0] == "Logs")
            {
                cbLogCity.SelectedIndex = -1;
                cbLogStaff.SelectedIndex = -1;
                txtLogDescription.Text = "";
                txtLogDescription.Focus();
            }
            else if (tag == "Treatment Rates")
            {
                cbPetType.SelectedIndex = -1;
                cbTreatment.SelectedIndex = -1;
                txtCageRate.Text = "";
                txtCageRate.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string)Tag == "Cities")
                {
                    City city = new City(int.Parse(txtCityId.Text), txtCityName.Text, txtProvince.Text);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = City.Add(city);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new city!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new city! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = City.Edit(city);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a city!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a city! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Cages")
                {
                    Cage cage = new Cage(int.Parse(txtCageId.Text), txtCageName.Text, txtDimensions.Text);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = Cage.Add(cage);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new cage!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new cage! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = Cage.Edit(cage);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a cage!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a cage! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Pet Types")
                {
                    PetType petType = new PetType(int.Parse(txtId.Text), txtName.Text);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = PetType.Add(petType);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new pet type!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new pet type! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = PetType.Edit(petType);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a pet type!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a pet type! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Service Types")
                {
                    ServiceType serviceType = new ServiceType(int.Parse(txtId.Text), txtName.Text);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = ServiceType.Add(serviceType);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new service type!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new service type! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = ServiceType.Edit(serviceType);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a service type!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a service type! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Treatments")
                {
                    Treatment treatment = new Treatment(int.Parse(txtId.Text), txtName.Text);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = Treatment.Add(treatment);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new treatment!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new treatment! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = Treatment.Edit(treatment);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a treatment!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a treatment! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Branches")
                {
                    City c = new City((int)cbBranchCity.SelectedValue);
                    Branch branch = new Branch(int.Parse(txtBranchId.Text), txtBranchName.Text, txtAddress.Text, txtPhoneNumber.Text, c);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = Branch.Add(branch);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new branch!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new branch! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = Branch.Edit(branch);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a branch!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a branch! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Cage Rates")
                {
                    Cage c = new Cage((int)cbCage.SelectedValue);
                    ServiceType s = new ServiceType((int)cbServiceType.SelectedValue);
                    CageRate cageRate = new CageRate(c,s,int.Parse(txtCageRate.Text));
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = CageRate.Add(cageRate);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new cage rate!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new cage rate! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = CageRate.Edit(cageRate);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a cage rate!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a cage rate! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Clients")
                {
                    City c = new City((int)cbClientCity.SelectedValue);
                    Client client = new Client(int.Parse(txtClientId.Text), txtClientName.Text, txtClientAddress.Text, txtClientPhoneNumber.Text, c);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = Client.Add(client);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new client!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new client! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = Client.Edit(client);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a client!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a client! UNKNOWN ERROR!");
                        }
                    }
                } 
                else if ((string)Tag == "Staffs")
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("The confirm password does not match with with the password!");
                        return;
                    }
                    Branch b = new Branch((int)cbStaffBranch.SelectedValue);
                    Staff staff = new Staff(txtStaffId.Text, txtStaffName.Text, b, txtConfirmPassword.Text);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = Staff.Add(staff);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new staff!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new staff! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        // doesnt work

                        rowsAffected = Staff.Edit(staff);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a staff!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a staff! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Transport Rates")
                {
                    City co = new City((int)cbCityOrigin.SelectedValue);
                    City cd = new City((int)cbCityDestination.SelectedValue);
                    ServiceType s = new ServiceType((int)cbTRServiceType.SelectedValue);
                    TransportRate transportRate = new TransportRate(co, cd, s, int.Parse(txtTRate.Text));
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = TransportRate.Add(transportRate);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new transport rate!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new transport rate! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = TransportRate.Edit(transportRate);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a transport rate!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a transport rate! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Transactions")
                {
                    Branch b = new Branch((int)cbTransactionBranch.SelectedValue);
                    ServiceType st = new ServiceType((int)cbTransactionService.SelectedValue);
                    Client c = new Client((int)cbTransactionClient.SelectedValue);
                    Staff s = new Staff(cbTransactionStaff.SelectedValue.ToString());
                    City ci = new City((int)cbTransactionCity.SelectedValue);
                    Transaction transaction = new Transaction(b, int.Parse(txtTransactionId.Text),dtpTransactionDate.Value,c,s,st,txtTransactionAddress.Text,ci,dtpTransactionExpectedArrival.Value);
                    int rowsAffected;
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
                else if (tag.Split()[0] == "Logs")
                {
                    Branch b = new Branch(int.Parse(tag.Split()[1]));
                    Staff s = new Staff((string)cbLogStaff.SelectedValue);
                    City ci = new City((int)cbLogCity.SelectedValue);
                    TransactionLog tl = new TransactionLog(dtpLogTime.Value, b, int.Parse(tag.Split()[2]), ci, txtLogDescription.Text, s);
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = TransactionLog.Add(tl);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new transaction log!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new transaction log! UNKNOWN ERROR!");
                        }
                    }
                }
                else if ((string)Tag == "Treatment Rates")
                {
                    Treatment t = new Treatment((int)cbTreatment.SelectedValue);
                    PetType p = new PetType((int)cbPetType.SelectedValue);
                    TreatmentRate tr = new TreatmentRate(t, p , int.Parse(txtTreatmentRate.Text));
                    int rowsAffected;
                    if (!frmParent.isEditing)
                    {
                        rowsAffected = TreatmentRate.Add(tr);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully added a new treatment rate!", "Information");
                            frmParent.listCount++;
                            ClearInputData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new treatment rate! UNKNOWN ERROR!");
                        }
                    }
                    else
                    {
                        rowsAffected = TreatmentRate.Edit(tr);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Succesfully updated a treatment rate!", "Information");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update a treatment rate! UNKNOWN ERROR!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((string)Tag == "Cities")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete city " + txtCityName.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    City city = new City(int.Parse(txtCityId.Text), txtCityName.Text, txtProvince.Text);
                    int affectedRows = City.Delete(city);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted city " + txtCityName.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete city " + txtCityName.Text + ".");
                    }
                }
            }
            else if ((string)Tag == "Cages")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete cage " + txtCageName.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Cage cage = new Cage(int.Parse(txtCageId.Text), txtCageName.Text, txtDimensions.Text);
                    int affectedRows = Cage.Delete(cage);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted cage " + txtCageName.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete cage " + txtCageName.Text + ".");
                    }
                }
            }
            else if ((string)Tag == "Pet Types")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the pet type " + txtName.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PetType petType = new PetType(int.Parse(txtId.Text), txtName.Text);
                    int affectedRows = PetType.Delete(petType);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the pet type " + txtName.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the pet type " + txtName.Text + ".");
                    }
                }
            }
            else if ((string)Tag == "Service Types")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the service type " + txtName.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ServiceType serviceType = new ServiceType(int.Parse(txtId.Text), txtName.Text);
                    int affectedRows = ServiceType.Delete(serviceType);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the service type " + txtName.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the service type " + txtName.Text + ".");
                    }
                }
            }
            else if ((string)Tag == "Treatments")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the treatment " + txtName.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Treatment treatment = new Treatment(int.Parse(txtId.Text), txtName.Text);
                    int affectedRows = Treatment.Delete(treatment);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the treatment " + txtName.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the treatment " + txtName.Text + ".");
                    }
                }
            }
            else if ((string)Tag == "Branches")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the branch " + txtBranchName.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    City city = new City((int)cbBranchCity.SelectedValue);
                    Branch branch = new Branch(int.Parse(txtBranchId.Text), txtBranchName.Text,txtAddress.Text,txtPhoneNumber.Text,city);
                    int affectedRows = Branch.Delete(branch);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the branch " + txtBranchName.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the branch " + txtBranchName.Text + ".");
                    }
                }
            }
            else if ((string)Tag == "Cage Rates")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the cage rate for cage " + cbCage.SelectedItem + " and service type " + cbServiceType.SelectedItem , "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Cage c = new Cage((int)cbCage.SelectedValue);
                    ServiceType s = new ServiceType((int)cbServiceType.SelectedValue);
                    CageRate cageRate = new CageRate(c, s, int.Parse(txtCageRate.Text));
                    int affectedRows = CageRate.Delete(cageRate);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the cage rate for cage " + cbCage.SelectedItem + " and service type " + cbServiceType.SelectedItem + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the cage rate for cage " + cbCage.SelectedItem + " and service type " + cbServiceType.SelectedItem + "!");
                    }
                }
            }
            else if ((string)Tag == "Clients")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the client " + txtClientName.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    City city = new City((int)cbClientCity.SelectedValue);
                    Client client = new Client(int.Parse(txtClientId.Text), txtClientName.Text, txtClientAddress.Text, txtClientPhoneNumber.Text, city);
                    int affectedRows = Client.Delete(client);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the client " + txtClientName.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the client " + txtClientName.Text + ".");
                    }
                }
            }
            else if ((string)Tag == "Staffs")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the staff " + txtStaffName.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Branch b = new Branch((int)cbStaffBranch.SelectedValue);
                    Staff staff = new Staff(txtStaffId.Text, txtStaffName.Text, b);
                    int affectedRows = Staff.Delete(staff);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the staff " + txtStaffName.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the staff " + txtStaffName.Text + ".");
                    }
                }
            }
            else if ((string)Tag == "Transport Rates")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the transport rate for city origin " + cbCityOrigin.SelectedItem + ", city destination " + cbCityDestination.SelectedItem + " and service type " + cbTRServiceType.SelectedItem, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    City co = new City((int)cbCityOrigin.SelectedValue);
                    City cd = new City((int)cbCityDestination.SelectedValue);
                    ServiceType s = new ServiceType((int)cbTRServiceType.SelectedValue);
                    TransportRate transportRate = new TransportRate(co, cd, s, int.Parse(txtTRate.Text));
                    int affectedRows = TransportRate.Delete(transportRate);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the transport rate for city origin " + cbCityOrigin.SelectedItem + ", city destination " + cbCityDestination.SelectedItem + " and service type " + cbTRServiceType.SelectedItem + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the transport rate for city origin " + cbCityOrigin.SelectedItem + ", city destination " + cbCityDestination.SelectedItem + " and service type " + cbTRServiceType.SelectedItem + "!");
                    }
                }
            }
            else if ((string)Tag == "Transactions")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the transaction in branch " + cbTransactionBranch.SelectedItem + " with the transaction ID " + txtTransactionId.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Branch b = new Branch((int)cbTransactionBranch.SelectedValue);
                    ServiceType st = new ServiceType((int)cbTransactionService.SelectedValue);
                    Client c = new Client((int)cbTransactionClient.SelectedValue);
                    Staff s = new Staff(cbTransactionStaff.SelectedValue.ToString());
                    City ci = new City((int)cbTransactionCity.SelectedValue);
                    Transaction transaction = new Transaction(b, int.Parse(txtTransactionId.Text), dtpTransactionDate.Value, c, s, st, txtTransactionAddress.Text, ci, dtpTransactionExpectedArrival.Value);
                    int affectedRows = Transaction.Delete(transaction);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the transaction in branch " + cbTransactionBranch.SelectedItem + " with the transaction ID " + txtTransactionId.Text + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the transaction in branch " + cbTransactionBranch.SelectedItem + " with the transaction ID " + txtTransactionId.Text + "!");
                    }
                }
            }
            else if ((string)Tag == "Treatment Rates")
            {
                DialogResult result = MessageBox.Show("Please confirm that you would like to delete the treatment rate for treatment " + cbTreatment.SelectedItem + " and pet type " + cbPetType.SelectedItem, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Treatment c = new Treatment((int)cbTreatment.SelectedValue);
                    PetType s = new PetType((int)cbPetType.SelectedValue);
                    TreatmentRate tr = new TreatmentRate(c, s, int.Parse(txtTreatmentRate.Text));
                    int affectedRows = TreatmentRate.Delete(tr);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Succesfully deleted the treatment rate for treatment " + cbTreatment.SelectedItem + " and pet type " + cbPetType.SelectedItem + "!");
                        btnCancel_Click(sender, e);
                        frmParent.listCount--;
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete the treatment rate for treatment " + cbTreatment.SelectedItem + " and pet type " + cbPetType.SelectedItem + "!");
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowPassword.Checked) txtPassword.PasswordChar = '\0';
            else txtPassword.PasswordChar = '*';
        }

        private void chbShowConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowConfirmPassword.Checked) txtConfirmPassword.PasswordChar = '\0';
            else txtConfirmPassword.PasswordChar = '*';
        }

        private void FrmDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmParent!=null)
                frmParent.btnSearch_Click(sender, e);
        }
    }
}
