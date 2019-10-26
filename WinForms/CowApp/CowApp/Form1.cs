using CowApp.DataAccess.Entities;
using CowApp.DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CowApp
{
    public partial class Form1 : Form
    {

        private IRepository Repo { get; set; }

        public Form1()
        {
            InitializeComponent();
            loadDataSource();
            loadCows();
        }

        private void loadDataSource()
        {
            Repo = new DBRepository();
        }

        private void loadCows()
        {
            ListBox lbCows = (ListBox) this.Controls.Find("lbCows", true)[0];
            List<Cow> breeds = Repo.GetCows().ToList();
            breeds.ForEach((b) => addCowToList(lbCows, b));
        }

        private void addCowToList(ListBox lbCows, Cow b)
        {
            Label lbl = new Label();
            lbl.Text = $"Cow: {b.Name}, {b.VeterinaryID}, {b.DateOfBirth}, {b.CalfCount}";
            lbl.Width = 500;
            lbCows.Controls.Add(lbl);
        }
    }
}
