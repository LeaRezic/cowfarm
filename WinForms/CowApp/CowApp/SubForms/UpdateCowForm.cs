using CowApp.DataAccess.Entities;
using CowApp.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CowApp.SubForms
{
    public partial class UpdateCowForm : Form
    {
        private IRepository Repo;
        private List<Breed> Breeds { get; set; }
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
            MessageBox.Show("Not implemented yet...");
            this.Close();
        }
    }
}
