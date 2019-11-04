using CowApp.DataAccess.Entities;
using CowApp.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CowApp.SubForms
{
    public partial class UpdateCowForm : Form
    {
        private IRepository Repo;
        private ErrorProvider errorProvider;
        private List<Breed> Breeds { get; set; }
        private int CowID { get; set; }
        public bool DidUpdate { get; set; }

        public UpdateCowForm()
        {
            InitializeComponent();
            InitDataSource();
            InitDropDowns();
            InitValidationListeners();
        }

        private void InitValidationListeners()
        {
            errorProvider = new ErrorProvider();
            txtName.Validating += TxtName_Validating;
            dpDob.Validating += DpDob_Validating;
            dpDoA.Validating += DpDoA_Validating;
        }

        private void DpDob_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dpDob.Value > DateTime.Now)
            {
                e.Cancel = true;
                dpDob.Focus();
                errorProvider.SetError(dpDob, "Date of Birth cannot be in the future");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(dpDob, null);
            }
        }

        private void DpDoA_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dpDoA.Value < dpDob.Value)
            {
                e.Cancel = true;
                dpDoA.Focus();
                errorProvider.SetError(dpDoA, "Date of Arrival cannot be before Date of Birth");
            }
            else if (dpDoA.Value > DateTime.Now)
            {
                e.Cancel = true;
                dpDoA.Focus();
                errorProvider.SetError(dpDoA, "Date of Arrival cannot be in the future");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(dpDoA, null);
            }
        }

        private void TxtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider.SetError(txtName, "Name cannot be null");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtName, null);
            }
        }
       
        private void InitDataSource()
        {
            Repo = new DBRepository();
        }

        private void InitDropDowns()
        {
            Breeds = Repo.GetBreeds().ToList();
            ddBreed.DataSource = Breeds;
            ddBreed.DisplayMember = "Name";
            ddBreed.ValueMember = "IDBreed";
        }

        public void ShowCow(Cow cow)
        {
            CowID = cow.IDCow;
            txtName.Text = cow.Name;
            ddBreed.SelectedValue = cow.BreedID;
            dpDob.Value = cow.DateOfBirth;
            mtxtVetId.Text = cow.VeterinaryID;
            dpDoA.Value = cow.DateOfArrival;
            numCalf.Value = cow.CalfCount;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren(ValidationConstraints.Enabled))
                {
                    MessageBox.Show("Please correct your input.");
                }
                else
                {
                    Repo.UpdateCow(GetCowData());
                    DidUpdate = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while updating cow. {ex.Message}");
            }
        }

        private Cow GetCowData()
        {
            Cow updatedCow = new Cow();
            updatedCow.IDCow = CowID;
            updatedCow.Name = txtName.Text;
            updatedCow.BreedID = int.Parse(ddBreed.SelectedValue.ToString());
            updatedCow.DateOfBirth = dpDob.Value;
            updatedCow.DateOfArrival = dpDoA.Value;
            updatedCow.CalfCount = int.Parse(numCalf.Value.ToString());
            updatedCow.VeterinaryID = mtxtVetId.Text;
            return updatedCow;
        }
    }
}
