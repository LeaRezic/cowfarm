using CowApp.DataAccess.Entities;
using CowApp.DataAccess.Repository;
using CowApp.SubForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CowApp
{
    public partial class CowListForm : Form
    {

        private IRepository Repo { get; set; }

        public CowListForm()
        {
            InitializeComponent();
            initializeRepo();
            loadCowList();
        }

        private void initializeRepo()
        {
            Repo = new DBRepository();
        }

        private void loadCowList()
        {
            IEnumerable<Cow> CowData = Repo.GetCows();
            if (CowData == null || CowData.Count() == 0)
            {
                lbCows.Items.Add("No Data");
                return;
            }
            lbCows.DataSource = CowData;
            //lbCows.DisplayMember = "Name";
            //lbCows.ValueMember = "CowID";
        }

        private void btnUpdateCow_Click(object sender, System.EventArgs e)
        {
            object selectedItem = lbCows.SelectedValue;
            if (selectedItem is Cow)
            {
                UpdateCowForm updateForm = new UpdateCowForm();
                updateForm.ShowCow(selectedItem as Cow);
                updateForm.Show();
                updateForm.FormClosed += UpdateForm_FormClosed;
            }
            else
            {
                MessageBox.Show("No data available.");
                return;
            }
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as UpdateCowForm).DidUpdate)
            {
                UpdateCowList();
            }
        }

        private void UpdateCowList()
        {
            lbCows.DataSource = Repo.GetCows();
        }
    }
}
