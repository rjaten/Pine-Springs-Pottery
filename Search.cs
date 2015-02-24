using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PineSpringsPotteryDatabase
{
    public partial class Search : Form
    {
        private string connectionString;
        private string selectStatement;
        private OleDbConnection connection;
        private List<LineItem> lineItems;
        private String[] customerNames;
        private String[] showNames;
        private DateTime[] showDates;
        private List<int> hostNos;
        private String[] hostNames;
        private String[] orderDates;
        private SortedList<int, Customer> customers;
        private SortedList<int, Show> shows;
        private SortedList<DateTime, Order> orders;
        private SortedList<int, CatalogPiece> pieces;
        private SortedList<int, Pattern> patterns;
        private Catalog newItemForm;
        private CustomerInformation customerInfoForm;
        private NewOrder orderForm;
        private NewShow showForm;
        private CustomerPurchases customerPurchases;
        private AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

        public Search()
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            connection = new OleDbConnection(connectionString);
            lineItems = new List<LineItem>();
            customers = new SortedList<int, Customer>();
            shows = new SortedList<int, Show>();
            newItemForm = new Catalog(this);
            patterns = newItemForm.GetPatternSortedList();
            pieces = newItemForm.GetPieceSortedList();
            InitializeComponent();
        }

        private void cUSTOMERBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cUSTOMERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pineSpringsPotteryDataSet);

        }

        private void Search_Load(object sender, EventArgs e)
        {
            //fill tables
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.receivablesQuery' table. You can move, or remove it, as needed.
            this.receivablesQueryTableAdapter.Fill(this.pineSpringsPotteryDataSet.receivablesQuery);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.orderLineItemQuery' table. You can move, or remove it, as needed.
            this.orderLineItemQueryTableAdapter.Fill(this.pineSpringsPotteryDataSet.orderLineItemQuery);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.PIECE_CATALOG' table. You can move, or remove it, as needed.
            this.pIECE_CATALOGTableAdapter.Fill(this.pineSpringsPotteryDataSet.PIECE_CATALOG);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.PATTERN' table. You can move, or remove it, as needed.
            this.pATTERNTableAdapter.Fill(this.pineSpringsPotteryDataSet.PATTERN);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.ORDERS' table. You can move, or remove it, as needed.
            this.oRDERSTableAdapter.Fill(this.pineSpringsPotteryDataSet.ORDERS);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.SHOW' table. You can move, or remove it, as needed.
            this.sHOWTableAdapter.Fill(this.pineSpringsPotteryDataSet.SHOW);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter.Fill(this.pineSpringsPotteryDataSet.CUSTOMER);

            patternPanel.Visible = false;
            piecePanel.Visible = false;
            SearchPanel.Visible = false;
            DatePanel.Visible = false;
            cUSTOMERDataGridView.Visible = false;
            sHOWDataGridView.Visible = false;
            oRDERSDataGridView.Visible = false;
            receivablesQueryDataGridView.Visible = false;
            orderLineItemQueryDataGridView.Visible = false;
            getCustomers();
            getShows();
            getHostNames();
            getOrders();
            SearchByComboBox.SelectedIndex = 0;
            SearchBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            SearchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        //used to get customer names
        private void getCustomers()
        {
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            selectStatement = "SELECT COUNT(*) FROM CUSTOMER;";

            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            int numCustomers = (int)selectCmd.ExecuteScalar();
            customerNames = new String[numCustomers];

            selectStatement = "SELECT CustomerNo, FirstName, LastName, Credit FROM CUSTOMER;";
            selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                Customer temp = new Customer();
                temp.customerNo = Convert.ToInt32(reader["CustomerNo"]);
                temp.firstName = Convert.ToString(reader["FirstName"]);
                temp.lastName = Convert.ToString(reader["LastName"]);
                temp.credit = Convert.ToDecimal(reader["Credit"]);
                String name = temp.firstName + " " + temp.lastName;
                customers.Add(temp.customerNo, temp);
                customerNames[count] = name;
                count++;
            }

        }

        private void getShows()
        {
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            selectStatement = "SELECT COUNT(*) FROM SHOW;";

            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            int numShows = (int)selectCmd.ExecuteScalar();
            showNames = new String[numShows];

            hostNos = new List<int>();

            selectStatement = "SELECT ShowNo, ShowName, ShowDate, ShowTime, HostNo FROM SHOW;";
            selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                Show temp = new Show();
                temp.showNo = Convert.ToInt32(reader["ShowNo"]);
                temp.showName = Convert.ToString(reader["ShowName"]);
                temp.showNo = Convert.ToInt32(reader["ShowNo"]);
                temp.showDate = Convert.ToDateTime(reader["ShowDate"]);

                if (!DBNull.Value.Equals(reader["HostNo"]))
                {
                    temp.hostNo = Convert.ToInt32(reader["HostNo"]);
                    hostNos.Add(temp.hostNo);
                }
                String name = temp.showName;
                String dateTime = temp.showDate + " " + temp.showTime;
                shows.Add(temp.showNo, temp);
                showNames[count] = name;
                //showDates[count] = dateTime;
                count++;
            }
        }

        private void getHostNames()
        {
            hostNames = new String[hostNos.Count];
            for (int i = 0; i < hostNos.Count; i++)
            {
                int customerNo = hostNos[i] - 1;
                hostNames[i] = customerNames[customerNo];
            }
        }

        private void getOrders()
        {
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            selectStatement = "SELECT COUNT(*) FROM ORDERS;";

            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            int numOrders = (int)selectCmd.ExecuteScalar();
            orderDates = new String[numOrders];

            selectStatement = "SELECT OrderNo, OrderDate FROM ORDERS;";
            selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                Order temp = new Order();
                temp.orderNo = Convert.ToInt32(reader["OrderNo"]);
                //temp.orderDate = Convert.ToDateTime(reader["OrderDate"]);
                String name = temp.orderDate.ToString();
                //orders.Add(temp.orderDate, temp);
                orderDates[count] = name;
                count++;
            }
        }

        //resets window, sets correct grids/buttons/searchfields to visible/enabled, and adds correct collection for auto complete
        private void SearchByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //search by customer name
            if (SearchByComboBox.SelectedIndex == 0)
            {
                reset();
                collection.Clear();
                collection.AddRange(customerNames);
                SearchBox.AutoCompleteCustomSource = collection;
                SearchPanel.Visible = true;
                cUSTOMERDataGridView.Visible = true;

            }
            //search by host name
            else if (SearchByComboBox.SelectedIndex == 1)
            {
                reset();
                collection.Clear();
                collection.AddRange(hostNames);
                SearchBox.AutoCompleteCustomSource = collection;
                SearchPanel.Visible = true;
                sHOWDataGridView.Visible = true;
            }
            //search by show name 
            else if (SearchByComboBox.SelectedIndex == 2)
            {
                reset();
                collection.Clear();
                collection.AddRange(showNames);
                SearchBox.AutoCompleteCustomSource = collection;
                SearchPanel.Visible = true;
                sHOWDataGridView.Visible = true;
            }
            //search by show date
            else if (SearchByComboBox.SelectedIndex == 3)
            {
                reset();
                DatePanel.Visible = true;
                sHOWDataGridView.Visible = true;
            }
            //search by order date
            else if (SearchByComboBox.SelectedIndex == 4)
            {
                reset();
                DatePanel.Visible = true;
                oRDERSDataGridView.Visible = true;
            }
            //search by order (customer)
            else if (SearchByComboBox.SelectedIndex == 5)
            {
                reset();
                collection.Clear();
                collection.AddRange(customerNames);
                SearchBox.AutoCompleteCustomSource = collection;
                SearchPanel.Visible = true;
                oRDERSDataGridView.Visible = true;
            }
            //Search by receivables
            else if (SearchByComboBox.SelectedIndex == 6)
            {
                reset();
                receivablesQueryDataGridView.Visible = true;
                SearchButton.Enabled = false;
                //loop through rows starting with last row
                int count = receivablesQueryDataGridView.Rows.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    //if total and amount paid are equal remove row
                    DataGridViewRow row = receivablesQueryDataGridView.Rows[i];
                    if (row.Cells[2].Value.Equals(row.Cells[3].Value))
                    {
                        receivablesQueryDataGridView.Rows.Remove(row);
                    }
                }

            }
            //Search by delivered/not delivered
            else if (SearchByComboBox.SelectedIndex == 7)
            {
                reset();
                orderLineItemQueryDataGridView.Visible = true;
                ViewInfoButton.Enabled = false;
                SearchButton.Enabled = false;
                //loop through rows starting with last row
                int count = orderLineItemQueryDataGridView.Rows.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    //if item status is delivered remove row
                    DataGridViewRow row = orderLineItemQueryDataGridView.Rows[i];
                    if (row.Cells[7].Value.ToString() == "DELIVERED")
                    {
                        orderLineItemQueryDataGridView.Rows.Remove(row);
                    }
                }
            }
            //Search by Pattern
            else if (SearchByComboBox.SelectedIndex == 8)
            {
                reset();
                patternPanel.Visible = true;
                DatePanel.Visible = true;
                orderLineItemQueryDataGridView.Visible = true;
            }
            //Search by Piece
            else //(SearchByComoBox.SelectedIndex ==9)
            {
                reset();
                piecePanel.Visible = true;
                DatePanel.Visible = true;
                orderLineItemQueryDataGridView.Visible = true;

            }
        }
        //get value of selected entry, used to open a new window to the info based on the search
        private void ViewInfoButton_Click(object sender, EventArgs e)
        {
            //opens to customer info
            if (cUSTOMERDataGridView.Visible == true)
            {
                int row = cUSTOMERDataGridView.CurrentRow.Index;
                int pCustomer = (int)cUSTOMERDataGridView[0, row].Value;

                if (customerInfoForm == null || IsDisposed)
                    customerInfoForm = new CustomerInformation(pCustomer);
                customerInfoForm.Show();
                customerInfoForm.BringToFront();
            }
            //opens to show info
            else if (sHOWDataGridView.Visible == true)
            {
                int row = sHOWDataGridView.CurrentRow.Index;
                int pShow = (int)sHOWDataGridView[0, row].Value;

                if (showForm == null || IsDisposed)
                    showForm = new NewShow(pShow);
                showForm.Show();
                showForm.BringToFront();
            }
            //opens to order info unless search was done by customer, which opens customers order history
            else if (oRDERSDataGridView.Visible == true)
            {
                int row = oRDERSDataGridView.CurrentRow.Index;
                if (SearchByComboBox.SelectedIndex == 5)
                {
                    int pCustomer = (int)oRDERSDataGridView[6, row].Value;

                    if (customerPurchases == null || IsDisposed)
                        customerPurchases = new CustomerPurchases(pCustomer);
                    customerPurchases.Show();
                    customerPurchases.BringToFront();
                }
                else
                {
                    int pOrder = (int)oRDERSDataGridView[0, row].Value;

                    if (orderForm == null || IsDisposed)
                        orderForm = new NewOrder(pOrder);
                    orderForm.Show();
                    orderForm.BringToFront();
                }
            }
            //opens customer info
            else //(receivablesQueryDataGridView.Visible == true)
            {
                int row = receivablesQueryDataGridView.CurrentRow.Index;
                int pCustomer = (int)receivablesQueryDataGridView[0, row].Value;

                if (customerInfoForm == null || IsDisposed)
                    customerInfoForm = new CustomerInformation(pCustomer);
                customerInfoForm.Show();
                customerInfoForm.BringToFront();
            }
        }
        //close window
        private void MenuButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            {
                //if search by customer name
                if (SearchByComboBox.SelectedIndex == 0)
                {
                    //get search string
                    String searchValue = SearchBox.Text;
                    //loop through rows starting with last row
                    int count = cUSTOMERDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //if the search value isn't the customers full name, first name, or last name remove row
                        DataGridViewRow row = cUSTOMERDataGridView.Rows[i];
                        if (row.Cells[1].Value + " " + row.Cells[2].Value != searchValue && row.Cells[1].Value.ToString() != searchValue && row.Cells[2].Value.ToString() != searchValue)
                        {
                            cUSTOMERDataGridView.Rows.Remove(row);
                        }
                    }
                }

                //if search by host
                else if (SearchByComboBox.SelectedIndex == 1)
                {
                    int hostNo = -1;
                    String searchValue = SearchBox.Text;
                    //loop through rows starting with last row
                    int count = cUSTOMERDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //search by full name, first name, or last name (search value) to get customers number and save the number
                        DataGridViewRow row = cUSTOMERDataGridView.Rows[i];
                        if (row.Cells[1].Value + " " + row.Cells[2].Value == searchValue && row.Cells[1].Value.ToString() != searchValue && row.Cells[2].Value.ToString() != searchValue)
                        {
                            hostNo = (int)row.Cells[0].Value;
                            break;
                        }
                    }
                    //loop through rows starting with last row
                    count = sHOWDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //if the host number doesn't match the host number with that customers name remove row
                        DataGridViewRow row = sHOWDataGridView.Rows[i];
                        if ((int)row.Cells[8].Value != hostNo)
                        {
                            sHOWDataGridView.Rows.Remove(row);
                        }
                    }
                }

                //if search by show name
                else if (SearchByComboBox.SelectedIndex == 2)
                {
                    //get search string
                    String searchValue = SearchBox.Text;
                    //loop through rows starting with last row
                    int count = sHOWDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //if show name isn't the show name searched for remove row
                        DataGridViewRow row = sHOWDataGridView.Rows[i];
                        if (row.Cells[1].Value.ToString() != searchValue)
                        {
                            sHOWDataGridView.Rows.Remove(row);
                        }
                    }
                }
                //if search by show date
                else if (SearchByComboBox.SelectedIndex == 3)
                {
                    //get search dates
                    DateTime startDate = startDateTimePicker.Value.Date;
                    DateTime endDate = endDateTimePicker.Value.Date;
                    //loop through table starting with last row
                    int count = sHOWDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //compare show date to start date and to end date
                        //if show date is before the start date or after the end date remove the row
                        DataGridViewRow row = sHOWDataGridView.Rows[i];
                        int earlier = DateTime.Compare((DateTime)row.Cells[2].Value, startDate);
                        int later = DateTime.Compare((DateTime)row.Cells[2].Value, endDate);
                        if (earlier < 0 || later > 0)
                        {
                            sHOWDataGridView.Rows.Remove(row);
                        }
                    }
                }
                //if search by order date
                else if (SearchByComboBox.SelectedIndex == 4)
                {
                    //get search dates
                    DateTime startDate = startDateTimePicker.Value.Date;
                    DateTime endDate = endDateTimePicker.Value.Date;
                    //loop through rows starting with last row
                    int count = oRDERSDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //compare order date to start date and to end date
                        //if order date is before the start date or after the end date remove the row
                        DataGridViewRow row = oRDERSDataGridView.Rows[i];
                        int earlier = DateTime.Compare((DateTime)row.Cells[1].Value, startDate);
                        int later = DateTime.Compare((DateTime)row.Cells[1].Value, endDate);
                        if (earlier < 0 || later > 0)
                        {
                            oRDERSDataGridView.Rows.Remove(row);
                        }
                    }
                }
                //if search by order (customer)
                else if (SearchByComboBox.SelectedIndex == 5)
                {
                    int customerNo = -1;
                    //get search string
                    String searchValue = SearchBox.Text;
                    //loop through rows starting with last row
                    int count = cUSTOMERDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //get customer number by searching customer table
                        DataGridViewRow row = cUSTOMERDataGridView.Rows[i];
                        if (row.Cells[1].Value + " " + row.Cells[2].Value == searchValue && row.Cells[1].Value.ToString() != searchValue && row.Cells[2].Value.ToString() != searchValue)
                        {
                            customerNo = (int)row.Cells[0].Value;
                            break;
                        }
                    }
                    //loop through rows starting with last row
                    count = oRDERSDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //customer number doesn't equal the customer searched for remove row
                        DataGridViewRow row = oRDERSDataGridView.Rows[i];
                        if ((int)row.Cells[6].Value != customerNo)
                        {
                            oRDERSDataGridView.Rows.Remove(row);
                        }
                    }
                }
                
                //Receivables and delivered do not use search button since no criteria is entered

                //Search by pattern
                else if (SearchByComboBox.SelectedIndex == 8)
                {
                    //get search dates and search pattern
                    String name = patternNameComboBox.GetItemText(patternNameComboBox.SelectedItem);
                    DateTime startDate = startDateTimePicker.Value.Date;
                    DateTime endDate = endDateTimePicker.Value.Date;
                    //loop through rows starting with last row
                    int count = orderLineItemQueryDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //if the order date is before the start date or after the end date or the pattern is not what was searched for, remove row
                        DataGridViewRow row = orderLineItemQueryDataGridView.Rows[i];
                        int earlier = DateTime.Compare((DateTime)row.Cells[2].Value, startDate);
                        int later = DateTime.Compare((DateTime)row.Cells[2].Value, endDate);
                        if (earlier < 0 || later > 0 || row.Cells[3].Value.ToString() != name)
                        {
                            orderLineItemQueryDataGridView.Rows.Remove(row);
                        }
                    }
                }
                //Search by piece
                else //(SearchByComboBox.SelectedIndex == 9)
                {
                    //get search dates and piece
                    String name = pieceNameComboBox.GetItemText(pieceNameComboBox.SelectedItem);
                    DateTime startDate = startDateTimePicker.Value.Date;
                    DateTime endDate = endDateTimePicker.Value.Date;
                    //loop through rows starting with last row
                    int count = orderLineItemQueryDataGridView.Rows.Count - 1;
                    for (int i = count; i >= 0; i--)
                    {
                        //if the order date is before the start date or after the end date or the piece is not what was searched for, remove row
                        DataGridViewRow row = orderLineItemQueryDataGridView.Rows[i];
                        int earlier = DateTime.Compare((DateTime)row.Cells[2].Value, startDate);
                        int later = DateTime.Compare((DateTime)row.Cells[2].Value, endDate);
                        if (earlier < 0 || later > 0 || row.Cells[4].Value.ToString() != name)
                        {
                            orderLineItemQueryDataGridView.Rows.Remove(row);
                        }
                    }
                }
            }
        }
        //reset method called to when serch by is changed to refill tables, clear search boxes, and sets dgv/ssearchboxes to invisible
        private void reset()
        {
            //fill tables
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.receivablesQuery' table. You can move, or remove it, as needed.
            this.receivablesQueryTableAdapter.Fill(this.pineSpringsPotteryDataSet.receivablesQuery);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.orderLineItemQuery' table. You can move, or remove it, as needed.
            this.orderLineItemQueryTableAdapter.Fill(this.pineSpringsPotteryDataSet.orderLineItemQuery);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.PIECE_CATALOG' table. You can move, or remove it, as needed.
            this.pIECE_CATALOGTableAdapter.Fill(this.pineSpringsPotteryDataSet.PIECE_CATALOG);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.PATTERN' table. You can move, or remove it, as needed.
            this.pATTERNTableAdapter.Fill(this.pineSpringsPotteryDataSet.PATTERN);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.ORDERS' table. You can move, or remove it, as needed.
            this.oRDERSTableAdapter.Fill(this.pineSpringsPotteryDataSet.ORDERS);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.SHOW' table. You can move, or remove it, as needed.
            this.sHOWTableAdapter.Fill(this.pineSpringsPotteryDataSet.SHOW);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter.Fill(this.pineSpringsPotteryDataSet.CUSTOMER);
            //make invisible
            patternPanel.Visible = false;
            piecePanel.Visible = false;
            SearchPanel.Visible = false;
            DatePanel.Visible = false;
            cUSTOMERDataGridView.Visible = false;
            sHOWDataGridView.Visible = false;
            oRDERSDataGridView.Visible = false;
            receivablesQueryDataGridView.Visible = false;
            orderLineItemQueryDataGridView.Visible = false;
            SearchButton.Enabled = true;
            ViewInfoButton.Enabled = true;
            //clear search criteria
            SearchBox.Clear();
            startDateTimePicker.ResetText();
            endDateTimePicker.ResetText();
            patternNameComboBox.SelectedIndex = 0;
            pieceNameComboBox.SelectedIndex = 0;
        }
    }
}
