using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * tara a few notes to hopefully make my thought process clear
 * the first is setting up what happens when you choose an option in the combobox
 * this is where the dynamic elements are postioned like the buttons labels and so forth
 * the aactual reports are made in an rdlc file strauser told me that using a datagrid view wouldbetter than what im doing right now so i will
 * look in to doing that loding th report happens in the button click events*/
namespace PineSpringsPotteryDatabase
{
    public partial class Generate_Reports : Form
    {
        // class variables
        DateTime enteredDate;
        DateTime totalenteredDate2;
        DateTime totalenteredDate3;
        DateTime expenseEnteredDate;
        DateTime expenseEnteredDate2;
        private OleDbDataReader reader;
        private BrowseListing browseCustomer;
        
        public Generate_Reports()
        {
            InitializeComponent();
        }

        private void Generate_Reports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PineSpringsPotteryDataSet.DataTable2' table. You can move, or remove it, as needed.
            //this.DataTable2TableAdapter.Fill(this.PineSpringsPotteryDataSet.DataTable2);
            // TODO: This line of code loads data into the 'PineSpringsPotteryDataSet.productinqueryByShow' table. You can move, or remove it, as needed.
            // this.productinqueryByShowTableAdapter.Fill(this.PineSpringsPotteryDataSet.productinqueryByShow);
            // TODO: This line of code loads data into the 'PineSpringsPotteryDataSet.totalSalesQuery' table. You can move, or remove it, as needed.
            //this.totalSalesQueryTableAdapter.Fill(this.PineSpringsPotteryDataSet.totalSalesQuery);
            //this.SHOWTableAdapter.Fill(this.DataSet1.SHOW, enteredDate);
            // TODO: This line of code loads data into the 'DataSet1.SHOW' table. You can move, or remove it, as needed.
            this.totalSalesQueryTableAdapter.Fill(this.PineSpringsPotteryDataSet.totalSalesQuery, DateTime.Now, DateTime.Now);
            // TODO: This line of code loads data into the 'PineSpringsPotteryDataSet.stats' table. You can move, or remove it, as needed.
            this.statsTableAdapter.Fill(this.PineSpringsPotteryDataSet.stats);
            // TODO: This line of code loads data into the 'PineSpringsPotteryDataSet.EXPENSE1' table. You can move, or remove it, as needed.
            //this.EXPENSE1TableAdapter.Fill(this.PineSpringsPotteryDataSet.EXPENSE1);
            this.EXPENSE1TableAdapter.Fill(this.PineSpringsPotteryDataSet.EXPENSE1, DateTime.Now, DateTime.Now);

            // TODO: This line of code loads data into the 'PineSpringsPotteryDataSet.produtionVersion2' table. You can move, or remove it, as needed.
            this.produtionVersion2TableAdapter.Fill(this.PineSpringsPotteryDataSet.produtionVersion2, dtpProdStart.Value, dtpProcEnd.Value);
            // TODO: This line of code loads data into the 'PineSpringsPotteryDataSet.DeliveryQuery' table. You can move, or remove it, as needed.
            this.DeliveryQueryTableAdapter.Fill(this.PineSpringsPotteryDataSet.DeliveryQuery, DateTime.Now);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            //this.reportViewer5.RefreshReport();
            this.reportViewer6.RefreshReport();
            this.reportViewer3.RefreshReport();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void showInfobutton_Click(object sender, EventArgs e)
        {

        }

        public void getCustomer(int pCustNo)
        {
            Customer customer = DatabaseAccess.getCustomerByNo(pCustNo);
            rtxtAddress.Text = customer.firstName + " " + customer.lastName + "\r\n" +
                customer.street + "\r\n" +
                customer.city + ", " + customer.state + " " + customer.zip;
            //listBox1.Items.Clear();
            //listBox1.Items.Add(customer.firstName + " " + customer.lastName);
            //listBox1.Items.Add(customer.street);
            //listBox1.Items.Add(customer.city + ", " + customer.state + " " + customer.zip);

        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            if(browseCustomer == null || browseCustomer.IsDisposed)
                browseCustomer = new BrowseListing(1, this);
            browseCustomer.Show();
            browseCustomer.BringToFront();


            //string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            //OleDbConnection connection = new OleDbConnection(connectionString);
            ////Open connection if not already
            //if (connection.State == ConnectionState.Closed)
            //{
            //    connection.Open();
            //}
            //try
            //{
            //    string selectStatement = "SELECT StreetAddress, City, State,Zip" + " FROM CUSTOMER WHERE FirstName='" + firstNametextBox3.Text + "' AND LastName='" + lastNameTextBox.Text + "';";
            //    OleDbCommand subSelectCmd = new OleDbCommand(selectStatement, connection);
            //    reader = subSelectCmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string addressOutput = reader["StreetAddress"].ToString();
            //        string cityOutput = reader["City"].ToString();
            //        string State = reader["StreetAddress"].ToString();
            //        string Zip = reader["Zip"].ToString();
            //        listBox1.Items.Add(firstNametextBox3.Text);
            //        listBox1.Items.Add(lastNameTextBox.Text);
            //        listBox1.Items.Add(addressOutput);
            //        listBox1.Items.Add(cityOutput);
            //        listBox1.Items.Add(State);
            //        listBox1.Items.Add(Zip);
            //        listBox1.Items.Add("");
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("There must be text entered into both textboxes in order to work");
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //string input = totaltextBox1.Text;
                //string input2 = totaltextBox2.Text;
                //totalenteredDate2 = DateTime.Parse(input);
                //totalenteredDate3 = DateTime.Parse(input2);
                this.totalSalesQueryTableAdapter.Fill(this.PineSpringsPotteryDataSet.totalSalesQuery, dtpSaleStart.Value, dtpSalesEnd.Value);
                this.reportViewer6.RefreshReport();
            }
            catch
            {
                MessageBox.Show("two dates in the form of month/day/year needs to be entered in order to work ex 3/26/2013");
            }
        }

        private void expenseButton_Click(object sender, EventArgs e)
        {
            try
            {
                //string expenseInput = expensetextBox1.Text;
                //string expenseInput2 = expensetextBox2.Text;
                //expenseEnteredDate = DateTime.Parse(expenseInput);
               // expenseEnteredDate2 = DateTime.Parse(expenseInput2);
                this.EXPENSE1TableAdapter.Fill(this.PineSpringsPotteryDataSet.EXPENSE1,dtpStartDate.Value,dtpEndDate.Value);
                this.reportViewer3.RefreshReport();
            }
            catch
            {
              MessageBox.Show("two dates in the form of month/day/year needs to be entered in order to work ex 3/26/2013");

            }
        }

        private void reportViewer6_Load(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            rtxtAddress.SelectAll();
            Clipboard.SetText(rtxtAddress.Text);
            MessageBox.Show("Address copied to Clipboard");
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            this.DeliveryQueryTableAdapter.Fill(this.PineSpringsPotteryDataSet.DeliveryQuery, dtpDelivShowDate.Value);
            this.reportViewer1.RefreshReport();
        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            this.produtionVersion2TableAdapter.Fill(this.PineSpringsPotteryDataSet.produtionVersion2, dtpProdStart.Value, dtpProcEnd.Value);
            this.reportViewer2.RefreshReport();
        }

      

    }
}
