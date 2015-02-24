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
    public partial class AddExpenseType : Form
    {
        //instance variables
        private OleDbConnection connection;
        private Form parent;
        private SortedList<int, string> types;

        //Constructor
        public AddExpenseType(Form pParent, SortedList<int, string> pTypes, OleDbConnection pConnection)
        {
            connection = pConnection;
            parent = pParent;
            types = pTypes;
            InitializeComponent();
        }

        //onload 
        private void AddExpenseType_Load(object sender, EventArgs e){}

        //Add Expense Type
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!(txtNewType.Text == "") && types.IndexOfValue(txtNewType.Text) == -1)
            {
                //Open connection if not already
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //insert new type
                String insert = "INSERT INTO EXPENSE_TYPE ( ExpenseTypeName) VALUES ('" + txtNewType.Text + "');";
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

                //force add expense form to give new type as option
                if (parent.GetType() == typeof(AddExpense))
                {
                    ((AddExpense)parent).getExpenseTypes();
                }
            }
            this.Close();
                
        }

        //Close and make no changes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
