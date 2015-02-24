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
    public partial class CustomerPurchases : Form
    {
        private string orderSelect;
        private Customer customer;
        private readonly string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
        private OleDbConnection connection;

        public CustomerPurchases(int pcustomer)
        {
            customer = new Customer();
            connection = new OleDbConnection(connectionString);
            customer.customerNo = pcustomer;
            InitializeComponent();
        }

        private void CustomerListing_Load(object sender, EventArgs e)
        {
            customer = DatabaseAccess.getCustomerByNo(customer.customerNo);
            txtCustomerName.Text = customer.firstName + " " + customer.lastName;
            loadData();

   
        }

        private void loadData()
        {
            orderSelect = "SELECT ORDERS.OrderNo, ORDERS.OrderDate, PIECE_CATALOG.PieceName, PIECE_SIZE.TotalPounds, PATTERN.PatternName, " +
                 "LINEITEM.Quantity, LINEITEM.Customizations, LINEITEM.ItemPrice, ORDERS.Subtotal, ORDERS.Discount, " +
                 "ORDERS.Total FROM (((((ORDERS INNER JOIN LINEITEM ON ORDERS.OrderNo = LINEITEM.OrderNo) INNER JOIN " +
                 "PATTERN ON LINEITEM.PatternType = PATTERN.PatternNo) INNER JOIN CUSTOMER ON ORDERS.CustomerNo = CUSTOMER.CustomerNo) INNER JOIN " +
                 "PIECE_SIZE ON LINEITEM.PieceNo = PIECE_SIZE.PieceNo AND LINEITEM.SizeNo = PIECE_SIZE.SizeNo) INNER JOIN " +
                 "PIECE_CATALOG ON PIECE_SIZE.PieceNo = PIECE_CATALOG.PieceNo) " +
                 "WHERE  (CUSTOMER.CustomerNo = " + customer.customerNo + ");";

            OleDbDataAdapter odaOrders = new OleDbDataAdapter(orderSelect, connection);
            DataTable dtOrders = new DataTable();
            odaOrders.Fill(dtOrders);
            connection.Close();
            dgvOrderHistory.DataSource = dtOrders;
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderNo = Convert.ToInt32((this.dgvOrderHistory.Rows[e.RowIndex].Cells["OrderNo"].Value).ToString());
            NewOrder showOrder = new NewOrder(0);
            showOrder.Show();
        }

        private void CustomerPurchases_Load(object sender, EventArgs e)
        {

        }
    }
}
