using CowApp.DataAccess.Entities;
using CowApp.DataAccess.Repository;
using CowApp.SubForms;
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
            //cowData = null;
        }

        private void loadCows()
        {
            if (CowData == null || CowData.Count == 0)
            {
                Label lbl = new Label();
                lbl.Text = "No Data.";
                this.lbCows.Controls.Add(lbl);
                return;
            }
            this.lbCows.DataSource = CowData;
            this.lbCows.SelectedIndexChanged += LbCows_SelectedIndexChanged;
            CurrentCow = lbCows.SelectedValue as Cow;
        }

        private void LbCows_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CurrentCow = lbCows.SelectedValue as Cow;
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
        }
    }
}
