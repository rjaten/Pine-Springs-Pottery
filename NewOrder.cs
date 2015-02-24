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
    public partial class NewOrder : Form
    {
        //instance variables
        private string connectionString;
        private string selectStatement;
        private OleDbConnection connection;
        private String[] customerNames;
        private List<Customer> customers;
        private Catalog newItemForm;
        private bool newOrder;
        private Order order;
        private decimal leftoverCredit;
        private bool editing;
        private BrowseListing browseCustomer;
        private BrowseListing showListing;
        private CustomerInformation newCustomer;

        //Constructor
        public NewOrder(int pOrderNo)
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            connection = new OleDbConnection(connectionString);
            customers = new List<Customer>();
            order = new Order();
            order.lineItems = new List<LineItem>();
            order.orderNo = pOrderNo;
            newOrder = false;
            editing = false;
            InitializeComponent();
        }

        //onLoad
        private void NewOrder_Load(object sender, EventArgs e)
        {
            //get status combobox options
            ((DataGridViewComboBoxColumn)dgvLineItems.Columns["Status"]).DataSource = Enum.GetNames(typeof(LineItemStatus));
            //get payment type options
            paymentTypeComboBox.DataSource = Enum.GetNames(typeof(PaymentType));

            //get names for autocomplete
            customerNames = DatabaseAccess.getCustomerNames();
            txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(customerNames);
            txtName.AutoCompleteCustomSource = collection;

            //parse input for correct format for access
            customerNoTextBox.DataBindings[0].Parse += new ConvertEventHandler(ParseNumeric);
            showNoTextBox.DataBindings[0].Parse += new ConvertEventHandler(ParseNumeric); 
            orderDateDateTimePicker.DataBindings[0].Parse += new ConvertEventHandler(ShortDate);

            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.ORDERS' table. You can move, or remove it, as needed.
            this.oRDERSTableAdapter.Fill(this.pineSpringsPotteryDataSet.ORDERS);

            //new Order
            if (order.orderNo == 0)
            {
                bindingNavigatorAddNewItem.PerformClick();
                editable();
            }
            //displaying existing order
            else
            {
                newOrder = false;
                int index = ordersBindingNavigator.BindingSource.Find("OrderNo", order.orderNo);
                ordersBindingNavigator.BindingSource.Position = index;
                getOrderInfo();
                uneditable();
            }
        }

        //reset values to add new order
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            cbPaidFull.Checked = false;
            order.taxable = true;
            order = new Order();
            dgvLineItems.Rows.Clear();
            order.lineItems = new List<LineItem>();
            order.orderDate = DateTime.Now;
            orderDateDateTimePicker.Value = DateTime.Now;
            customerNoTextBox.Text = "";
            txtName.Text = "";
            showNoTextBox.Text = "";
            txtShowName.Text = "";
            subtotalTextBox.Text = "0.00";
            discountTextBox.Text = "0.00";
            txtNewTotal.Text = "0.00";
            taxTextBox.Text = "0.00";
            totalTextBox.Text = "0.00";
            nudDollarDiscount.Value = 0;
            nudPercentDiscount.Value = 0;
            nudAmountPaid.Value = 0;
            newOrder = true;
            editable();
        }

        //if editing or new order - enable fields
        private void editable()
        {
            //navigator
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorMoveFirstItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = false;
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = false;

            //enter fields
            txtName.ReadOnly = false;
            txtNotes.ReadOnly = false;
            orderDateDateTimePicker.Enabled = true;
            paymentTypeComboBox.Enabled = true;
            cbShipping.Enabled = true;
            nudShipping.Enabled = false;
            txtCheckNo.ReadOnly = false;
            cbPaidFull.Enabled = true;
            dgvLineItems.AllowUserToDeleteRows = true;
            nudAmountPaid.Enabled = true;

            dgvLineItems.Columns[3].ReadOnly = false;
            dgvLineItems.Columns[4].ReadOnly = false;
            dgvLineItems.Columns[6].ReadOnly = false;
            dgvLineItems.Columns[7].ReadOnly = false;
            dgvLineItems.Columns[8].ReadOnly = false;
            dgvLineItems.Columns[9].ReadOnly = false;

            //buttons
            btnSelectShow.Enabled = true;
            btnSelectCustomer.Enabled = true;
            btnAddNewCustomer.Enabled = true;
            btnAddItem.Enabled = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnRemoveCustomer.Enabled = true;
            btnRemoveShow.Enabled = true;

            //discount/credit
            grpDiscount.Visible = true;
            lblLeftOverCredit.Visible = true;
            lblLeftOverCreditLabel.Visible = true;

            if (newOrder)
            {
                ccbCustomerCredit.Visible = true;
                txtCustomerCredit.Visible = true;
                bindingNavigatorDeleteItem.Enabled = true;
                btnAddItem.Enabled = true;
                taxableCheckBox.Enabled = true;
            }
            else
            {
                ccbCustomerCredit.Checked = false;
                ccbCustomerCredit.Visible = false;
                txtCustomerCredit.Visible = false;
                bindingNavigatorDeleteItem.Enabled = false;
            }
        }

        //if onnly viewing - disable changes
        private void uneditable()
        {
            //navigator
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = false;

            //enter fields
            txtName.ReadOnly = true;
            txtNotes.ReadOnly = true;
            orderDateDateTimePicker.Enabled = false;
            paymentTypeComboBox.Enabled = false;
            dgvLineItems.Columns[3].ReadOnly = true;
            dgvLineItems.Columns[4].ReadOnly = true;
            dgvLineItems.Columns[6].ReadOnly = true;
            dgvLineItems.Columns[7].ReadOnly = true;
            dgvLineItems.Columns[8].ReadOnly = true;
            dgvLineItems.Columns[9].ReadOnly = true;
            cbShipping.Enabled = false;
            nudShipping.Enabled = false;
            txtCheckNo.ReadOnly = true;
            cbPaidFull.Enabled = false;
            nudAmountPaid.Enabled = false;
            taxableCheckBox.Enabled = false;
            dgvLineItems.AllowUserToDeleteRows = false;

            //buttons
            btnSelectShow.Enabled = false;
            btnSelectCustomer.Enabled = false;
            btnAddNewCustomer.Enabled = false;
            btnAddItem.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnRemoveCustomer.Enabled = false;
            btnRemoveShow.Enabled = false;

            //discount/credit
            grpDiscount.Visible = false;
            ccbCustomerCredit.Visible = false;
            txtCustomerCredit.Visible = false;
            lblLeftOverCredit.Visible = false;
            lblLeftOverCreditLabel.Visible = false;
        }

        //get items for an existing order
        private void getExistingItems()
        {
            order.lineItems = new List<LineItem>();
            List<LineItem> items;
            //Open connection if not already
            if (order.orderNo > 0)
            {
                items = DatabaseAccess.getLineItems(order.orderNo);
                foreach (LineItem item in items)
                {
                    order.lineItems.Add(item);
                }
            }
            displayLineItems();
        }
        
        //add item to order fromcatalof
        public void addLineItem(LineItem pLineItem)
        {
            order.lineItems.Add(pLineItem);
            displayLineItems();
            CalculateCurrency();
        }

        //show line items in datagrid view
        private void displayLineItems()
        {
            dgvLineItems.Rows.Clear();
            foreach (LineItem item in order.lineItems)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvLineItems);
                newRow.Cells[0].Value = DatabaseAccess.GetPieceByNo(item.pieceNo).pieceName;
                newRow.Cells[1].Value = DatabaseAccess.GetPieceSizeByNo(item.pieceNo,item.sizeNo).totalPounds.ToString();
                newRow.Cells[2].Value = DatabaseAccess.GetPatternByNo(item.patternNo).patternName;
                newRow.Cells[3].Value = item.quantity.ToString();
                newRow.Cells[4].Value = item.price.ToString("f2");
                newRow.Cells[5].Value = item.totalPrice.ToString("f2");
                newRow.Cells[6].Value = item.status.ToString();
                newRow.Cells[7].Value = item.customizations;
                newRow.Cells[8].Value = item.isGift;
                newRow.Cells[9].Value = item.cardMessage;
                dgvLineItems.Rows.Add(newRow);
            }
        }

        //show catalod to add line item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if(newItemForm == null || newItemForm.IsDisposed)
                newItemForm = new Catalog(this);
            newItemForm.Show();
            newItemForm.BringToFront();
        }

        //if item is changed in datagridview - make changes to other cells and to item list in the order object
        private void dgvLineItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || (!editing && !newOrder))
            {
                return;
            }
            //represents edited version of item
            LineItem editItem = order.lineItems[e.RowIndex];
            int quant = 0;
            decimal price = 0.0m;

            DataGridViewRow row = this.dgvLineItems.Rows[e.RowIndex];
            switch (e.ColumnIndex)
            {
                    //quantity changed
                case 3:
                    if (row.Cells["Quantity"].Value != null && int.TryParse(row.Cells["Quantity"].Value.ToString(), out quant))
                    {
                        editItem.totalPrice = quant * editItem.price;
                        row.Cells["TotalPrice"].Value = editItem.totalPrice.ToString("f2");
                    }
                    editItem.quantity = (int)(editItem.totalPrice /editItem.price);
                    row.Cells["Quantity"].Value = editItem.quantity.ToString();
                    break;
                    //item price changed
                case 4:
                    if (row.Cells["Price"].Value != null && decimal.TryParse(row.Cells["Price"].Value.ToString(), out price))
                    {
                        editItem.totalPrice = editItem.quantity * price;
                        row.Cells["TotalPrice"].Value = editItem.totalPrice.ToString("f2");
                    }
                    editItem.price = editItem.totalPrice/editItem.quantity;
                    row.Cells["Price"].Value = editItem.price.ToString("f2");
                    break;
                    //status changed
                case 6:
                    editItem.status = (LineItemStatus)Enum.Parse(typeof(LineItemStatus), row.Cells["Status"].Value.ToString());
                    break;
                    //customizations changed
                case 7:
                    if (row.Cells["Customizations"].Value != null)
                        editItem.customizations = row.Cells["Customizations"].Value.ToString();
                    else
                        editItem.customizations = "";
                    break;
                    //gift option changed
                case 8:
                    editItem.isGift = Convert.ToBoolean(row.Cells["isGift"].Value);
                    break;
                    //card message changed
                case 9:
                    if (row.Cells["CardMessage"].Value != null)
                        editItem.cardMessage = row.Cells["CardMessage"].Value.ToString();
                    else
                        editItem.cardMessage = "";
                    break;
            }
            //put new edited item into list
            order.lineItems[e.RowIndex] = editItem;
            CalculateCurrency();
        }

        //make existing order editable
        private void btnEdit_Click(object sender, EventArgs e)
        {
            editing = true;
            newOrder = false;
            nudDollarDiscount.Value = 0;
            nudPercentDiscount.Value = 0;
            editable();
        }

        //get a customer by itsnumber
        public void getCustomerNo(int pCustNo)
        {
            Customer selectedCustomer = DatabaseAccess.getCustomerByNo(pCustNo);
            txtName.Text = selectedCustomer.firstName + " " + selectedCustomer.lastName + " (" + selectedCustomer.customerNo + ")";
            customerNoTextBox.Text = pCustNo.ToString();
            getCustomerCredit();
        }

        //calculate totals, taxes, discounts
        private void CalculateCurrency()
        {
            if (editing || newOrder)
            {
                decimal subtotal = 0;
                decimal discount = 0;
                decimal newSubtotal = 0;
                decimal tax = 0;
                decimal total = 0;
                leftoverCredit = 0;
                if (dgvLineItems.RowCount < 0)
                    return;
                foreach (LineItem item in order.lineItems)
                {
                    if (item.status != LineItemStatus.CANCELLED && item.status != LineItemStatus.RETURNED)
                        subtotal += decimal.Round(item.totalPrice, 2);
                }
                subtotalTextBox.Text = subtotal.ToString("f2");

                if (rbDollarDiscount.Checked)
                    discount = Decimal.Round(nudDollarDiscount.Value + order.discount, 2);
                else
                    discount = Decimal.Round(nudPercentDiscount.Value / 100.0m * subtotal + order.discount, 2);
                discountTextBox.Text = discount.ToString("f2");

                if (ccbCustomerCredit.Checked)
                {
                    discount += Decimal.Round(Convert.ToDecimal(txtCustomerCredit.Text), 2);
                    leftoverCredit = 0.0m;
                }
                else
                    leftoverCredit = Decimal.Round(Convert.ToDecimal(txtCustomerCredit.Text),2);

                if (discount > subtotal)
                {
                    leftoverCredit += Decimal.Round(discount - subtotal,2);
                    discount = decimal.Round(subtotal, 2);
                }
                discountTextBox.Text = discount.ToString("f2");

                newSubtotal = Decimal.Round(subtotal - discount, 2);
                txtNewTotal.Text = newSubtotal.ToString("f2");

                if (taxableCheckBox.Checked)
                    tax = Decimal.Round((newSubtotal) * 0.06m, 2);
                else
                    tax = 0;
                taxTextBox.Text = tax.ToString("f2");

                total = newSubtotal + tax + nudShipping.Value;
                totalTextBox.Text = total.ToString("f2");

                if (newOrder)
                {
                    if (cbPaidFull.Checked)
                        nudAmountPaid.Value = total;
                }

                if (nudAmountPaid.Value >= total)
                {
                    txtAmountDue.Text = "0.00";
                }
                else
                    txtAmountDue.Text = (total - nudAmountPaid.Value).ToString("f2");
                lblLeftOverCredit.Text = leftoverCredit.ToString("f2");
            }
        }

        //change percent discount
        private void nudPercentDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (rbPercent.Checked && (this.newOrder || this.editing) )
                CalculateCurrency();
        }

        //change dollar discount
        private void txtDollarDiscount_TextChanged(object sender, EventArgs e)
        {
            if (rbDollarDiscount.Checked && (this.newOrder || this.editing))
                CalculateCurrency();
        }

        //change whether there is tax or not
        private void taxableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.newOrder || this.editing)
            {
                order.taxable = taxableCheckBox.Checked;
                CalculateCurrency();
            }
        }

        //saving an order
        private void btnSave_Click(object sender, EventArgs e)
        {
            //do not save an order with no itemd
            if (order.lineItems.Count <= 0)
                MessageBox.Show("No Items in Order");
            else
            {
                editing = false;
                newOrder = false;
                if (nudAmountPaid.Value > Convert.ToDecimal(totalTextBox.Text))
                    nudAmountPaid.Value = Convert.ToDecimal(totalTextBox.Text);
                if (taxableCheckBox.Checked)
                    taxableCheckBox.Checked = true;
                this.Validate();
                this.ordersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.pineSpringsPotteryDataSet);
                uneditable();
                updateBinding();
                updateTotals();
                updateLineItems();
                getOrderInfo();
            }

        }

        //refresh bindingto reflect changes and move to current order
        private void updateBinding()
        {
            int pk;
            Int32.TryParse(orderNoTextBox.Text, out pk);
            this.oRDERSTableAdapter.Fill(this.pineSpringsPotteryDataSet.ORDERS);
            int index;
            if (pk <= 0)
            {
                //Open connection if not already
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                selectStatement = "SELECT MAX(OrderNo) FROM ORDERS;";

                //Create Command for select statement
                OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
                pk = (int)selectCmd.ExecuteScalar();
                connection.Close();
            }
            index = ordersBindingNavigator.BindingSource.Find("OrderNo", pk);
            ordersBindingNavigator.BindingSource.Position = index;
        }

        //update total spent and total sales for customer or show for new order or if show/customer changes
        private void updateTotals()
        {
            if (order.customerNo > 0)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                String s2 = "UPDATE CUSTOMER SET TotalSpent = TotalSpent - " + order.newSubtotal + " WHERE CustomerNo = " + order.customerNo + ";";

                OleDbCommand cmd = new OleDbCommand(s2, connection);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }


            if (customerNoTextBox.Text != "" && Convert.ToInt32(customerNoTextBox.Text) > 0)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                String s2 = "UPDATE CUSTOMER SET TotalSpent = TotalSpent + " + txtNewTotal.Text + ", Credit = " + leftoverCredit + " WHERE CustomerNo = " + customerNoTextBox.Text + ";";

                OleDbCommand cmd = new OleDbCommand(s2, connection);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }

            if (order.showNo > 0)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                String s2 = "UPDATE SHOW SET TotalSales = TotalSales - " + order.newSubtotal + " WHERE ShowNo = " + order.showNo + ";";

                OleDbCommand cmd = new OleDbCommand(s2, connection);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }

            if (showNoTextBox.Text != "" && Convert.ToInt32(showNoTextBox.Text) > 0)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                String s2 = "UPDATE SHOW SET TotalSales = TotalSales + " + txtNewTotal.Text + " WHERE ShowNo = " + showNoTextBox.Text + ";";

                OleDbCommand cmd = new OleDbCommand(s2, connection);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }

        }

        //if new order or changes to lineitems, delete existing and write new 
        private void updateLineItems()
        {
            
            if (orderNoTextBox.Text != "" && Convert.ToInt32(orderNoTextBox.Text) > 0)
            {
                order.orderNo = Convert.ToInt32(orderNoTextBox.Text);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                String s1 = "DELETE FROM LINEITEM WHERE OrderNo = @OrderNo";

                OleDbCommand cmd = new OleDbCommand(s1, connection);
                cmd.Parameters.AddWithValue("@OrderNo", order.orderNo);
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

            foreach (LineItem item in order.lineItems)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                String s1 = "INSERT INTO LINEITEM (OrderNo, PieceNo, SizeNo, ItemLineNo, PatternType, Quantity, ItemPrice, TotalPrice, Customizations, Status, isGift, CardMessage) VALUES (" + order.orderNo + ", "
                        + item.pieceNo + ", " + item.sizeNo + ", " + (order.lineItems.IndexOf(item) + 1) + ", " + item.patternNo + ", " + item.quantity + ", " + item.price + ", " + item.totalPrice + ", @Customizations, '" + item.status.ToString() + "', " + item.isGift + ", @CardMessage);";


                OleDbCommand cmd = new OleDbCommand(s1, connection);
                cmd.Parameters.AddWithValue("@Customizations", item.customizations);
                cmd.Parameters.AddWithValue("@CardMessage", item.cardMessage);

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

        //get credit for selected customer
        private void getCustomerCredit()
        {
            if (order.customerNo > 0)
            {
                //Open connection if not already
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                selectStatement = "SELECT Credit FROM CUSTOMER WHERE CustomerNo = " + order.customerNo + ";";

                //Create Command for select statement
                OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
                txtCustomerCredit.Text = ((decimal)selectCmd.ExecuteScalar()).ToString("f2");
                connection.Close();
            }
        }

        //change date of order struct 
        private void orderDateDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (newOrder)
                order.orderDate = orderDateDateTimePicker.Value;
        }

        //select customer from listing
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            if(browseCustomer == null || browseCustomer.IsDisposed)
                browseCustomer = new BrowseListing(1, this);
            browseCustomer.Show();
            browseCustomer.BringToFront();
        }

        //cancel changes of close form
        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (newOrder || !editing)
            {
                this.Close();
            }
            else if(editing)
            {
                this.editing = false;
                this.oRDERSTableAdapter.Fill(this.pineSpringsPotteryDataSet.ORDERS);
                int index = ordersBindingNavigator.BindingSource.Find("OrderNo", order.orderNo);
                ordersBindingNavigator.BindingSource.Position = index;
                getOrderInfo();
                uneditable();
            }
        }

        //customer selected from auto complete
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Check if the Text has changed and set the other fields. Reset the textchanged flag
                string sCustNo = txtName.Text.Substring(txtName.Text.LastIndexOf('(') + 1, txtName.Text.LastIndexOf(')') - txtName.Text.LastIndexOf('(') - 1);
                try
                {
                    customerNoTextBox.Text = sCustNo;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
                getCustomerCredit();
            }
        }

        //open new customer form to add a new customer
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            if(newCustomer == null || newCustomer.IsDisposed)
                newCustomer = new CustomerInformation(0);
            newCustomer.Show();
            newCustomer.BringToFront();
        }

        //if option to use customer credit changes
        private void ccbCustomerCredit_CheckedChanged(object sender, EventArgs e)
        {
            if(editing || newOrder)
                CalculateCurrency();
        }

        //if option to use percet discount changes
        private void rbPercent_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCurrency();
        }

        //if paid in full option changes
        private void cbPaidFull_CheckedChanged(object sender, EventArgs e)
        {

            if (newOrder || editing)
            {
                if (cbPaidFull.Checked)
                {
                    nudAmountPaid.Enabled = false;
                }
                else
                {
                    nudAmountPaid.Enabled = true;
                }
                CalculateCurrency();
            }
        }

        //if notes changes
        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            order.notes = txtNotes.Text;
        }

        //get show from listing
        public void getShow(int pShowNo, string pShowName, DateTime pShowDate)
        {
            showNoTextBox.Text = pShowNo.ToString(); ;
            txtShowName.Text = pShowName;
            orderDateDateTimePicker.Value = pShowDate;
        }

        //show listing to select show
        private void btnSelectShow_Click(object sender, EventArgs e)
        {
            if (showListing == null || showListing.IsDisposed)
                showListing = new BrowseListing(3, this);
            showListing.Show();
            showListing.BringToFront();
        }

        //if shipping option changes
        private void cbShipping_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShipping.Checked)
            {
                nudShipping.Enabled = true;
            }
            else
            {
                nudShipping.Value = 0;
                nudShipping.Enabled = false;
            }
        }

        //if payment type changes
        private void paymentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paymentTypeComboBox.Text == "CHECK")
            {
                lblCheckNo.Visible = true;
                txtCheckNo.Visible = true;
            }
            else
            {
                txtCheckNo.Visible = false;
                lblCheckNo.Visible = false;
            }
        }

        //cancel add new order - no deleting of previous orders
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            nudPercentDiscount.Value = 0;
            nudDollarDiscount.Value = 0;
            newOrder = false;
            getOrderInfo();
            Int32.TryParse(orderNoTextBox.Text, out order.orderNo);
            uneditable();
        }

        //if deleting from dgv, delete from list
        private void dgvLineItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!editing && !newOrder)
                e.Cancel = true;
            else
            {
                order.lineItems.RemoveAt(e.Row.Index);
                CalculateCurrency();
            }
        }

        //shipping value changed
        private void nudShipping_ValueChanged(object sender, EventArgs e)
        {
            if (this.newOrder || this.editing)
                CalculateCurrency();
        }

        //dollar discount amount changed
        private void txtDollarDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (this.newOrder || this.editing)
                CalculateCurrency();
        }

        //get info about next order
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            getOrderInfo();
        }

        //get info about order to store if changes are made
        private void getOrderInfo()
        {
            if (orderNoTextBox.Text != "")
                order.orderNo = Convert.ToInt32(orderNoTextBox.Text);
            if (order.orderNo > 0)
            {
                if (showNoTextBox.Text != "")
                {
                    order.showNo = Convert.ToInt32(showNoTextBox.Text);
                    txtShowName.Text = DatabaseAccess.getShowNameByNo(order.showNo);
                }
                else
                    txtShowName.Text = "";
                if (customerNoTextBox.Text != "")
                {
                    order.customerNo = Convert.ToInt32(customerNoTextBox.Text);
                    Customer customer = DatabaseAccess.getCustomerByNo(order.customerNo);
                    txtName.Text = customer.firstName + " " + customer.lastName + " (" + customer.customerNo + ")";
                    getCustomerCredit();
                }
                else
                {
                    txtName.Text = "";
                }
                order.orderDate = orderDateDateTimePicker.Value;
                order.notes = txtNotes.Text;
                if (subtotalTextBox.Text != "")
                    order.subtotal = Convert.ToDecimal(subtotalTextBox.Text);
                if (discountTextBox.Text != "")
                    order.discount = Convert.ToDecimal(discountTextBox.Text);
                if (txtNewTotal.Text != "")
                    order.newSubtotal = Convert.ToDecimal(txtNewTotal.Text);
                order.taxable = taxableCheckBox.Checked;
                if (taxTextBox.Text != "")
                    order.tax = Convert.ToDecimal(subtotalTextBox.Text);
                if (totalTextBox.Text != "")
                    order.total = Convert.ToDecimal(totalTextBox.Text);
                order.amountPaid = nudAmountPaid.Value;
                cbPaidFull.Checked = (order.amountPaid >= order.total);
                order.paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), paymentTypeComboBox.Text);
                order.checkNo = txtCheckNo.Text;
                txtAmountDue.Text = (order.total - order.amountPaid).ToString("f2");
                getExistingItems();
            }
        }

        //get info about last order
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            getOrderInfo();
        }

        //get info from previous order
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            getOrderInfo();
        }

        //get info from first order
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            getOrderInfo();
        }

        //if amount paid value changes
        private void nudAmountPaid_ValueChanged(object sender, EventArgs e)
        {
            if (newOrder || editing)
                CalculateCurrency();
        }

        //if no value in show number, assign dataset value to null
        private void showNoTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (showNoTextBox.Text == "")
            {
                DataRowView drv = ordersBindingSource.Current as DataRowView;
                if (drv != null)
                {
                    drv["ShowNo"] = DBNull.Value;
                    drv.Row.ClearErrors();
                }
            }  
        }

        //if no value in customer number, assign dataset value to null
        private void customerNoTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (customerNoTextBox.Text == "")
            {
                DataRowView drv = ordersBindingSource.Current as DataRowView;
                if (drv != null)
                {
                    drv["CustomerNo"] = DBNull.Value;
                    drv.Row.ClearErrors();
                }
            }  
        }

        //show customizations or card message in dailog box for easier read
        private void dgvLineItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            DataGridViewRow row = this.dgvLineItems.Rows[e.RowIndex];
            switch (e.ColumnIndex)
            {
                case 7:
                    MessageBox.Show(row.Cells["Customizations"].Value.ToString(), "Customizations");
                    break;
                case 9:
                    MessageBox.Show(row.Cells["CardMessage"].Value.ToString(), "Card Message");
                    break;
            }
        }

        //remove show from order
        private void btnRemoveShow_Click(object sender, EventArgs e)
        {
            showNoTextBox.Text = null;
            txtShowName.Text = "";
        }

        //remove customer from order
        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            customerNoTextBox.Text = null;
            txtName.Text = "";
        }

        //parse blank number box to null
        private void ParseNumeric(object sender, ConvertEventArgs e)
        {
            if (e.Value.Equals(""))
                e.Value = DBNull.Value;
        }

        //parse date to short date for easier comparisons
        private void ShortDate(object sender, ConvertEventArgs e)
        {
                e.Value = orderDateDateTimePicker.Value.ToShortDateString();
        }

        //parse date to short date for easier comparisons
        private void orderDateDateTimePicker_Validated(object sender, EventArgs e)
        {
            DataRowView drv = ordersBindingSource.Current as DataRowView;
            if (drv != null)
            {
                drv["OrderDate"] = orderDateDateTimePicker.Value.ToShortDateString();
                drv.Row.ClearErrors();
            }
        }

        //parse date to short date for easier comparisons
        private void orderDateDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            DataRowView drv = ordersBindingSource.Current as DataRowView;
            if (drv != null)
            {
                drv["OrderDate"] = orderDateDateTimePicker.Value.ToShortDateString();
                drv.Row.ClearErrors();
            }
        }

    }
}
