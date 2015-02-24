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
    public partial class AddExpense : Form
    {
        //Instance Variables
        private readonly string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
        private OleDbConnection connection;
        private SortedList<int, string> expenseTypes;
        private int expenseNo;
        private AddExpenseType newtype;
        private WebBrowser map;

        //Constructor
        public AddExpense(int pExpenseNo)
        {
            InitializeComponent();
            expenseTypes = new SortedList<int, string>();
            connection = new OleDbConnection(connectionString);
            expenseNo = pExpenseNo;
        }

        //onLoad
        private void AddExpense_Load(object sender, EventArgs e)
        {
            getExpenseTypes();          //get types to load in combobox
            //if displaying existing expense
            if (expenseNo > 0)
            {
                //disable input
                expenseDateDateTimePicker.Enabled = false;
                expenseTypeComboBox.Enabled = false;
                nudAmount.ReadOnly = true;
                nudMileage.ReadOnly = true;
                descriptionTextBox.ReadOnly = true;
                btnSubmit.Visible = false;
                btnCancel.Text = "Close";
                getExpense();
            }
            //if new expense
            else
            {
                //enable input
                btnDelete.Visible = false;
                expenseDateDateTimePicker.Enabled = true;
                expenseTypeComboBox.Enabled = true;
                nudAmount.ReadOnly = false;
                nudMileage.ReadOnly = false;
                descriptionTextBox.ReadOnly = false;
                btnSubmit.Visible = true;
                btnCancel.Text = "Cancel";
            }
        }

        //get list of expense types
        public void getExpenseTypes()
        {
            //empty expense type list
            expenseTypes.Clear();
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT  * FROM EXPENSE_TYPE;";
            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            //get info from reader
            while (reader.Read())
            {
                expenseTypes.Add(Convert.ToInt32(reader["ExpenseTypeNo"]), Convert.ToString(reader["ExpenseTypeName"]));
            }
            connection.Close();

            //turn expense type list into string array for combobox source
            int count = 0;
            string[] types = new string[expenseTypes.Count];
            foreach (string type in expenseTypes.Values)
            {
                types[count] = type;
                count++;
            }
            expenseTypeComboBox.DataSource = types;
        }

        //get existing expense
        private void getExpense()
        {
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //make sql statement, command, and execute it to a data reader
            string selectStatement = "SELECT EXPENSE_TYPE.ExpenseTypeName, EXPENSE.ExpenseDate, EXPENSE.Amount,  EXPENSE.Mileage, EXPENSE.Description  FROM (EXPENSE INNER JOIN EXPENSE_TYPE ON EXPENSE.ExpenseType = EXPENSE_TYPE.ExpenseTypeNo) WHERE EXPENSE.ExpenseNo = " + expenseNo + ";";
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            OleDbDataReader reader = selectCmd.ExecuteReader();

            //get info from reader
            while (reader.Read())
            {
                expenseTypeComboBox.SelectedItem = Convert.ToString(reader["ExpenseTypeName"]);
                expenseDateDateTimePicker.Value = Convert.ToDateTime(reader["ExpenseDate"]);
                nudAmount.Value = Convert.ToDecimal(reader["Amount"]);
                nudMileage.Value = Convert.ToDecimal(reader["Mileage"]);
                descriptionTextBox.Text = Convert.ToString(reader["Description"]);

            }
            connection.Close();
        }

        //add new expense
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //make sql statement, command, and execute it to a data reader
            String insert = "INSERT INTO EXPENSE ( ExpenseType,  ExpenseDate, Amount, Mileage, Description) VALUES ("
                    + expenseTypes.Keys[expenseTypes.IndexOfValue(expenseTypeComboBox.SelectedItem.ToString())] + ", #"
                    + expenseDateDateTimePicker.Value + "#, "
                    + nudAmount.Value + ", "
                    + nudMileage.Value + ", '"
                    + descriptionTextBox.Text + "');";
            OleDbCommand cmd = new OleDbCommand(insert, connection);

            int response = -1;
            try
            {
                //if successfull give confirmation
                response = cmd.ExecuteNonQuery();
                MessageBox.Show(expenseTypeComboBox.SelectedItem.ToString() + " Expense Added", "Expense Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            this.Close();
        }

        //Close form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Add new Expense Type
        private void expenseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if form doesn't already exist - create it
            if(newtype == null || newtype.IsDisposed)
                newtype = new AddExpenseType(this, expenseTypes, connection);
            newtype.Show();
            newtype.BringToFront();
        }

        private void mapButton_Click(object sender, EventArgs e)
        {
            String website = "https://maps.google.com/";
            if (map == null || map.IsDisposed)
                map = new WebBrowser(website);
            map.Show();
            map.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete?",
                      "Delete Expense", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //make sql statement, command, and execute it to a data reader
                String insert = "DELETE FROM EXPENSE WHERE ExpenseNo = " + expenseNo;
                OleDbCommand cmd = new OleDbCommand(insert, connection);

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
                this.Close();
            }
        }

    }
}
