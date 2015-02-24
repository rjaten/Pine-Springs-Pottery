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
    public partial class CustomerInformation : Form
    {
        private bool newCustomer;
        private ViewWishList newWishList;
        private CustomerPurchases orderHistory;
        private Customer customer;
        private OleDbConnection connection;
        private string connectionString;
        private string selectStatement;
        private List<Pattern> patterns;
        private WebBrowser emailWindow;
        private List<Customer> customers;

        public CustomerInformation(int pCustomer)
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            connection = new OleDbConnection(connectionString);
            customers = new List<Customer>();
            customer = new Customer();
            customer.customerNo = pCustomer;
            if (customer.customerNo == 0)
            {
                newCustomer = true;
            }
            else
            {
                newCustomer = false;
                //getCustomer();
            }
            patterns = DatabaseAccess.GetPatterns();
            InitializeComponent();
        }

        private void cUSTOMERBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text == "" || lastNameTextBox.Text == "")
            {
                MessageBox.Show("First and Last Name cannot be blank");
            }
            else
            {
                if (newCustomer)
                {
                    foreach (Customer cust in customers)
                    {
                        if (cust.firstName == firstNameTextBox.Text && cust.lastName == lastNameTextBox.Text)
                        {
                            DialogResult result = MessageBox.Show("This customer name already exist.\r\n"
                                + "Please check the customer address below.\r\n\r\n"
                                + cust.firstName + " " + cust.lastName + "\r\n" + cust.street + "\r\n"
                                + cust.city + ", " + cust.state + " " + cust.zip
                                + "\r\n\r\nAre they the same customer?",
                                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                bindingNavigatorDeleteItem.PerformClick();
                                int index = cUSTOMERBindingNavigator.BindingSource.Find("CustomerNo", cust.customerNo);
                                cUSTOMERBindingNavigator.BindingSource.Position = index;
                                getPatternPreference();
                                break;
                            }
                        }
                    }
                }
                newCustomer = false;
                this.Validate();
                this.cUSTOMERBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.pineSpringsPotteryDataSet);
                uneditable();
                updateBinding();
                getPatternPreference();
            }
        }

        private void updateBinding()
        {
            int pk;
            Int32.TryParse(customerNoTextBox.Text, out pk);
            this.cUSTOMERTableAdapter.Fill(this.pineSpringsPotteryDataSet.CUSTOMER);
            int index;
            if(pk <= 0)
            {
                //Open connection if not already
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                selectStatement = "SELECT MAX(CustomerNo) FROM CUSTOMER;";

                //Create Command for select statement
                OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
                pk = (int)selectCmd.ExecuteScalar();
            }
            connection.Close();
            index = cUSTOMERBindingNavigator.BindingSource.Find("CustomerNo", pk);
            cUSTOMERBindingNavigator.BindingSource.Position = index;
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            Pattern noPattern = new Pattern();
            noPattern.patternName = "";
            noPattern.patternNo = 0;
            patterns.Insert(0, noPattern);
            cboPatternPreference.DataSource = patterns;
            // TODO: This line of code loads data into the 'pineSpringsPotteryDataSet.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter.Fill(this.pineSpringsPotteryDataSet.CUSTOMER);
            patternPreferenecTextBox.DataBindings[0].Parse += new ConvertEventHandler(ParseNumeric);
            customers = DatabaseAccess.getCustomers();

            if (newCustomer)
            {
                bindingNavigatorAddNewItem.PerformClick();
            }
            else//(!newCustomer) view customer number
            {
                int index = cUSTOMERBindingNavigator.BindingSource.Find("CustomerNo", customer.customerNo);
                cUSTOMERBindingNavigator.BindingSource.Position = index;
                getPatternPreference();
                //displayCustomerInfo();
            }
        }

        private void getPatternPreference()
        {
            if (patternPreferenecTextBox.Text != "")
            {
                 cboPatternPreference.SelectedItem = patterns.Find(pattern => pattern.patternNo == Convert.ToInt32(patternPreferenecTextBox.Text));
            }
            else
            {
                cboPatternPreference.SelectedIndex = 0;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            newCustomer = false;
            editable();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            newCustomer = true;
            editable();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewWishListButton_Click(object sender, EventArgs e)
        {
            customer.customerNo = Convert.ToInt32(customerNoTextBox.Text);
            if (newWishList == null || newWishList.IsDisposed)
                newWishList = new ViewWishList(customer.customerNo);
            newWishList.Show();
            newWishList.BringToFront();
        }

        private void PurchasesButton_Click(object sender, EventArgs e)
        {
            customer.customerNo = Convert.ToInt32(customerNoTextBox.Text);
            if (orderHistory == null || orderHistory.IsDisposed)
                orderHistory = new CustomerPurchases(customer.customerNo);
            orderHistory.Show();
            orderHistory.BringToFront();
        }


        private void cboPatternPreference_SelectedIndexChanged(object sender, EventArgs e)
        {
            patternPreferenecTextBox.Text = DatabaseAccess.GetPatterns().Find(pattern => pattern.patternName == cboPatternPreference.SelectedItem.ToString()).patternNo.ToString();
            if (patternPreferenecTextBox.Text == "0")
                patternPreferenecTextBox.Text = "";
        }

        private void cUSTOMERBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            uneditable();
        }

        private void editable()
        {
            bindingNavigatorMoveFirstItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = false;
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = false;
            editButton.Enabled = false;
            firstNameTextBox.Enabled = true;
            lastNameTextBox.Enabled = true;
            streetAddressTextBox.Enabled = true;
            cityTextBox.Enabled = true;
            stateTextBox.Enabled = true;
            zipTextBox.Enabled = true;
            homePhoneTextBox.Enabled = true;
            mobilePhoneTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            contactPreferenceTextBox.Enabled = true;
            patternPreferenecTextBox.Enabled = true;
            isHostCheckBox.Enabled = true;
            creditTextBox.Enabled = true;
            notesTextBox.Enabled = true;
            taxExemptNoTextBox.Enabled = true;
            cboPatternPreference.Enabled = true;
            bindingNavigatorAddNewItem.Enabled = false;
            email.Enabled = false;
            if (newCustomer)
            {
                isHostCheckBox.Checked = false;
                PurchasesButton.Enabled = false;
                ViewWishListButton.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = true;
            }
            else
            {
                PurchasesButton.Enabled = true;
                ViewWishListButton.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = false;
            }
        }

        private void uneditable()
        {
            firstNameTextBox.Enabled = false;
            lastNameTextBox.Enabled = false;
            streetAddressTextBox.Enabled = false;
            cityTextBox.Enabled = false;
            stateTextBox.Enabled = false;
            zipTextBox.Enabled = false;
            homePhoneTextBox.Enabled = false;
            mobilePhoneTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            contactPreferenceTextBox.Enabled = false;
            patternPreferenecTextBox.Enabled = false;
            isHostCheckBox.Enabled = false;
            creditTextBox.Enabled = false;
            notesTextBox.Enabled = false;
            editButton.Enabled = true;
            totalSpentTextBox.Enabled = false;
            taxExemptNoTextBox.Enabled = false;
            cboPatternPreference.Enabled = false;
            PurchasesButton.Enabled = true;
            ViewWishListButton.Enabled = true;
            email.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = false;
            bindingNavigatorAddNewItem.Enabled = true;
            if (cUSTOMERBindingSource.Position + 1 < pineSpringsPotteryDataSet.CUSTOMER.Count)
            {
                bindingNavigatorMoveLastItem.Enabled = true;
                bindingNavigatorMoveNextItem.Enabled = true;
            }
            if (cUSTOMERBindingSource.Position > 0)
            {
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

        private void email_Click(object sender, EventArgs e)
        {
            String website = "https://outlook.com/";
            emailWindow = new WebBrowser(website);
            emailWindow.Show();
            emailWindow.BringToFront();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "")
            {
                email.Enabled = false;
            }
            else
            {
                email.Enabled = true;
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            getPatternPreference();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            getPatternPreference();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            getPatternPreference();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            getPatternPreference();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            getPatternPreference();
        }

        private void ParseNumeric(object sender, ConvertEventArgs e)
        {
            if (e.Value.Equals(""))
                e.Value = DBNull.Value;
        }
    }
}