using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PineSpringsPotteryDatabase
{
    public partial class MainMenu : Form
    {
        private CustomerInformation customerInfoForm;
        private NewOrder newOrderForm;
        private NewShow newShowForm;
        private Search newSearchForm;
       // private OrderConformation newComformationForm;
        private Generate_Reports newGenerateReports;
        private Catalog catalog;
        private AddExpense expense;
        private BrowseListing listings;

        public MainMenu()
        {
            InitializeComponent();
        }

        // this is acutallynew show named wrong fix later
        private void NewShowButton_Click(object sender, EventArgs e)
        {
            if (newShowForm == null || newShowForm.IsDisposed)
                newShowForm = new NewShow(0);
            newShowForm.Show();
            newShowForm.BringToFront();
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            if(newOrderForm == null || newOrderForm.IsDisposed)
                newOrderForm = new NewOrder(0);
            newOrderForm.Show();
            newOrderForm.BringToFront();
        }

        private void NewCustomerButton_Click(object sender, EventArgs e)
        {
            if(customerInfoForm ==  null || customerInfoForm.IsDisposed)
                customerInfoForm = new CustomerInformation(0);
            customerInfoForm.Show();
            customerInfoForm.BringToFront();
        }

        private void SearchScreenButton_Click(object sender, EventArgs e)
        {
            if(newSearchForm == null || newSearchForm.IsDisposed)
                newSearchForm = new Search();
            newSearchForm.Show();
            newSearchForm.BringToFront();
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            if(newGenerateReports == null || newGenerateReports.IsDisposed)
                newGenerateReports = new Generate_Reports();
            newGenerateReports.Show();
            newGenerateReports.BringToFront();
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            if(catalog == null || catalog.IsDisposed)
                catalog = new Catalog(this);
            catalog.Show();
            catalog.BringToFront();
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            if (expense == null ||expense.IsDisposed)
                expense = new AddExpense(0);
            expense.Show();
            expense.BringToFront();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(listings == null || listings.IsDisposed)
                listings = new BrowseListing(0, this);
            listings.Show();
            listings.BringToFront();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
