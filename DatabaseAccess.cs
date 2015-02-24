using PineSpringsPotteryDatabase.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PineSpringsPotteryDatabase
{
    class DatabaseAccess
    {
        public static readonly string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb"; 


        public static List<Customer> getCustomers()
        {

            OleDbConnection connection = new OleDbConnection(connectionString);
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            List<Customer> customers = new List<Customer>();

            String selectStatement = "SELECT * FROM CUSTOMER;";
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            try
            {

                while (reader.Read())
                {
                    Customer temp = new Customer();
                    temp.customerNo = Convert.ToInt32(reader["CustomerNo"]);
                    temp.firstName = Convert.ToString(reader["FirstName"]);
                    temp.lastName = Convert.ToString(reader["LastName"]);
                    temp.credit = Convert.ToDecimal(reader["Credit"]);
                    temp.totalSpent = Convert.ToDecimal(reader["TotalSpent"]);
                    temp.street = Convert.ToString(reader["StreetAddress"]);
                    temp.city = Convert.ToString(reader["City"]);
                    temp.state = Convert.ToString(reader["State"]);
                    temp.zip = Convert.ToString(reader["Zip"]);
                    temp.homePhone = Convert.ToString(reader["HomePhone"]);
                    temp.mobilePhone = Convert.ToString(reader["MobilePhone"]);
                    temp.contactPreference = Convert.ToString(reader["ContactPreference"]);
                    temp.isHost = Convert.ToBoolean(reader["isHost"]);
                    temp.notes = Convert.ToString(reader["Notes"]);
                    temp.email = Convert.ToString(reader["Email"]);
                    //temp.patternPreferenceNo = Convert.ToInt32(reader["PatternPreference"]);
                    temp.taxExemptNo = Convert.ToString(reader["TaxExemptNo"]);
                    customers.Add(temp);
                }
            }
            catch (DataException exp)
            {
                MessageBox.Show(exp.Message);
            }
            connection.Close();
            return customers;
        }

        public static Customer getCustomerByNo(int pCustomerNo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            List<Customer> customers = new List<Customer>();

            String selectStatement = "SELECT * FROM CUSTOMER WHERE CUSTOMER.CustomerNo = " + pCustomerNo + ";";
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            Customer customer = new Customer();
            try
            {

                while (reader.Read())
                {
                    customer.customerNo = Convert.ToInt32(reader["CustomerNo"]);
                    customer.firstName = Convert.ToString(reader["FirstName"]);
                    customer.lastName = Convert.ToString(reader["LastName"]);
                    customer.credit = Convert.ToDecimal(reader["Credit"]);
                    customer.totalSpent = Convert.ToDecimal(reader["TotalSpent"]);
                    customer.street = Convert.ToString(reader["StreetAddress"]);
                    customer.city = Convert.ToString(reader["City"]);
                    customer.state = Convert.ToString(reader["State"]);
                    customer.zip = Convert.ToString(reader["Zip"]);
                    customer.homePhone = Convert.ToString(reader["HomePhone"]);
                    customer.mobilePhone = Convert.ToString(reader["MobilePhone"]);
                    customer.contactPreference = Convert.ToString(reader["ContactPreference"]);
                    customer.isHost = Convert.ToBoolean(reader["isHost"]);
                    customer.notes = Convert.ToString(reader["Notes"]);
                    customer.email = Convert.ToString(reader["Email"]);
                    //customer.patternPreferenceNo = Convert.ToInt32(reader["PatternPreference"]);
                    customer.taxExemptNo = Convert.ToString(reader["TaxExemptNo"]);
                }
            }
            catch (DataException exp)
            {
                MessageBox.Show(exp.Message);
            }
            connection.Close();
            return customer;
        }

        public static String[] getCustomerNames()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String selectStatement = "SELECT COUNT(*) FROM CUSTOMER;";

            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            int numCustomers = (int)selectCmd.ExecuteScalar();
            String[] customerNames = new String[numCustomers];

            selectStatement = "SELECT CustomerNo, FirstName, LastName, Credit, TotalSpent FROM CUSTOMER;";
            selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                String name = Convert.ToString(reader["FirstName"]) + " " + Convert.ToString(reader["LastName"]) + " (" + Convert.ToInt32(reader["CustomerNo"]) + ")";
                customerNames[count] = name;
                count++;
            }
            connection.Close();
            return customerNames;
        }

        public static List<LineItem> getLineItems(int pOrderNo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            List<LineItem> items = new List<LineItem>();
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String selectStatement = "SELECT * FROM LINEITEM WHERE OrderNo = " + pOrderNo + ";";
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                LineItem temp = new LineItem();
                temp.pieceNo = Convert.ToInt32(reader["PieceNo"]);
                temp.sizeNo = Convert.ToInt32(reader["sizeNo"]);
                temp.patternNo = Convert.ToInt32(reader["PatternType"]);
                temp.quantity = Convert.ToInt32(reader["Quantity"]);
                temp.price = Convert.ToDecimal(reader["ItemPrice"]);
                temp.totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                temp.status = (LineItemStatus)Enum.Parse(typeof(LineItemStatus), Convert.ToString(reader["Status"]));
                temp.isGift = Convert.ToBoolean(reader["IsGift"]);
                temp.customizations = Convert.ToString(reader["Customizations"]);
                temp.cardMessage = Convert.ToString(reader["CardMessage"]);
                items.Add(temp);
            }
            connection.Close();
            return items;
        }

        public static List<Order> getOrders()
        {
            List<Order> orders = new List<Order>();
            OleDbConnection connection = new OleDbConnection(connectionString);
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            String selectStatement = "SELECT * FROM ORDERS;";
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                Order order = new Order();
                order.orderNo = Convert.ToInt32(reader["OrderNo"]);
                if (!DBNull.Value.Equals(reader["ShowNo"]))
                    order.showNo = Convert.ToInt32(reader["ShowNo"]);
                if (!DBNull.Value.Equals(reader["OrderDate"]))
                    order.orderDate = Convert.ToDateTime(reader["OrderDate"]);
                if (!DBNull.Value.Equals(reader["CustomerNo"]))
                    order.customerNo = Convert.ToInt32(reader["CustomerNo"]);
                if (!DBNull.Value.Equals(reader["Subtotal"]))
                    order.subtotal = Convert.ToDecimal(reader["Subtotal"]);
                if (!DBNull.Value.Equals(reader["Discount"]))
                    order.discount = Convert.ToDecimal(reader["Discount"]);
                if (!DBNull.Value.Equals(reader["NewSubtotal"]))
                    order.newSubtotal = Convert.ToDecimal(reader["NewSubtotal"]);
                if (!DBNull.Value.Equals(reader["Tax"]))
                    order.tax = Convert.ToDecimal(reader["Tax"]);
                if (!DBNull.Value.Equals(reader["Shipping"]))
                    order.shipping = Convert.ToDecimal(reader["Shipping"]);
                if (!DBNull.Value.Equals(reader["Total"]))
                    order.total = Convert.ToDecimal(reader["Total"]);
                if (!DBNull.Value.Equals(reader["PaymentType"]))
                    order.paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), Convert.ToString(reader["PaymentType"]));
                order.notes = Convert.ToString(reader["Notes"]);
                if (!DBNull.Value.Equals(reader["CheckNo"]))
                    order.checkNo = Convert.ToString(reader["CheckNo"]);
                order.taxable = Convert.ToBoolean(reader["Taxable"]);
                orders.Add(order);
            }
            connection.Close();
            return orders;
        }

        public static Order getOrderbyNumber(int pOrderNo)
        {
            Order order = new Order();
            order.orderNo = pOrderNo;
            OleDbConnection connection = new OleDbConnection(connectionString);
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
           
            String selectStatement = "SELECT * FROM ORDERS WHERE ORDERS.OrderNo = " + order.orderNo + ";";
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                if (!DBNull.Value.Equals(reader["ShowNo"]))
                    order.showNo = Convert.ToInt32(reader["ShowNo"]);
                if (!DBNull.Value.Equals(reader["OrderDate"]))
                    order.orderDate = Convert.ToDateTime(reader["OrderDate"]);
                if (!DBNull.Value.Equals(reader["CustomerNo"]))
                    order.customerNo = Convert.ToInt32(reader["CustomerNo"]);
                if (!DBNull.Value.Equals(reader["Subtotal"]))
                    order.subtotal = Convert.ToDecimal(reader["Subtotal"]);
                if (!DBNull.Value.Equals(reader["Discount"]))
                    order.discount = Convert.ToDecimal(reader["Discount"]);
                if (!DBNull.Value.Equals(reader["NewSubtotal"]))
                    order.newSubtotal = Convert.ToDecimal(reader["NewSubtotal"]);
                if (!DBNull.Value.Equals(reader["Tax"]))
                    order.tax = Convert.ToDecimal(reader["Tax"]);
                if (!DBNull.Value.Equals(reader["Shipping"]))
                    order.shipping = Convert.ToDecimal(reader["Shipping"]);
                if (!DBNull.Value.Equals(reader["Total"]))
                    order.total = Convert.ToDecimal(reader["Total"]);
                if (!DBNull.Value.Equals(reader["PaymentType"]))
                    order.paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), Convert.ToString(reader["PaymentType"]));
                order.notes = Convert.ToString(reader["Notes"]);
                if (!DBNull.Value.Equals(reader["CheckNo"]))
                    order.checkNo = Convert.ToString(reader["CheckNo"]);
                order.taxable = Convert.ToBoolean(reader["Taxable"]);
            }
            connection.Close();
            return order;
        }
        public static Pattern GetPatternByNo(int pPatternNo)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT  PATTERN.PatternNo, PATTERN.PatternName, PATTERN.PatternPicture.FileName, PATTERN.PatternPicture.FileData " +
                "FROM PATTERN WHERE PATTERN.PatternNo = " + pPatternNo;

            Pattern pattern = new Pattern();
            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                pattern.patternNo = Convert.ToInt32(reader["PatternNo"]);
                pattern.patternName = Convert.ToString(reader["PatternName"]);
                String fileName = Convert.ToString(reader["PATTERN.PatternPicture.FileName"]);
                if (fileName != "")
                {
                    byte[] image = GetImageBytesFromOLEField((byte[])reader["PATTERN.PatternPicture.FileData"]);
                    try
                    {
                        MemoryStream memStream = new MemoryStream(image);
                        pattern.patternPicture = new Bitmap(memStream);
                        //temp.patternPicture = new Bitmap(temp.patternPicture, new Size(100, 80));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    pattern.patternPicture = new Bitmap((System.Drawing.Image)(Resources.noimage));
                }
            }
            connection.Close();
            return pattern;
        }

        public static List<Pattern> GetPatterns()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT  PATTERN.PatternNo, PATTERN.PatternName, PATTERN.PatternPicture.FileName, PATTERN.PatternPicture.FileData " +
                "FROM PATTERN ORDER BY PatternName;";

            List<Pattern> patterns = new List<Pattern>();
            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                Pattern temp = new Pattern();
                temp.patternNo = Convert.ToInt32(reader["PatternNo"]);
                temp.patternName = Convert.ToString(reader["PatternName"]);
                String fileName = Convert.ToString(reader["PATTERN.PatternPicture.FileName"]);
                if (fileName != "")
                {
                    byte[] image = GetImageBytesFromOLEField((byte[])reader["PATTERN.PatternPicture.FileData"]);
                    try
                    {
                        MemoryStream memStream = new MemoryStream(image);
                        temp.patternPicture = new Bitmap(memStream);
                        //temp.patternPicture = new Bitmap(temp.patternPicture, new Size(100, 80));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    temp.patternPicture = new Bitmap((System.Drawing.Image)(Resources.noimage));
                }
                patterns.Add(temp);
            }
            connection.Close();
            return patterns;
        }

        public static CatalogPiece GetPieceByNo(int pPieceNo)
        {
            CatalogPiece piece = new CatalogPiece();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT  PIECE_CATALOG.PieceNo, PIECE_CATALOG.PieceName, PIECE_CATALOG.Description, PIECE_CATALOG.Picture.FileName, PIECE_CATALOG.Picture.FileData " +
                "FROM PIECE_CATALOG WHERE PIECE_CATALOG.PieceNo =" + pPieceNo;

            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                piece.pieceNo = Convert.ToInt32(reader["PieceNo"]);
                piece.pieceName = Convert.ToString(reader["PieceName"]);
                piece.description = Convert.ToString(reader["Description"]);
                string filename = Convert.ToString(reader["PIECE_CATALOG.Picture.FileName"]);
                if (filename != "")
                {
                    byte[] image = GetImageBytesFromOLEField((byte[])reader["PIECE_CATALOG.Picture.FileData"]);
                    try
                    {
                        MemoryStream memStream = new MemoryStream(image);
                        piece.picture = new Bitmap(memStream);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    piece.picture = new Bitmap((System.Drawing.Image)(Resources.noimage));
                }
                piece.sizeOptions = new List<CatalogPieceSize>();
                string subSelectStatement = "SELECT PIECE_SIZE.SizeNo, PIECE_SIZE.Dimensions, PIECE_SIZE.BasePrice, PIECE_SIZE.SizeDescription, PIECE_SIZE.TotalPounds " +
                       "FROM PIECE_SIZE WHERE PIECE_SIZE.PieceNo = " + piece.pieceNo + " ORDER BY SizeNo;";
                OleDbCommand subSelectCmd = new OleDbCommand(subSelectStatement, connection);
                //execute reader and close reader
                OleDbDataReader subReader = subSelectCmd.ExecuteReader();

                while (subReader.Read())
                {
                    CatalogPieceSize subTemp = new CatalogPieceSize();
                    subTemp.sizeNo = Convert.ToInt32(subReader["SizeNo"]);
                    subTemp.totalPounds = Convert.ToDecimal(subReader["TotalPounds"]);
                    subTemp.sizeDescription = Convert.ToString(subReader["SizeDescription"]);
                    subTemp.dimensions = Convert.ToString(subReader["Dimensions"]);
                    subTemp.basePrice = Convert.ToDecimal(subReader["BasePrice"]);
                    piece.sizeOptions.Add(subTemp);
                }
            }
            connection.Close();
            return piece;
        }

        public static List<CatalogPiece> GetPieces()
        {
            List<CatalogPiece> pieces = new List<CatalogPiece>();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT  PIECE_CATALOG.PieceNo, PIECE_CATALOG.PieceName, PIECE_CATALOG.Description, PIECE_CATALOG.Picture.FileName, PIECE_CATALOG.Picture.FileData " +
                "FROM PIECE_CATALOG ORDER BY PieceName;";

            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                CatalogPiece temp = new CatalogPiece();
                temp.pieceNo = Convert.ToInt32(reader["PieceNo"]);
                temp.pieceName = Convert.ToString(reader["PieceName"]);
                temp.description = Convert.ToString(reader["Description"]);
                string filename = Convert.ToString(reader["PIECE_CATALOG.Picture.FileName"]);
                if (filename != "")
                {
                    byte[] image = GetImageBytesFromOLEField((byte[])reader["PIECE_CATALOG.Picture.FileData"]);
                    try
                    {
                        MemoryStream memStream = new MemoryStream(image);
                        temp.picture = new Bitmap(memStream);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    temp.picture = new Bitmap((System.Drawing.Image)(Resources.noimage));
                }
                temp.sizeOptions = new List<CatalogPieceSize>();
                string subSelectStatement = "SELECT PIECE_SIZE.SizeNo, PIECE_SIZE.Dimensions, PIECE_SIZE.BasePrice, PIECE_SIZE.SizeDescription, PIECE_SIZE.TotalPounds " +
                       "FROM PIECE_SIZE WHERE PIECE_SIZE.PieceNo = " + temp.pieceNo + " ORDER BY SizeNo;";
                OleDbCommand subSelectCmd = new OleDbCommand(subSelectStatement, connection);
                //execute reader and close reader
                OleDbDataReader subReader = subSelectCmd.ExecuteReader();

                while (subReader.Read())
                {
                    CatalogPieceSize subTemp = new CatalogPieceSize();
                    subTemp.sizeNo = Convert.ToInt32(subReader["SizeNo"]);
                    subTemp.totalPounds = Convert.ToDecimal(subReader["TotalPounds"]);
                    subTemp.sizeDescription = Convert.ToString(subReader["SizeDescription"]);
                    subTemp.dimensions = Convert.ToString(subReader["Dimensions"]);
                    subTemp.basePrice = Convert.ToDecimal(subReader["BasePrice"]);
                    temp.sizeOptions.Add(subTemp);
                }
                pieces.Add(temp);
            }
            connection.Close();
            return pieces;
        }

        public static List<ShowType> GetShowTypes()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT SHOW_TYPE.ShowTypeNo, SHOW_TYPE.ShowTypeName " +
                "FROM SHOW_TYPE ORDER BY SHOW_TYPE.ShowTypeName;";

            List<ShowType> showTypes = new List<ShowType>();
            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                ShowType temp = new ShowType();
                temp.showTypeNo = Convert.ToInt32(reader["ShowTypeNo"]);
                temp.showTypeName = Convert.ToString(reader["ShowTypeName"]);
                showTypes.Add(temp);
            }
            connection.Close();
            return showTypes;
        }

        public static string getShowNameByNo(int showNo)
        {

            OleDbConnection connection = new OleDbConnection(connectionString);
            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            List<Customer> customers = new List<Customer>();

            String selectStatement = "SELECT ShowName FROM SHOW WHERE SHOW.ShowNo = " + showNo + ";";
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);
            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            string name ="";
            try
            {

                while (reader.Read())
                {
                    name = Convert.ToString(reader["ShowName"]);
                }
            }
            catch (DataException exp)
            {
                MessageBox.Show(exp.Message);
            }
            connection.Close();
            return name;
        }

        public static CatalogPieceSize GetPieceSizeByNo(int pPieceNo,int pSizeNo)
        {
            CatalogPieceSize size = new CatalogPieceSize();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            //Open connection if not already
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectStatement = "SELECT PIECE_SIZE.SizeNo, PIECE_SIZE.Dimensions, PIECE_SIZE.BasePrice, PIECE_SIZE.SizeDescription, PIECE_SIZE.TotalPounds " +
                       "FROM PIECE_SIZE WHERE PIECE_SIZE.PieceNo = " + pPieceNo + " AND PIECE_SIZE.SizeNo = " + pSizeNo;

            //Create Command for select statement
            OleDbCommand selectCmd = new OleDbCommand(selectStatement, connection);

            //execute reader and close reader
            OleDbDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                size.sizeNo = Convert.ToInt32(reader["SizeNo"]);
                size.totalPounds = Convert.ToDecimal(reader["TotalPounds"]);
                size.sizeDescription = Convert.ToString(reader["SizeDescription"]);
                size.dimensions = Convert.ToString(reader["Dimensions"]);
                size.basePrice = Convert.ToDecimal(reader["BasePrice"]);
            }
            connection.Close();
            return size;
        }

        //CODE FROM
        //http://blogs.msdn.com/b/pranab/archive/2008/07/15/removing-ole-header-from-images-stored-in-ms-access-db-as-ole-object.aspx
        private static byte[] GetImageBytesFromOLEField(byte[] oleFieldBytes)
        {

            const string BITMAP_ID_BLOCK = "BM";
            const string JPG_ID_BLOCK = "\u00FF\u00D8\u00FF";
            const string PNG_ID_BLOCK = "\u0089PNG\r\n\u001a\n";
            const string GIF_ID_BLOCK = "GIF8";
            const string TIFF_ID_BLOCK = "II*\u0000";
            byte[] imageBytes;

            // Get a UTF7 Encoded string version
            Encoding u8 = Encoding.UTF7;
            string strTemp = u8.GetString(oleFieldBytes);

            // Get the first 300 characters from the string
            string strVTemp = strTemp.Substring(0, 300);

            // Search for the block
            int iPos = -1;
            if (strVTemp.IndexOf(BITMAP_ID_BLOCK) != -1)
                iPos = strVTemp.IndexOf(BITMAP_ID_BLOCK);
            else if (strVTemp.IndexOf(JPG_ID_BLOCK) != -1)
                iPos = strVTemp.IndexOf(JPG_ID_BLOCK);
            else if (strVTemp.IndexOf(PNG_ID_BLOCK) != -1)
                iPos = strVTemp.IndexOf(PNG_ID_BLOCK);
            else if (strVTemp.IndexOf(GIF_ID_BLOCK) != -1)
                iPos = strVTemp.IndexOf(GIF_ID_BLOCK);
            else if (strVTemp.IndexOf(TIFF_ID_BLOCK) != -1)
                iPos = strVTemp.IndexOf(TIFF_ID_BLOCK);
            else
                throw new Exception("Unable to determine header size for the OLE Object");

            // From the position above get the new image
            if (iPos == -1)
                throw new Exception("Unable to determine header size for the OLE Object");

            //Array.Copy(
            imageBytes = new byte[oleFieldBytes.LongLength - iPos];
            MemoryStream ms = new MemoryStream();
            ms.Write(oleFieldBytes, iPos, oleFieldBytes.Length - iPos);
            imageBytes = ms.ToArray();
            ms.Close();
            ms.Dispose();
            return imageBytes;


        }

    }
}
