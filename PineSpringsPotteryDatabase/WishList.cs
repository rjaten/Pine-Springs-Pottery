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
    public partial class ViewWishList : Form
    {
        private Customer customer;
        private Catalog newItemForm;
        private List<WishList> wishlistItems;
        private WishList wishlist;
        private OleDbConnection connection;
        private string connectionString;

        public ViewWishList(int pCustomer)
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            connection = new OleDbConnection(connectionString);
            customer = new Customer();
            customer.customerNo = pCustomer;
            wishlistItems = new List<WishList>();
            wishlist = new WishList();
            wishlist.customerNo = customer.customerNo;
            newItemForm = new Catalog(this);
            InitializeComponent();
        }

        private void WishList_Load(object sender, EventArgs e)
        {
            customer = DatabaseAccess.getCustomerByNo(customer.customerNo);
            txtCustomer.Text = customer.firstName + " " + customer.lastName;
            getExistingItems();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Catalog newItemForm = new Catalog(this);
            newItemForm.Show();
        }

        public void getWishListItem(LineItem pLineItem)
        {
            WishList temp = new WishList();
            temp.customerNo = wishlist.customerNo;
            temp.wishListItemNo = wishlistItems.Count + 1;
            temp.pieceNo = pLineItem.pieceNo;
            temp.patternNo = pLineItem.patternNo;
            temp.sizeNo = pLineItem.sizeNo;
            temp.customizations = pLineItem.customizations;
            temp.quantity = pLineItem.quantity;
            temp.wishDate = DateTime.Now;
            wishlistItems.Add(temp);
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridView1);
            newRow.Cells[0].Value = temp.wishListItemNo.ToString();
            newRow.Cells[0].Value = temp.wishListItemNo.ToString();
            newRow.Cells[1].Value = DatabaseAccess.GetPieceByNo(temp.pieceNo).pieceName;
            newRow.Cells[2].Value = DatabaseAccess.GetPatternByNo(temp.patternNo).patternName;
            newRow.Cells[3].Value = DatabaseAccess.GetPieceSizeByNo(temp.pieceNo, temp.sizeNo).totalPounds.ToString();
            newRow.Cells[4].Value = temp.customizations;
            newRow.Cells[5].Value = temp.quantity.ToString();
            newRow.Cells[6].Value = temp.wishDate.ToString("MM/dd/yyyy");
            dataGridView1.Rows.Add(newRow);
            updateItems();
        }

        public void getWishListItem(WishList pWishlistItem)
        {
            WishList temp = new WishList();
            temp.customerNo = wishlist.customerNo;
            temp.wishListItemNo = wishlistItems.Count + 1;
            temp.pieceNo = pWishlistItem.pieceNo;
            temp.patternNo = pWishlistItem.patternNo;
            temp.sizeNo = pWishlistItem.sizeNo;
            temp.customizations = pWishlistItem.customizations;
            temp.quantity = pWishlistItem.quantity;
            temp.wishDate = DateTime.Now;
            wishlistItems.Add(temp);
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridView1);
            newRow.Cells[0].Value = temp.wishListItemNo.ToString();
            newRow.Cells[1].Value = DatabaseAccess.GetPieceByNo(temp.pieceNo).pieceName;
            newRow.Cells[2].Value = DatabaseAccess.GetPatternByNo(temp.patternNo).patternName;
            newRow.Cells[3].Value = DatabaseAccess.GetPieceSizeByNo(temp.pieceNo, temp.sizeNo).totalPounds.ToString();
            newRow.Cells[4].Value = temp.customizations;
            newRow.Cells[5].Value = temp.quantity.ToString();
            newRow.Cells[6].Value = temp.wishDate.ToString("MM/dd/yyyy");
            dataGridView1.Rows.Add(newRow);
        }

        private void getExistingItems()
        {
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                string selectStatement = "SELECT * FROM WISHLIST WHERE CustomerNo = " + customer.customerNo + ";";
                OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
                //execute reader and close reader
                OleDbDataReader reader = selectCmd.ExecuteReader();

                while (reader.Read())
                {
                    WishList temp = new WishList();

                    temp.wishListItemNo = Convert.ToInt32(reader["WishlistItemNo"]);
                    temp.pieceNo = Convert.ToInt32(reader["PieceNo"]);
                    temp.sizeNo = Convert.ToInt32(reader["sizeNo"]);
                    temp.patternNo = Convert.ToInt32(reader["PatternNo"]);
                    if (!DBNull.Value.Equals(reader["Quantity"]))
                        temp.quantity = Convert.ToInt32(reader["Quantity"]);
                    if (!DBNull.Value.Equals(reader["WishDate"]))
                        temp.wishDate = Convert.ToDateTime(reader["WishDate"]);
                    temp.customizations = Convert.ToString(reader["Customizations"]);
                    getWishListItem(temp);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void updateItems()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String s1 = "DELETE FROM WISHLIST WHERE CustomerNo = @CustomerNo";

            OleDbCommand cmd = new OleDbCommand(s1, connection);
            cmd.Parameters.AddWithValue("@CustomerNo", customer.customerNo);
            int response = -1;
            try
            {
                response = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (WishList item in wishlistItems)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                s1 = "INSERT INTO WISHLIST (CustomerNo, PieceNo, SizeNo, WishlistItemNo, PatternNo, Quantity, Customizations, WishDate) " +
                    "VALUES (" + item.customerNo + ", " + item.pieceNo + ", " + item.sizeNo + ", " + item.wishListItemNo + ", " + item.patternNo + ", " + item.quantity + ", '" + item.customizations + "', #" + item.wishDate.ToString("MM/dd/yyyy") + "#) ";

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

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                wishlistItems.RemoveAt(row.Index);
                dataGridView1.Rows.Remove(row);
            }
            updateItems();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            wishlistItems.RemoveAt(e.Row.Index);
            updateItems();
        }

    }
}
