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
        private Cow CurrentCow { get; set; }
        private List<Cow> CowData;

        public CowListForm()
        {
            InitializeComponent();
            loadDataSource();
            loadCows();
        }

        private void loadDataSource()
        {
            Repo = new DBRepository();
            CurrentCow = null;
            CowData = Repo.GetCows().ToList();
        }

        private void loadCows()
        {
            if (CowData == null || CowData.Count == 0)
            {
                this.lbCows.Items.Add("No Data");
                return;
            }
            this.lbCows.SelectedIndexChanged += LbCows_SelectedIndexChanged;
            this.lbCows.DataSource = CowData;
        }

        private void LbCows_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lbCows.Items.Count > 0)
            {
                CurrentCow = lbCows.SelectedValue as Cow;
            }
        }

        private void btnUpdateCow_Click(object sender, System.EventArgs e)
        {
            if (CowData == null || CowData.Count == 0)
            {
                MessageBox.Show("No data available.");
                return;
            }
            if (CurrentCow == null)
            {
                MessageBox.Show("Please select a cow to update.");
                return;
            }
            UpdateCowForm updateForm = new UpdateCowForm();
            updateForm.ShowCow(CurrentCow);
            updateForm.Show();
            updateForm.FormClosed += UpdateForm_FormClosed;
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as UpdateCowForm).DidUpdate)
            {
                this.UpdateDisplayData();
            }
        }

        private void UpdateDisplayData()
        {
            CowData = Repo.GetCows().ToList();
            lbCows.DataSource = CowData;
        }
    }
}
