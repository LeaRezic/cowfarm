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
        private List<Breed> Breeds { get; set; }
        private int CowID { get; set; }
        public UpdateCowForm()
        {
            InitializeComponent();
            InitDataSource();
            InitDropDowns();
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
                Repo.UpdateCow(this.GetCowData());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while updating cow. {ex.Message}");
            }
            finally
            {
                this.Close();
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
