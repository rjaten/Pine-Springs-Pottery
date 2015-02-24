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
    public partial class NewShow : Form
    {
        private Show show;
        private String[] customerNames;
        private OleDbConnection connection;
        private string connectionString;
        private string selectStatement;
        private List<Customer> customers;
        private AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        private Catalog newItemForm;
        private List<CatalogPiece> pieces;
        private List<Pattern> patterns;
        private Guest guest;
        private List<Guest> guests;
        private Customer guestCustomer;
        private bool newShow;
        private List<ShowType> showTypes;
        private List<showPiece> piecesTaken;
        private List<showPiece> piecesSold;
        private int takenPieces = 0;
        private CustomerInformation newCustomer;
        private BrowseListing browseCustomer;
        private WebBrowser email;

        public NewShow(int pShow)
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            connection = new OleDbConnection(connectionString);
            show = new Show();
            show.showNo = pShow;
            if (show.showNo == 0)
            {
                newShow = true;
            }
            else
            {
                newShow = false;
            }
            newItemForm = new Catalog(this);
            customers = new List<Customer>();
            guest = new Guest();
            guests = new List<Guest>();
            guestCustomer = new Customer();
            piecesSold = new List<showPiece>();
            piecesTaken = new List<showPiece>();
            showTypes = DatabaseAccess.GetShowTypes();
            InitializeComponent();
        }

        private void sHOWBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (showNameTextBox.Text == "")
            {
                MessageBox.Show("There must be a show name.");
            }
            else if (showTypeTextBox.Text == "")
            {
                MessageBox.Show("There must be a show type.");
            }
            else
            {
                //make new host a host in customer table
                if (hostNoTextBox.Text != "")
                {
                    show.hostNo = Convert.ToInt32(hostNoTextBox.Text); 
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    String updateStatement = "UPDATE CUSTOMER Set isHost = true WHERE CustomerNo = " + show.hostNo;

                    OleDbCommand updateCmd = new OleDbCommand(updateStatement, connection);
                    updateCmd.ExecuteNonQuery();
                    connection.Close();
                }
                this.Validate();
                this.sHOWBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.pineSpringsPotteryDataSet);
                updateBinding();
                updateGuests();
                uneditable();
                getShowInfo();
                newShow = false;
            }
        }

        private void updateBinding()
        {
            int pk;
            Int32.TryParse(showNoTextBox.Text, out pk);
            this.sHOWTableAdapter.Fill(this.pineSpringsPotteryDataSet.SHOW);
            int index;
            if (pk <= 0)
            {
                //Open connection if not already
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                selectStatement = "SELECT MAX(ShowNo) FROM SHOW;";

                //Create Command for select statement
                OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
                pk = (int)selectCmd.ExecuteScalar();
                connection.Close();
            }
            index = sHOWBindingNavigator.BindingSource.Find("ShowNo", pk);
            sHOWBindingNavigator.BindingSource.Position = index;
        }

        private void NewShow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter.Fill(this.pineSpringsPotteryDataSet.CUSTOMER);
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.SHOW' table. You can move, or remove it, as needed.
            this.sHOWTableAdapter.Fill(this.pineSpringsPotteryDataSet.SHOW);


            getCustomers();
            //collection.AddRange(customerNames);
            //addGuestTextBox.AutoCompleteCustomSource = collection;

            patterns = DatabaseAccess.GetPatterns();
            pieces = DatabaseAccess.GetPieces();
            showTypes = DatabaseAccess.GetShowTypes();
            cboShowType.DataSource = showTypes;


            hostNoTextBox.DataBindings[0].Parse += new ConvertEventHandler(ParseNumeric);
            showDateDateTimePicker.DataBindings[0].Parse += new ConvertEventHandler(ShortDate);

            //new show
            if (show.showNo == 0)
            {
                bindingNavigatorAddNewItem.PerformClick();
            }
            else //(show != 0) view show number
            {
                int index = sHOWBindingNavigator.BindingSource.Find("ShowNo", show.showNo);
                sHOWBindingNavigator.BindingSource.Position = index;
                uneditable();
                getShowInfo();
            }
        }


        private void ShortDate(object sender, ConvertEventArgs e)
        {

            e.Value = showDateDateTimePicker.Value.ToShortDateString();
        }

        private void addGuestButton_Click(object sender, EventArgs e)
        {
            getGuest(guestCustomer);
        }

        private void takenPiecesButton_Click(object sender, EventArgs e)
        {
            if (newItemForm == null || newItemForm.IsDisposed)
                newItemForm = new Catalog(this);
            newItemForm.Show();
            newItemForm.BringToFront();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            newShow = false;
            editable();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            newShow = true;
            guests.Clear();
            dgvGuestList.Rows.Clear();
            showDateDateTimePicker.Value = DateTime.Now;
            showTypeTextBox.Text = DatabaseAccess.GetShowTypes().Find(show => show.showTypeName == cboShowType.SelectedItem.ToString()).showTypeNo.ToString();
            editable();
        }

        private void sHOWBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            uneditable();
        }

        public void getShowPieceTaken(LineItem pItem)
        {
            showPiece temp = new showPiece();
            temp.showNo = show.showNo;
            temp.itemNo = takenPieces;
            temp.sold = false;
            temp.pieceName = DatabaseAccess.GetPieceByNo(pItem.pieceNo).pieceName;
            temp.patternName = DatabaseAccess.GetPatternByNo(pItem.patternNo).patternName;
            temp.pieceSize = DatabaseAccess.GetPieceSizeByNo(pItem.pieceNo, pItem.sizeNo).totalPounds;
            piecesTaken.Add(temp);
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dgvPiecesTaken);
            newRow.Cells[0].Value = temp.itemNo;
            newRow.Cells[1].Value = temp.pieceName;
            newRow.Cells[2].Value = temp.patternName;
            newRow.Cells[3].Value = temp.pieceSize;
            dgvPiecesTaken.Rows.Add(newRow);
            updateShowPieces();
            takenPieces++;
        }

        private void getShowPieceTaken(showPiece pPiece)
        {
            showPiece temp = new showPiece();
            temp.showNo = pPiece.showNo;
            temp.itemNo = pPiece.itemNo;
            temp.sold = pPiece.sold;
            temp.pieceName = pPiece.pieceName;
            temp.patternName = pPiece.patternName;
            temp.pieceSize = pPiece.pieceSize;
            piecesTaken.Add(temp);
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dgvPiecesTaken);
            newRow.Cells[0].Value = temp.itemNo;
            newRow.Cells[1].Value = temp.pieceName;
            newRow.Cells[2].Value = temp.patternName;
            newRow.Cells[3].Value = temp.pieceSize;
            dgvPiecesTaken.Rows.Add(newRow);
        }

        private void updateShowPieces()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String s1 = "DELETE FROM ShowPieces WHERE ShowNo = @ShowNo";

            OleDbCommand cmd = new OleDbCommand(s1, connection);
            cmd.Parameters.AddWithValue("@ShowNo", show.showNo);
            int response = -1;
            try
            {
                response = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            List<showPiece> temp = new List<showPiece>();

            foreach (showPiece piece in piecesTaken)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                s1 = "INSERT INTO ShowPieces (ItemNo, ShowNo, PieceName, PatternName, PieceSize, Sold) " +
                    "VALUES (" + piece.itemNo + ", " + piece.showNo + ", '" + piece.pieceName + "', '" +
                    piece.patternName + "', " + piece.pieceSize + ", " + piece.sold + ") ";

                cmd.CommandText = s1;
                response = -1;
                try
                {
                    response = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
                connection.Close();
            foreach (showPiece piece in piecesSold)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                s1 = "INSERT INTO ShowPieces (ItemNo, ShowNo, PieceName, PatternName, PieceSize, Sold) " +
                    "VALUES (" + piece.itemNo + ", " + piece.showNo + ", '" + piece.pieceName + "', '" +
                    piece.patternName + "', " + piece.pieceSize + ", " + piece.sold + ") ";

                cmd.CommandText = s1;
                response = -1;
                try
                {
                    response = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
        }

        private void getExistingShowPiecesTaken()
        {
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                string selectStatement = "SELECT * FROM ShowPieces WHERE ShowNo = " + show.showNo + " AND Sold = " + false + " ;";
                OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
                //execute reader and close reader
                OleDbDataReader reader = selectCmd.ExecuteReader();

                while (reader.Read())
                {
                    showPiece temp = new showPiece();
                    temp.itemNo = Convert.ToInt32(reader["ItemNo"]);
                    temp.patternName = Convert.ToString(reader["PatternName"]);
                    temp.pieceName = Convert.ToString(reader["PieceName"]);
                    temp.showNo = Convert.ToInt32(reader["ShowNo"]);
                    temp.pieceSize = Convert.ToDecimal(reader["PieceSize"]);
                    temp.sold = Convert.ToBoolean(reader["Sold"]);
                    getShowPieceTaken(temp);
                    takenPieces++;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            connection.Close();
        }

        private void getShowPieceSold(showPiece pPiece, bool newPieceSold)
        {
            showPiece temp = new showPiece();
            temp.showNo = pPiece.showNo;
            temp.itemNo = pPiece.itemNo;
            temp.sold = pPiece.sold;
            temp.pieceName = pPiece.pieceName;
            temp.patternName = pPiece.patternName;
            temp.pieceSize = pPiece.pieceSize;
            piecesSold.Add(temp);
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dgvSold);
            newRow.Cells[0].Value = temp.itemNo;
            newRow.Cells[1].Value = temp.pieceName;
            newRow.Cells[2].Value = temp.patternName;
            newRow.Cells[3].Value = temp.pieceSize;
            dgvSold.Rows.Add(newRow);
            if (newPieceSold)
                updateShowPieces();
        }

        private void getExistingShowPiecesSold()
        {
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                string selectStatement = "SELECT * FROM ShowPieces WHERE ShowNo = " + show.showNo + " AND Sold = " + true + " ;";
                OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
                //execute reader and close reader
                OleDbDataReader reader = selectCmd.ExecuteReader();

                while (reader.Read())
                {
                    showPiece temp = new showPiece();
                    temp.itemNo = Convert.ToInt32(reader["ItemNo"]);
                    temp.patternName = Convert.ToString(reader["PatternName"]);
                    temp.pieceName = Convert.ToString(reader["PieceName"]);
                    temp.showNo = Convert.ToInt32(reader["ShowNo"]);
                    temp.pieceSize = Convert.ToDecimal(reader["PieceSize"]);
                    temp.sold = Convert.ToBoolean(reader["Sold"]);
                    getShowPieceSold(temp, false);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            connection.Close();
        }

        private void btnMoveToSold_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPiecesTaken.SelectedRows)
            {
                showPiece temp = new showPiece();
                temp.showNo = show.showNo;
                temp.itemNo = Convert.ToInt32((this.dgvPiecesTaken.Rows[row.Index].Cells[0].Value).ToString());
                temp.pieceName = Convert.ToString((this.dgvPiecesTaken.Rows[row.Index].Cells[1].Value).ToString());
                temp.patternName = Convert.ToString((this.dgvPiecesTaken.Rows[row.Index].Cells[2].Value).ToString());
                temp.pieceSize = Convert.ToDecimal((this.dgvPiecesTaken.Rows[row.Index].Cells[3].Value).ToString());
                temp.sold = true;
                piecesTaken.RemoveAt(row.Index);
                dgvPiecesTaken.Rows.Remove(row);
                getShowPieceSold(temp, true);
            }
        }

        private void btnMoveToTaken_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSold.SelectedRows)
            {
                showPiece temp = new showPiece();
                temp.showNo = show.showNo;
                temp.itemNo = Convert.ToInt32((this.dgvSold.Rows[row.Index].Cells[0].Value).ToString());
                temp.pieceName = Convert.ToString((this.dgvSold.Rows[row.Index].Cells[1].Value).ToString());
                temp.patternName = Convert.ToString((this.dgvSold.Rows[row.Index].Cells[2].Value).ToString());
                temp.pieceSize = Convert.ToDecimal((this.dgvSold.Rows[row.Index].Cells[3].Value).ToString());
                temp.sold = false;
                piecesSold.RemoveAt(row.Index);
                dgvSold.Rows.Remove(row);
                getShowPieceTaken(temp);
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            if (newCustomer == null || newCustomer.IsDisposed)
                newCustomer = new CustomerInformation(0);
            newCustomer.Show();
            newCustomer.BringToFront();
        }

        private void btnBrowseCustomer_Click(object sender, EventArgs e)
        {
            if (browseCustomer == null || browseCustomer.IsDisposed)
                browseCustomer = new BrowseListing(1, this, false);
            browseCustomer.Show();
            browseCustomer.BringToFront();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (browseCustomer == null || browseCustomer.IsDisposed)
                browseCustomer = new BrowseListing(1, this, true);
            browseCustomer.Show();
        }

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

            selectStatement = "SELECT CustomerNo, FirstName, LastName FROM CUSTOMER;";
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
                String name = temp.firstName + " " + temp.lastName + " (" + temp.customerNo + ")";
                customers.Add(temp);
                customerNames[count] = name;
                count++;
            }
            connection.Close();

        }

        public void getHostNo(int pCustNo)
        {
            Customer customer = DatabaseAccess.getCustomerByNo(pCustNo);
            hostTextBox.Text = customer.firstName + " " + customer.lastName;
            hostNoTextBox.Text = pCustNo.ToString();
        }

        public void getCustomerNo(int pCustNo)
        {
            Customer selectedCustomer = DatabaseAccess.getCustomerByNo(pCustNo);
            getGuest(selectedCustomer);
        }

        public void getGuest(Customer addCustomer)
        {
            Guest temp = new Guest();
            temp.showNo = show.showNo;
            temp.customerNo = addCustomer.customerNo;
            temp.firstName = addCustomer.firstName;
            temp.lastName = addCustomer.lastName;
            temp.response = GuestResponse.NORESPONSE;
            guests.Add(temp);
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dgvGuestList);
            newRow.Cells[0].Value = temp.showNo.ToString();
            newRow.Cells[1].Value = temp.customerNo.ToString();
            newRow.Cells[2].Value = temp.firstName;
            newRow.Cells[3].Value = temp.lastName;
            newRow.Cells[4].Value = temp.response.ToString();
            dgvGuestList.Rows.Add(newRow);
        }

        private void updateGuests()
        {
            //if (newShow)
            //{
            //    //Open connection if not already
            //    if (connection.State == ConnectionState.Closed)
            //    {
            //        connection.Open();
            //    }
            //    selectStatement = "SELECT MAX(ShowNo) FROM SHOW;";

            //    //Create Command for select statement
            //    OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            //    show.showNo = (int)selectCmd.ExecuteScalar();
            //    connection.Close();
            //}
            if (showNoTextBox.Text != "")
            {
                show.showNo = Convert.ToInt32(showNoTextBox.Text); if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                String s1 = "DELETE FROM GUESTLIST WHERE ShowNo = @ShowNo";

                OleDbCommand cmd = new OleDbCommand(s1, connection);
                cmd.Parameters.AddWithValue("@ShowNo", show.showNo);
                int response = -1;
                try
                {
                    response = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }
            else
                return;

            foreach (Guest guest in guests)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                String s1 = "INSERT INTO GUESTLIST (GuestNo, ShowNo, Response) " +
                    "VALUES (" + guest.customerNo + ", " + show.showNo + ", '" + guest.response.ToString() + "') ";

                OleDbCommand cmd = new OleDbCommand(s1, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
        }

        private void getExistingGuests()
        {
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                string selectStatement = "SELECT * FROM GUESTLIST WHERE ShowNo = " + show.showNo + ";";
                OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
                //execute reader and close reader
                OleDbDataReader reader = selectCmd.ExecuteReader();

                while (reader.Read())
                {
                    Guest temp = new Guest();

                    temp.customerNo = Convert.ToInt32(reader["GuestNo"]);
                    Customer selectedCustomer = customers.FirstOrDefault(customer => customer.customerNo == temp.customerNo);
                    temp.firstName = selectedCustomer.firstName;
                    temp.lastName = selectedCustomer.lastName;
                    temp.showNo = Convert.ToInt32(reader["ShowNo"]);
                    if (!DBNull.Value.Equals(reader["Response"]))
                        temp.response = (GuestResponse)Enum.Parse(typeof(GuestResponse), Convert.ToString(reader["Response"]));
                    getGuest(temp);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            connection.Close();
        }

        public void getGuest(Guest pGuest)
        {
            if (pGuest.customerNo != 0)
            {
                Guest temp = new Guest();
                temp.showNo = show.showNo;
                temp.customerNo = pGuest.customerNo;
                temp.firstName = pGuest.firstName;
                temp.lastName = pGuest.lastName;
                temp.response = pGuest.response;

                guests.Add(temp);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvGuestList);
                newRow.Cells[0].Value = temp.showNo.ToString();
                newRow.Cells[1].Value = temp.customerNo.ToString();
                newRow.Cells[2].Value = temp.firstName;
                newRow.Cells[3].Value = temp.lastName;
                newRow.Cells[4].Value = temp.response.ToString();
                dgvGuestList.Rows.Add(newRow);
            }
        }

        //private void addGuestTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (addGuestTextBox.Text != "")
        //    {
        //        addGuestButton.Enabled = true;
        //    }
        //    else
        //    {
        //        addGuestButton.Enabled = false;
        //    }
        //}

        //private void addGuestTextBox_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        string sCustNo = addGuestTextBox.Text.Substring(addGuestTextBox.Text.LastIndexOf('(') + 1, addGuestTextBox.Text.LastIndexOf(')') - addGuestTextBox.Text.LastIndexOf('(') - 1);
        //        Int32.TryParse(sCustNo, out guestCustomer.customerNo);
        //    }
        //}

        //private void addGuestTextBox_Leave(object sender, EventArgs e)
        //{
        //    if (Array.IndexOf(customerNames, addGuestTextBox.Text) == -1)
        //    {
        //        addGuestTextBox.Text = "";
        //    }
        //}

        private void getShowType()
        {
            if (showTypeTextBox.Text != "")
            {
                cboShowType.SelectedItem = showTypes.Find(show => show.showTypeNo == Convert.ToInt32(showTypeTextBox.Text));
            }
            else
            {
                cboShowType.SelectedIndex = 0;
            }
        }

        private void editable()
        {
            bindingNavigatorMoveFirstItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = false;
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = false;
            editButton.Enabled = false;
            showNameTextBox.Enabled = true;
            hostTextBox.Enabled = true;
            showDateDateTimePicker.Enabled = true;
            showLocationTextBox.Enabled = true;
            showTypeTextBox.Enabled = true;
            descriptionTextBox.Enabled = true;
            nudNonOrderSalesTotal.Enabled = true;
            bindingNavigatorAddNewItem.Enabled = false;
            cboShowType.Enabled = true;
            btnSelect.Enabled = true;
            guestListGroupBox.Enabled = true;
            btnRemoveHost.Enabled = true;
            if (newShow)
            {
                piecesGroupBox.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = true;
            }
            else
            {
                piecesGroupBox.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = false;
            }
        }

        private void uneditable()
        {
            btnSelect.Enabled = false;
            editButton.Enabled = true;
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = false;
            showNameTextBox.Enabled = false;
            hostTextBox.Enabled = false;
            showDateDateTimePicker.Enabled = false;
            showLocationTextBox.Enabled = false;
            showTypeTextBox.Enabled = false;
            descriptionTextBox.Enabled = false;
            nudNonOrderSalesTotal.Enabled = false;
            totalSalesTextBox.Enabled = false;
            guestListGroupBox.Enabled = false;
            cboShowType.Enabled = false;
            piecesGroupBox.Enabled = false;
            btnRemoveHost.Enabled = false;
            if (sHOWBindingSource.Position + 1 < pineSpringsPotteryDataSet.SHOW.Count)
            {
                bindingNavigatorMoveLastItem.Enabled = true;
                bindingNavigatorMoveNextItem.Enabled = true;
            }
            if (sHOWBindingSource.Position > 0)
            {
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

        private void cboShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            showTypeTextBox.Text = DatabaseAccess.GetShowTypes().Find(show => show.showTypeName == cboShowType.SelectedItem.ToString()).showTypeNo.ToString();
            if (showTypeTextBox.Text == "0")
                showTypeTextBox.Text = "";
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            uneditable();
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            String website = "https://outlook.com/";
            if (email == null || email.IsDisposed)
                email = new WebBrowser(website);
            email.Show();
            email.BringToFront();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            getShowInfo();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            getShowInfo();

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            getShowInfo();

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            getShowInfo();
        }

        private void getShowInfo()
        {
            dgvPiecesTaken.Rows.Clear();
            dgvSold.Rows.Clear();
            dgvGuestList.Rows.Clear();
            guests.Clear();
            getShowType();
            if (showNoTextBox.Text != "" && Convert.ToInt32(showNoTextBox.Text) > 0)
                show.showNo = Convert.ToInt32(showNoTextBox.Text);

            if (hostNoTextBox.Text != "")
            {
                show.hostNo = Convert.ToInt32(hostNoTextBox.Text);
                Customer customer = DatabaseAccess.getCustomerByNo(show.hostNo);
                hostTextBox.Text = customer.firstName + " " + customer.lastName;
            }
            else
                hostTextBox.Text = "";
            getExistingGuests();
            getExistingShowPiecesTaken();
            getExistingShowPiecesSold();
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            getShowInfo();
            uneditable();
        }

        private void dgvGuestList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            guests.RemoveAt(e.Row.Index);
        }

        private void dgvGuestList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            Guest editGuest = guests[e.RowIndex];
            DataGridViewRow row = this.dgvGuestList.Rows[e.RowIndex];
            if (e.ColumnIndex == 4)
            {
                editGuest.response = (GuestResponse)Enum.Parse(typeof(GuestResponse), row.Cells[4].Value.ToString());
            }
            guests[e.RowIndex] = editGuest;
        }

        private void btnRemoveHost_Click(object sender, EventArgs e)
        {
            hostNoTextBox.Text = "";
            hostTextBox.Text = "";
        }

        private void ParseNumeric(object sender, ConvertEventArgs e)
        {
            if (e.Value.Equals(""))
                e.Value = DBNull.Value;
        }

        private void showDateDateTimePicker_Validated(object sender, EventArgs e)
        {
            DataRowView drv = sHOWBindingSource.Current as DataRowView;
            if (drv != null)
            {
                drv["ShowDate"] = showDateDateTimePicker.Value.ToShortDateString();
                drv.Row.ClearErrors();
            }
        }

        private void showDateDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            DataRowView drv = sHOWBindingSource.Current as DataRowView;
            if (drv != null)
            {
                drv["ShowDate"] = showDateDateTimePicker.Value.ToShortDateString();
                drv.Row.ClearErrors();
            }
        }
    }
}

