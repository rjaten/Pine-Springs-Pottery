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
    public partial class BrowseListing : Form
    {
        //instance variables
        private readonly string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
        private OleDbConnection connection;
        private string expenseSelect;           //dynamic select of expenses
        private string customerSelect;          //dynamic select of customers
        private string orderSelect;             //dynamic select of orders
        private string ShowSelect;              //dynamic select of shows
        private Form parent;                    //form that called this one
        private int type;                       //type of listing to show
       // private CustomerInformation displayCustomer;
        private NewOrder showOrder;
        private NewShow showShow;
        private AddExpense viewExpense;
        private bool isHost;
        //flags that datepickers were changed
        private bool startdateOrdChanged;       //orders
        private bool enddateOrdChanged;
        private bool startdateShowChanged;      //shows
        private bool enddateShowChanged;
        private bool startdateExpChanged;       //expenses
        private bool enddateExpChanged;

        //Constructor
        public BrowseListing(int pType, Form pParent)
        {
            connection = new OleDbConnection(connectionString);
            parent = pParent;
            this.type = pType;
            startdateExpChanged = false;
            enddateExpChanged = false;
            startdateShowChanged = false;
            enddateShowChanged = false;
            startdateOrdChanged = false;
            enddateOrdChanged = false;
            InitializeComponent();
        }


        public BrowseListing(int pType, Form pParent, bool pIsHost)
        {
            isHost = pIsHost;
            connection = new OleDbConnection(connectionString);
            parent = pParent;
            this.type = pType;
            startdateExpChanged = false;
            enddateExpChanged = false;
            startdateShowChanged = false;
            enddateShowChanged = false;
            startdateOrdChanged = false;
            enddateOrdChanged = false;
            InitializeComponent();
        }

        //onLoad
        private void BrowseListing_Load(object sender, EventArgs e)
        {
            ////if Customer only listing
            //if (type == 1)
            //{
            //    customerSelect = "SELECT CUSTOMER.CustomerNo, CUSTOMER.FirstName, CUSTOMER.LastName, CUSTOMER.StreetAddress, CUSTOMER.City, CUSTOMER.State, CUSTOMER.Zip, " +
            //         "CUSTOMER.HomePhone, CUSTOMER.MobilePhone, CUSTOMER.Email, CUSTOMER.ContactPreference, PATTERN.PatternName, CUSTOMER.TotalSpent, " +
            //         "CUSTOMER.isHost, CUSTOMER.Credit, CUSTOMER.Notes, CUSTOMER.TaxExemptNo FROM (CUSTOMER LEFT OUTER JOIN PATTERN ON CUSTOMER.PatternPreference = PATTERN.PatternNo)";
            //    getCustomers();
            //    //remove other tabs
            //    tabHolder.TabPages.Remove(tabShow);
            //    tabHolder.TabPages.Remove(tabOrder);
            //    tabHolder.TabPages.Remove(tabExpenses);
            //}
            ////if order only listing
            //else if (type == 2)
            //{
            //    orderSelect = "SELECT ORDERS.OrderNo, CUSTOMER.FirstName + ' ' + CUSTOMER.LastName AS Name, ORDERS.OrderDate, SHOW.ShowName, ORDERS.Subtotal, ORDERS.Discount, " +
            //             "ORDERS.NewSubtotal, ORDERS.Tax, ORDERS.Shipping, ORDERS.Total, ORDERS.AmountPaid, ORDERS.PaymentType, ORDERS.CheckNo, ORDERS.Notes, ORDERS.Taxable " +
            //             "FROM ((ORDERS LEFT OUTER JOIN SHOW ON ORDERS.ShowNo = SHOW.ShowNo) LEFT OUTER JOIN CUSTOMER ON ORDERS.CustomerNo = CUSTOMER.CustomerNo)";
            //    getOrders();
            //    //remove other tabs
            //    tabHolder.TabPages.Remove(tabShow);
            //    tabHolder.TabPages.Remove(tabExpenses);
            //    tabHolder.TabPages.Remove(tabCustomer);
            //}
            ////if show only listing
            //else if (type == 3)
            //{
            //    getShowTypes();
            //    ShowSelect = "SELECT SHOW.ShowNo, SHOW.ShowName, CUSTOMER.FirstName + ' ' + CUSTOMER.LastName AS HostName, SHOW.ShowDate, SHOW.ShowTime, SHOW.ShowLocation, " +
            //             "SHOW_TYPE.ShowTypeName As ShowType, SHOW.TotalSales, SHOW.NonOrderSalesTotal, SHOW.Description FROM ((SHOW LEFT OUTER JOIN " +
            //             "CUSTOMER ON SHOW.HostNo = CUSTOMER.CustomerNo) INNER JOIN SHOW_TYPE ON SHOW.ShowType = SHOW_TYPE.ShowTypeNo)";
            //    getShows();
            //    //remove other tabs
            //    tabHolder.TabPages.Remove(tabCustomer);
            //    tabHolder.TabPages.Remove(tabOrder);
            //    tabHolder.TabPages.Remove(tabExpenses);
            //}
            ////if expense only listing
            //else if (type == 4)
            //{
            //    getExpenseTypes();
            //    expenseSelect = "SELECT EXPENSE.ExpenseNo, EXPENSE_TYPE.ExpenseTypeName, EXPENSE.ExpenseDate, EXPENSE.Amount,  EXPENSE.Mileage, EXPENSE.Description  FROM (EXPENSE INNER JOIN EXPENSE_TYPE ON EXPENSE.ExpenseType = EXPENSE_TYPE.ExpenseTypeNo)";
            //    getExpenses();
            //    //remove other tabs
            //    tabHolder.TabPages.Remove(tabShow);
            //    tabHolder.TabPages.Remove(tabOrder);
            //    tabHolder.TabPages.Remove(tabCustomer);
            //}
            ////show all lists and tabs
            //else
            //{
               loadData();
            //}
        }

        //Handle Tab switching
        private void tabHolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (type == 0)
                loadData();
        }

        //Load Data
        private void loadData()
        {
            //which tab is selected
            switch (tabHolder.SelectedIndex)
            {
                case 0:
                    customerSelect = "SELECT CUSTOMER.CustomerNo, CUSTOMER.FirstName, CUSTOMER.LastName, CUSTOMER.StreetAddress, CUSTOMER.City, CUSTOMER.State, CUSTOMER.Zip, " +
                         "CUSTOMER.HomePhone, CUSTOMER.MobilePhone, CUSTOMER.Email, CUSTOMER.ContactPreference, PATTERN.PatternName, CUSTOMER.TotalSpent, " +
                         "CUSTOMER.isHost, CUSTOMER.Credit, CUSTOMER.Notes, CUSTOMER.TaxExemptNo FROM (CUSTOMER LEFT OUTER JOIN PATTERN ON CUSTOMER.PatternPreference = PATTERN.PatternNo)";
                    getCustomers();
                    break;
                case 1:
                    orderSelect = "SELECT ORDERS.OrderNo, ORDERS.OrderDate, PIECE_CATALOG.PieceName, PIECE_SIZE.TotalPounds, PATTERN.PatternName, " +
                         "LINEITEM.Quantity, LINEITEM.Customizations, LINEITEM.ItemPrice, ORDERS.Subtotal, ORDERS.Discount, " +
                         "ORDERS.Total FROM (((((ORDERS INNER JOIN LINEITEM ON ORDERS.OrderNo = LINEITEM.OrderNo) INNER JOIN " +
                         "PATTERN ON LINEITEM.PatternType = PATTERN.PatternNo) INNER JOIN CUSTOMER ON ORDERS.CustomerNo = CUSTOMER.CustomerNo) INNER JOIN " +
                         "PIECE_SIZE ON LINEITEM.PieceNo = PIECE_SIZE.PieceNo AND LINEITEM.SizeNo = PIECE_SIZE.SizeNo) INNER JOIN " +
                         "PIECE_CATALOG ON PIECE_SIZE.PieceNo = PIECE_CATALOG.PieceNo) " +
                         "WHERE  (CUSTOMER.CustomerNo = " + customerNoTextBox.Text + ");";
                    getOrders();
                    break;
                case 2:
                    getShowTypes();
                    ShowSelect = "SELECT SHOW.ShowNo, SHOW.ShowName, CUSTOMER.FirstName + ' ' + CUSTOMER.LastName AS HostName, SHOW.ShowDate, SHOW.ShowTime, SHOW.ShowLocation, " +
                             "SHOW_TYPE.ShowTypeName As ShowType, SHOW.TotalSales, SHOW.NonOrderSalesTotal, SHOW.Description FROM ((SHOW LEFT OUTER JOIN " +
                             "CUSTOMER ON SHOW.HostNo = CUSTOMER.CustomerNo) INNER JOIN SHOW_TYPE ON SHOW.ShowType = SHOW_TYPE.ShowTypeNo)";
                    getShows();
                    break;
                case 3:
                    getExpenseTypes();
                    expenseSelect = "SELECT EXPENSE.ExpenseNo, EXPENSE_TYPE.ExpenseTypeName, EXPENSE.ExpenseDate, EXPENSE.Amount,  EXPENSE.Mileage, EXPENSE.Description  FROM (EXPENSE INNER JOIN EXPENSE_TYPE ON EXPENSE.ExpenseType = EXPENSE_TYPE.ExpenseTypeNo)";
                    getExpenses();
                    break;
                default:
                    break;
            }
        }
        #region CUSTOMER
        //***************************************************CUSTOMERS*******************************************************************************************//
        //Double click on cell
        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //if a data row
            if (e.RowIndex >= 0)
            {
                //get cutomer no
                int custNo = Convert.ToInt32((this.dgvCustomers.Rows[e.RowIndex].Cells["CustomerNo"].Value).ToString());
                //add to new order form
                if (parent.GetType() == typeof(NewOrder))
                {
                    ((NewOrder)parent).getCustomerNo(custNo);
                    this.Close();
                }
                //new show form
                else if (parent.GetType() == typeof(NewShow))
                {
                    if (!isHost)
                        ((NewShow)parent).getCustomerNo(custNo);
                    else
                        ((NewShow)parent).getHostNo(custNo);
                    this.Close();
                }
                else if (parent.GetType() == typeof(Generate_Reports))
                {
                    ((Generate_Reports)parent).getCustomer(custNo);
                    this.Close();
                }
                //show customer info
                
//================                //else
                //{
                //    if( displayCustomer == null || displayCustomer.IsDisposed)
                //        displayCustomer = new CustomerInformation(custNo);
                //    displayCustomer.Show();
                //}
            }
        }

        //Fill grid with customers
        private void getCustomers()
        {
            OleDbDataAdapter odaCustomers = new OleDbDataAdapter(customerSelect, connection);
            DataTable dtCustomers = new DataTable();
            connection.Close();
            odaCustomers.Fill(dtCustomers);
            dgvCustomers.DataSource = dtCustomers;
            dgvCustomers.Columns["CustomerNo"].Width = 0;
            dgvCustomers.Columns["State"].Width = 0;
            dgvCustomers.Columns["Zip"].Width = 0;
            dgvCustomers.Columns["TotalSpent"].DefaultCellStyle.Format = "f2";
            dgvCustomers.Columns["Credit"].DefaultCellStyle.Format = "f2";
        }

        //Clear all search criteria
        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            txtFirstNameCustomer.Text = "";
            txtLastNameCustomer.Text = "";
            txtCityCustomer.Text = "";
            nudTotalSpent.Value = 0;
            cbHostCustomer.Checked = false;
            cbTaxExemptCustomer.Checked = false;
        }

        //when first name search changes - refresh data
        private void txtFirstNameCustomer_TextChanged(object sender, EventArgs e)
        {
           // makeCustomerSelect();
            //getCustomers();
        }

        //when last name search changes - refresh data
        private void txtLastNameCustomer_TextChanged(object sender, EventArgs e)
        {
           // makeCustomerSelect();
           // getCustomers();
        }

        //when city search changes - refresh data
        private void txtCityCustomer_TextChanged(object sender, EventArgs e)
        {
           // makeCustomerSelect();
           // getCustomers();
        }

        //when host search changes - refresh data
        private void cbHostCustomer_CheckedChanged(object sender, EventArgs e)
        {
           // makeCustomerSelect();
           // getCustomers();
        }

        //when tax exempt search changes - refresh data
        private void cbTaxExemptCustomer_CheckedChanged(object sender, EventArgs e)
        {
           // makeCustomerSelect();
           // getCustomers();
        }

        //when total spent search changes - refresh data
        private void nudTotalSpent_ValueChanged(object sender, EventArgs e)
        {
          //  makeCustomerSelect();
           // getCustomers();
        }

        //Make select statement based on search criteria
        private void makeCustomerSelect()
        {
            customerSelect = "SELECT CUSTOMER.CustomerNo, CUSTOMER.FirstName, CUSTOMER.LastName, CUSTOMER.StreetAddress, CUSTOMER.City, CUSTOMER.State, CUSTOMER.Zip, " +
                 "CUSTOMER.HomePhone, CUSTOMER.MobilePhone, CUSTOMER.Email, CUSTOMER.ContactPreference, PATTERN.PatternName, CUSTOMER.TotalSpent, " +
                 "CUSTOMER.isHost, CUSTOMER.Credit, CUSTOMER.Notes, CUSTOMER.TaxExemptNo FROM (CUSTOMER LEFT OUTER JOIN PATTERN ON CUSTOMER.PatternPreference = PATTERN.PatternNo) WHERE CUSTOMER.CustomerNo <> null";

            if (txtSearch.Text != "")
            {
                customerSelect += " AND CUSTOMER.FirstName LIKE '%" + txtSearch.Text + "%'";
                customerSelect += " OR CUSTOMER.LastName LIKE '%" + txtSearch.Text + "%'";
            }
            if (txtCityCustomer.Text != "")
            {
                customerSelect += " AND CUSTOMER.City LIKE '%" + txtCityCustomer.Text + "%'";
            }
            customerSelect += " AND CUSTOMER.TotalSpent >= " + nudTotalSpent.Value;
            if (cbHostCustomer.Checked)
            {
                customerSelect += " AND Customer.isHost = true";
            }
            if (cbTaxExemptCustomer.Checked)
            {
                customerSelect += " AND Customer.TaxExemptNo <> null";
            }
        }

        
        #endregion

        #region orders
        //***************************************************ORDERS*******************************************************************************************//
        

        //get orders to fill datagridview
        private void getOrders()
        {
            OleDbDataAdapter odaOrders = new OleDbDataAdapter(orderSelect, connection);
            DataTable dtOrders = new DataTable();
            connection.Close();
            odaOrders.Fill(dtOrders);
            dgvOrders.DataSource = dtOrders;
            //dgvOrders.Columns["Subtotal"].DefaultCellStyle.Format = "f2";
            //dgvOrders.Columns["Subtotal"].Width = 80;
            //dgvOrders.Columns["Discount"].DefaultCellStyle.Format = "f2";
            //dgvOrders.Columns["Discount"].Width = 80;
            //dgvOrders.Columns["NewSubtotal"].DefaultCellStyle.Format = "f2";
            //dgvOrders.Columns["NewSubtotal"].Width = 80;
            //dgvOrders.Columns["Tax"].DefaultCellStyle.Format = "f2";
            //dgvOrders.Columns["Tax"].Width = 80;
            //dgvOrders.Columns["Shipping"].DefaultCellStyle.Format = "f2";
            //dgvOrders.Columns["Shipping"].Width = 80;
            //dgvOrders.Columns["Total"].DefaultCellStyle.Format = "f2";
            //dgvOrders.Columns["Total"].Width = 80;
            //dgvOrders.Columns["AmountPaid"].DefaultCellStyle.Format = "f2";
            //dgvOrders.Columns["AmountPaid"].Width = 80;
            //dgvOrders.Columns["Taxable"].Width = 30;
            //dgvOrders.Columns["OrderNo"].Width = 50;
            //dgvOrders.Columns["OrderDate"].Width = 80;
        }

        //double click on order cell
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //display order info if in data row
            if (e.RowIndex >= 0)
            {
                int orderNo = Convert.ToInt32((this.dgvOrders.Rows[e.RowIndex].Cells["OrderNo"].Value).ToString());
                if(showOrder == null || showOrder.IsDisposed)
                    showOrder = new NewOrder(orderNo);
                showOrder.Show();
            }
        }

        //reset search critria
        private void btnClearOrders_Click(object sender, EventArgs e)
        {
            //dtpEndDateOrders.Value = DateTime.Now;
            //dtpStartDateOrders.Value = DateTime.Now;
            cbTaxExemptOrders.Checked = false;
            //txtCustomerNAmeOrders.Text = "";
            nudSubtotal.Value= 0;
            enddateOrdChanged = false;
            startdateOrdChanged = false;
            makeOrderSelect();
            getOrders();
        }

        //when date criteria changes - refresh order data
        private void dtpStartDateOrders_ValueChanged(object sender, EventArgs e)
        {
            startdateOrdChanged = true;
            makeOrderSelect();
            getOrders();
        }

        //when date criteria changes - refresh order data
        private void dtpEndDateOrders_ValueChanged(object sender, EventArgs e)
        {
            enddateOrdChanged = true;
            makeOrderSelect();
            getOrders();
        }

        //when name criteria changes - refresh order data
        private void txtCustomerNAmeOrders_TextChanged(object sender, EventArgs e)
        {
            makeOrderSelect();
            getOrders();
        }

        //when tax-exempt criteria changes - refresh order data
        private void cbTaxExemptOrders_CheckedChanged(object sender, EventArgs e)
        {
            makeOrderSelect();
            getOrders();
        }

        //when subtotal criteria changes - refresh order data
        private void nudSubtotal_ValueChanged(object sender, EventArgs e)
        {
            makeOrderSelect();
            getOrders();
        }

        //when showname criteria changes - refresh order data
        private void txtShowName_TextChanged(object sender, EventArgs e)
        {
            makeOrderSelect();
            getOrders();
        }



        //make new select statement based on search criteria
        private void makeOrderSelect()
        {
            orderSelect = "SELECT ORDERS.OrderNo, CUSTOMER.FirstName + ' ' + CUSTOMER.LastName AS Name, ORDERS.OrderDate, SHOW.ShowName, ORDERS.Subtotal, ORDERS.Discount, " +
                             "ORDERS.NewSubtotal, ORDERS.Tax, ORDERS.Shipping, ORDERS.Total, ORDERS.AmountPaid, ORDERS.PaymentType, ORDERS.CheckNo, ORDERS.Notes, ORDERS.Taxable " +
                             "FROM ((ORDERS LEFT OUTER JOIN SHOW ON ORDERS.ShowNo = SHOW.ShowNo) LEFT OUTER JOIN CUSTOMER ON ORDERS.CustomerNo = CUSTOMER.CustomerNo) WHERE ORDERS.OrderNo <> null";
            //if (txtCustomerNAmeOrders.Text != "")
            //{
            //    orderSelect += " AND CUSTOMER.FirstName + ' ' + CUSTOMER.LastName LIKE '%" + txtCustomerNAmeOrders.Text + "%'";
            //}
            if (txtShowName.Text != "")
            {
                orderSelect += " AND SHOW.ShowName LIKE '%" + txtShowName.Text + "%'";
            }
            orderSelect += " AND ORDERS.Subtotal >= " + nudSubtotal.Value; 
            if (cbTaxExemptOrders.Checked)
            {
                orderSelect += " AND ORDERS.Taxable = false";
            }
            if (startdateOrdChanged)
            {
               // orderSelect += " AND ORDERS.OrderDate >= #" + dtpStartDateOrders.Value.ToString("MM/dd/yyyy") + "#";
            }
            if (enddateOrdChanged)
            {
                //orderSelect += " AND ORDERS.OrderDate <= #" + dtpEndDateOrders.Value.ToString("MM/dd/yyyy") + "#";
            }
        }
        #endregion

        #region SHOWS
        //***************************************************SHOWS*******************************************************************************************//
        //get data to fill show datagridview
        private void getShows()
        {
            OleDbDataAdapter odaShows = new OleDbDataAdapter(ShowSelect, connection);
            DataTable dtShows = new DataTable();
            connection.Close();
            odaShows.Fill(dtShows);
            dgvShows.DataSource = dtShows;
            dgvShows.Columns["TotalSales"].DefaultCellStyle.Format = "f2";
            dgvShows.Columns["NonOrderSalesTotal"].DefaultCellStyle.Format = "f2";
            dgvShows.Columns["ShowNo"].Width = 50;
            dgvShows.Columns["ShowDate"].Width = 80;
            dgvShows.Columns["ShowTime"].Width = 80;
        }

        //get show types for drop down option
        private void getShowTypes()
        {
            List<string> showTypes = new List<string>();
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT ShowTypeName FROM SHOW_TYPE;";
            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                showTypes.Add(Convert.ToString(reader["ShowTypeName"]));
            }
            cbxShowType.DataSource = showTypes;
            cbxShowType.SelectedItem = null;
        }

        //Double click on show data cell
        private void dgvShows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if in a data cell
            if (e.RowIndex >= 0)
            {
                //get show information
                int showNo = Convert.ToInt32((this.dgvShows.Rows[e.RowIndex].Cells["ShowNo"].Value).ToString());
                string showName = (this.dgvShows.Rows[e.RowIndex].Cells["ShowName"].Value).ToString();
                DateTime showDate = Convert.ToDateTime((this.dgvShows.Rows[e.RowIndex].Cells["ShowDate"].Value).ToString());
                //if from new order, pass in show info to new order parent
                if (parent.GetType() == typeof(NewOrder))
                {
                    ((NewOrder)parent).getShow(showNo, showName, showDate);
                    this.Close();
                }
                //display show info form
                else
                {
                    if(showShow == null || showShow.IsDisposed)
                        showShow = new NewShow(showNo);
                    showShow.Show();
                }
            }
        }

        //when host name criteria changes - refresh show data
        private void txtHostNameShows_TextChanged(object sender, EventArgs e)
        {
            makeShowSelect();
            getShows();
        }

        //when show type criteria changes - refresh show data
        private void cbxShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            makeShowSelect();
            getShows();
        }

        //when date criteria changes - refresh show data
        private void dtpStartDateShows_ValueChanged(object sender, EventArgs e)
        {
            startdateShowChanged = true;
            makeShowSelect();
            getShows();
        }

        //when date criteria changes - refresh show data
        private void dtpEndDateShows_ValueChanged(object sender, EventArgs e)
        {
            enddateShowChanged = true;
            makeShowSelect();
            getShows();
        }

        //reset search criteria
        private void btnClearShows_Click(object sender, EventArgs e)
        {
            dtpStartDateShows.Value = DateTime.Now;
            dtpEndDateShows.Value = DateTime.Now;
            startdateShowChanged = false;
            enddateShowChanged = false;
            cbxShowType.SelectedItem = null;
            txtHostNameShows.Text = "";

        }

        //make new select statement based on search criteria
        private void makeShowSelect()
        {
            ShowSelect = "SELECT SHOW.ShowNo, SHOW.ShowName, CUSTOMER.FirstName + ' ' + CUSTOMER.LastName AS Host, SHOW.ShowDate, SHOW.ShowTime, SHOW.ShowLocation, " +
                             "SHOW_TYPE.ShowTypeName As ShowType, SHOW.TotalSales, SHOW.NonOrderSalesTotal, SHOW.Description FROM ((SHOW LEFT OUTER JOIN " +
                             "CUSTOMER ON SHOW.HostNo = CUSTOMER.CustomerNo) INNER JOIN SHOW_TYPE ON SHOW.ShowType = SHOW_TYPE.ShowTypeNo) WHERE Show.ShowNo <> null";

            if (txtHostNameShows.Text != "")
            {
                ShowSelect += " AND CUSTOMER.FirstName + ' ' + CUSTOMER.LastName LIKE '%" + txtHostNameShows.Text + "%'";
            }

            if (cbxShowType.SelectedItem != null)
            {
                ShowSelect += " AND SHOW_TYPE.ShowTypeName = '" + cbxShowType.SelectedItem.ToString() + "'";
            }
            if (startdateShowChanged)
            {
                ShowSelect += " AND SHOW.ShowDate >= #" + dtpStartDateShows.Value.ToString("MM/dd/yyyy") + "#";
            }
            if (enddateShowChanged)
            {
                ShowSelect += " AND SHOW.ShowDate <= #" + dtpEndDateShows.Value.ToString("MM/dd/yyyy") + "#";
            }
        }
        #endregion

        #region Expenses
        //***************************************************EXPENSES***********************************************************************************//
        //get expense data to fill datagridview
        private void getExpenses()
        {
            OleDbDataAdapter odaExpeses = new OleDbDataAdapter(expenseSelect, connection);
            DataTable dtExpenses = new DataTable();
            connection.Close();
            odaExpeses.Fill(dtExpenses);
            dgvExpenses.DataSource = dtExpenses;
        }
        
        //double click on expense data cell
        private void dgvExpenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if not a header row
            if (e.RowIndex >= 0)
            {
                //display info
                int expenseNo = Convert.ToInt32((this.dgvExpenses.Rows[e.RowIndex].Cells["ExpenseNo"].Value).ToString());
                if(viewExpense == null || viewExpense.IsDisposed)
                    viewExpense = new AddExpense(expenseNo);
                viewExpense.Show();
            }
        }

        //get expense types to fill option drop down
        private void getExpenseTypes()
        {
            List<string> expenseTypes = new List<string>();
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT ExpenseTypeName FROM EXPENSE_TYPE;";
            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                expenseTypes.Add(Convert.ToString(reader["ExpenseTypeName"]));
            }
            expenseTypeComboBox.DataSource = expenseTypes;
            expenseTypeComboBox.SelectedItem = null;
        }

        //when expense type criteria changes - refresh expense data
        private void expenseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            makeExpenseSelect();
            getExpenses();
        }

        //when date criteria changes - refresh expense data
        private void dtpStartDateExpense_ValueChanged(object sender, EventArgs e)
        {
            startdateExpChanged = true;
            makeExpenseSelect();
            getExpenses();
        }

        //when date criteria changes - refresh expense data
        private void dtpEndDateExpense_ValueChanged(object sender, EventArgs e)
        {
            enddateExpChanged = true;
            makeExpenseSelect();
            getExpenses();
        }

        //clear search criteria
        private void btnClearExpenses_Click(object sender, EventArgs e)
        {
            dtpStartDateExpense.Value = DateTime.Now;
            dtpEndDateExpense.Value = DateTime.Now;
            expenseTypeComboBox.SelectedItem = null;
            startdateExpChanged = false;
            enddateExpChanged = false;
            expenseSelect = "SELECT EXPENSE.ExpenseNo, EXPENSE_TYPE.ExpenseTypeName, EXPENSE.ExpenseDate, EXPENSE.Amount,  EXPENSE.Mileage, EXPENSE.Description  FROM (EXPENSE INNER JOIN EXPENSE_TYPE ON EXPENSE.ExpenseType = EXPENSE_TYPE.ExpenseTypeNo)";
            getExpenses();
        }

        //make new select statement based on search criteria
        private void makeExpenseSelect()
        {
            expenseSelect = "SELECT EXPENSE.ExpenseNo, EXPENSE_TYPE.ExpenseTypeName, EXPENSE.ExpenseDate, EXPENSE.Amount,  EXPENSE.Mileage, EXPENSE.Description "
                + "FROM (EXPENSE INNER JOIN EXPENSE_TYPE ON EXPENSE.ExpenseType = EXPENSE_TYPE.ExpenseTypeNo) WHERE EXPENSE.ExpenseNo <> null";

            if (expenseTypeComboBox.SelectedItem != null)
            {
                expenseSelect += " AND EXPENSE_TYPE.ExpenseTypeName = '" + expenseTypeComboBox.SelectedItem.ToString() + "'";
            }
            if (startdateExpChanged)
            {
                expenseSelect += " AND EXPENSE.ExpenseDate >= #" + dtpStartDateExpense.Value.ToString("MM/dd/yyyy") + "#";
            }
            if (enddateExpChanged)
            {
                expenseSelect += " AND EXPENSE.ExpenseDate <= #" + dtpEndDateExpense.Value.ToString("MM/dd/yyyy") + "#";
            }
        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {
            
        }



        private void dgvOrderHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewOrder newOrderForm = new NewOrder(0); 
            if (newOrderForm == null || newOrderForm.IsDisposed)
                newOrderForm = new NewOrder(0);
            newOrderForm.Show();
            newOrderForm.BringToFront();
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            Catalog catalog = new Catalog(this);
            if (catalog == null || catalog.IsDisposed)
                catalog = new Catalog(this);
            catalog.Show();
            catalog.BringToFront();
        }
         #endregion
        
        #region 2015 Changes
        //searches db for first or last name entered by user and outputs to dvgCustomer
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            makeCustomerSelect();
            getCustomers();
            //searchCustomer();

        }
        //highlight all text for easier input of new info
        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
        }
        //clear search field
        private void btnSearchClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        //check for duplicate customers
        private void searchCustomer()
        {
           
            //select all data in dvgCustomers, cycle through looking for dublicate
            //first and last name for the customer that the user is trying to 
            //enter into the db. If duplicate data is found ask your if it is the 
            //same customer or new customer with same name.
            //**************************************************************
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(txtFirstNameCustomer.Text.TrimEnd()) && row.Cells[2].Value.ToString().Equals(txtLastNameCustomer.Text.TrimEnd()))
                {
                    
                    DialogResult result = MessageBox.Show("This customer name already exist.\r\n"
                        + "Please check the customer address below.\r\n\r\n"
                        + row.Cells[1].Value.ToString()
                        + " " + row.Cells[2].Value.ToString() + "\r\n" + row.Cells[3].Value.ToString() + "\r\n"
                        + row.Cells[4].Value.ToString() + ", " + row.Cells[5].Value.ToString() + " "
                        + row.Cells[6].Value.ToString()
                        + "\r\n\r\nAre they the same customer?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    break;
             //********************************************************
                    // continue search to see if any more duplicates 
                    // then write to db
                }
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtFirstNameCustomer.Text = dgvCustomers.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                txtLastNameCustomer.Text = dgvCustomers.Rows[e.RowIndex].Cells["LastName"].Value.ToString();

                txtStreetAddressTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["StreetAddress"].Value.ToString();
                txtCityCustomer.Text = dgvCustomers.Rows[e.RowIndex].Cells["City"].Value.ToString();
                stateTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["State"].Value.ToString();
                zipTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["Zip"].Value.ToString();

                homePhoneTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["HomePhone"].Value.ToString();
                mobilePhoneTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["MobilePhone"].Value.ToString();

                emailTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                taxExemptNoTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["TaxExemptNo"].Value.ToString();
                totalSpentTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["TotalSpent"].Value.ToString();


                customerNoTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["CustomerNo"].Value.ToString();

                if (dgvCustomers.Rows[e.RowIndex].Cells["IsHost"].Value.ToString() == "True")
                {
                    isHostCheckBox.Checked = true;
                }
                else
                {
                    isHostCheckBox.Checked = false;
                }

            }
                loadData();


        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string searchData = txtSearch.Text;//hold user search critera
            //clear the search info to restore full datalist for dgvCustomer
            btnSearchClear_Click(this,e);
            //look for duplicate
            searchCustomer();
            //return user search critera
            txtSearch.Text = searchData;
        }

        //fill data about customer into appropriate fields such as textboxes and 
        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                txtFirstNameCustomer.Text = dgvCustomers.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                txtLastNameCustomer.Text = dgvCustomers.Rows[e.RowIndex].Cells["LastName"].Value.ToString();

                txtStreetAddressTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["StreetAddress"].Value.ToString();
                txtCityCustomer.Text = dgvCustomers.Rows[e.RowIndex].Cells["City"].Value.ToString();
                stateTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["State"].Value.ToString();
                zipTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["Zip"].Value.ToString();

                homePhoneTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["HomePhone"].Value.ToString();
                mobilePhoneTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["MobilePhone"].Value.ToString();

                emailTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                taxExemptNoTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["TaxExemptNo"].Value.ToString();
                totalSpentTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["TotalSpent"].Value.ToString();


                customerNoTextBox.Text = dgvCustomers.Rows[e.RowIndex].Cells["CustomerNo"].Value.ToString();

                if (dgvCustomers.Rows[e.RowIndex].Cells["IsHost"].Value.ToString() == "True")
                {
                    isHostCheckBox.Checked = true;
                }
                else
                {
                    isHostCheckBox.Checked = false;
                }
            }
        }
        #endregion










    }
}
    



       
