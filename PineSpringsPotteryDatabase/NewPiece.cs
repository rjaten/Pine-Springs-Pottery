using Microsoft.Office.Interop.Access.Dao;
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
    public partial class NewPiece : Form
    {
        //instance variables
        private string connectionString;        //connection to database
        private OleDbConnection connection;
        private Form parent;                    //form that called this one
        private CatalogPiece currentPiece;      //current piece info 
        private String fileName;                //filename of imported photo
        private List<NumericUpDown> nudPounds;        //list of textboxes to enter in info for sizes of current piece
        private List<TextBox> txtDimensions;
        private List<TextBox> txtDescriptions;
        private List<NumericUpDown> nudPrices;
        private List<Label> lblDeletes;         //labels for deleting extra size options
        private int sizeCount;                  //number of size options

        //Constructor
        public NewPiece(Form pParent, CatalogPiece pPiece)
        {
            //assign parameters
            parent = pParent;
            currentPiece = pPiece;
            //instatiate
            nudPounds = new List<NumericUpDown>();
            txtDimensions = new List<TextBox>();
            txtDescriptions = new List<TextBox>();
            nudPrices = new List<NumericUpDown>();
            lblDeletes = new List<Label>();
            fileName = "";
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            connection = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        //onLoad
        private void NewPiece_Load(object sender, EventArgs e)
        {
            //make sure first row (headers) stays small
            tableAddSizes.RowStyles[0].Height = 30;
            //start size options count at 0
            sizeCount = 0;
            //if existing piece, display information
            if (currentPiece.pieceNo != 0)
            {
                pbxNewPiecePicture.Image = currentPiece.picture;
                txtPieceName.Text = currentPiece.pieceName;
                txtDescription.Text = currentPiece.description;
                ShowSizes();
                btnAddPiece.Text = "Save Edit";
            }
            //new piece
            else
            {
                sizeCount++;
                AddRow(sizeCount, new CatalogPieceSize());
            }
        }

        //Add picture to imagebox from selected file
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pbxNewPiecePicture.Image = new Bitmap(open.FileName);
                // image file path
                //fileName = Path.GetFileName(open.FileName);
                fileName = open.FileName;
            } 
        }

        //remove picture from imagebox
        private void btnRemovePicture_Click(object sender, EventArgs e)
        {
            pbxNewPiecePicture.Image = null;
            fileName = "delete";                //flag to remove picture from database
        }

        //Display size options of piece being edited
        private void ShowSizes()
        {
            foreach (CatalogPieceSize size in currentPiece.sizeOptions)
            {
                sizeCount++;
                //adds a row of textboxes with all information
                AddRow(sizeCount, size);
            }
        }

        //Add a new row to size options
        private void AddRow(int rowCount, CatalogPieceSize pSize)
        {
            //new row and formatting for table
            RowStyle style = new RowStyle();
            style.SizeType = SizeType.AutoSize;
            style.Height = 30;
            tableAddSizes.RowStyles.Add(style);
            tableAddSizes.RowCount++;
            //Pounds NUD
            NumericUpDown tempnud = new NumericUpDown();
            tempnud.Width = 75;
            tempnud.DecimalPlaces = 2;
            tempnud.Maximum = 100;
            tempnud.Focus();
            tempnud.Value = pSize.totalPounds;
            nudPounds.Insert(rowCount - 1, tempnud);
            tableAddSizes.Controls.Add(nudPounds[rowCount-1], 0, rowCount);
            //Dimensions Text
            TextBox temp = new TextBox();
            temp.Width = 155;
            temp.MaxLength = 255;
            temp.Text = pSize.dimensions;
            txtDimensions.Insert(rowCount - 1, temp);
            tableAddSizes.Controls.Add(txtDimensions[rowCount - 1], 1, rowCount);
            //Descriptions Text
            temp = new TextBox();
            temp.Width = 150;
            temp.MaxLength = 255;
            temp.Text = pSize.sizeDescription;
            txtDescriptions.Insert(rowCount - 1, temp);
            tableAddSizes.Controls.Add(txtDescriptions[rowCount - 1], 2, rowCount);
            //Prices NUD
            tempnud = new NumericUpDown();
            tempnud.Width = 85;
            tempnud.DecimalPlaces = 2;
            tempnud.Maximum = 100000;
            tempnud.Value = pSize.basePrice;
            nudPrices.Insert(rowCount - 1, tempnud);
            tableAddSizes.Controls.Add(nudPrices[rowCount - 1], 3, rowCount);
            //Delete Button
            Label delete = new Label();
            delete.ForeColor = Color.DarkRed;
            delete.Text = "X";
            delete.Click += new EventHandler(this.DeleteRow_Click);
            if (rowCount == 1)
            {
                delete.Visible = false;
            }
            lblDeletes.Insert(rowCount - 1, delete);
            //add row to table
            tableAddSizes.Controls.Add(lblDeletes[rowCount - 1], 4, rowCount);

        }

        //Delete rowfrom size options
        private void DeleteRow_Click(object sender, EventArgs e)
        {
            //decrease number of size options
            sizeCount--;
            //fins out which row the delete action happened in
            TableLayoutPanelCellPosition pos = tableAddSizes.GetPositionFromControl((Label)sender);
            int rowIndex = pos.Row;

            //remove all contents in that row
            for (int columnIndex = 0; columnIndex < tableAddSizes.ColumnCount; columnIndex++)
            {
                var control = tableAddSizes.GetControlFromPosition(columnIndex, rowIndex);
                tableAddSizes.Controls.Remove(control);
            }

            //move lower rows up
            for (int i = rowIndex + 1; i < tableAddSizes.RowCount; i++)
            {
                for (int columnIndex = 0; columnIndex < tableAddSizes.ColumnCount; columnIndex++)
                {
                    var control = tableAddSizes.GetControlFromPosition(columnIndex, i);
                    tableAddSizes.SetRow(control, i - 1);
                }
            }
            //decrease the tables row count
            tableAddSizes.RowCount--;

            //remove input controls from lists
            nudPounds.RemoveAt(rowIndex - 1);
            txtDimensions.RemoveAt(rowIndex - 1);
            txtDescriptions.RemoveAt(rowIndex - 1);
            nudPrices.RemoveAt(rowIndex - 1);
            lblDeletes.RemoveAt(rowIndex - 1);


        }

        //Button Action to Add a row
        private void btnAddSize_Click(object sender, EventArgs e)
        {
            sizeCount++;
            //empty row
            AddRow(sizeCount, new CatalogPieceSize());
        }

        //add or update piece
        private void btnAddPiece_Click(object sender, EventArgs e)
        {
            //require piece name
            if (txtPieceName.Text == "")
            {
                MessageBox.Show("Piece Name is required");
            }
            else
            {
                //add new piece
                if (currentPiece.pieceNo == 0)
                {
                    insertNewPiece();
                }
                //update current piece
                else
                {
                    updatePiece();
                }
            }
        }

        //Insert new piece into database
        private void insertNewPiece()
        {
            //connect to database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //insert and get newest primary key
            String insert = @"INSERT INTO PIECE_CATALOG (PieceName,Description) VALUES (@PieceName, @Description);";
            string getnewpk = "Select @@Identity";
            OleDbCommand cmd = new OleDbCommand(insert, connection);
            cmd.Parameters.AddWithValue("@PieceName", txtPieceName.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = getnewpk;
            currentPiece.pieceNo = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            //add picture if picture exists
            insertPicture();

            //add piece sizes
            insertPieceSizes();


            //make catalog show new info
            if (parent.GetType() == typeof(Catalog))
            {
                ((Catalog)parent).refreshPieces();
            }
            parent.Enabled = true;
            this.Close();    
        }

        //Update changes to current piece
        private void updatePiece()
        {
            //open connection
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            // update piece info
            String update = @"UPDATE PIECE_CATALOG Set PieceName = @PieceName, Description = @Description WHERE PieceNo = @PieceNo";
            OleDbCommand cmd = new OleDbCommand(update, connection);
            cmd.Parameters.AddWithValue("@PieceName", txtPieceName.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@PieceNo", currentPiece.pieceNo);
            cmd.ExecuteNonQuery();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            //add picture if picture exists
            insertPicture();

            //delete current size options
            String delete = @"DELETE FROM PIECE_SIZE WHERE PIECE_SIZE.PieceNo = " + currentPiece.pieceNo;
            cmd.CommandText = delete;
            cmd.ExecuteNonQuery();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            connection.Close();

            //add updated size options
            insertPieceSizes();

            //force parent to refresh options
            if (parent.GetType() == typeof(Catalog))
            {
                ((Catalog)parent).refreshPieces();
            }
            parent.Enabled = true;
            this.Close();
        }

        //Insert piece sizes into database
        public void insertPieceSizes()
        {
            //connect to db
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //make insert for each row 
                String insert;
                for (int i = 0; i < nudPounds.Count; i++)
                {
                    insert = @"INSERT INTO PIECE_SIZE (PieceNo, SizeNo, TotalPounds, Dimensions, SizeDescription, BasePrice) VALUES (@PieceNo, @SizeNo, @TotalPounds, @Dimensions, @SizeDescription, @BasePrice);";

                    OleDbCommand cmd = new OleDbCommand(insert, connection);
                    cmd.Parameters.AddWithValue("@PieceNo", currentPiece.pieceNo);
                    cmd.Parameters.AddWithValue("@SizeNo", i + 1);
                    Decimal dec = ((NumericUpDown)tableAddSizes.GetControlFromPosition(0, i + 1)).Value;
                    cmd.Parameters.AddWithValue("@TotalPounds", dec);
                    String text = ((TextBox)tableAddSizes.GetControlFromPosition(1, i + 1)).Text;
                    cmd.Parameters.AddWithValue("@Dimensions", text);
                    text = ((TextBox)tableAddSizes.GetControlFromPosition(2, i + 1)).Text;
                    cmd.Parameters.AddWithValue("@SizeDescripition", text);
                    dec = ((NumericUpDown)tableAddSizes.GetControlFromPosition(3, i + 1)).Value;
                    cmd.Parameters.AddWithValue("@BasePrice", dec);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
                connection.Close();
           
        }

        //Add/Update Photo in DB
        private void insertPicture()
        {
            if (fileName != "")
            {
                //code from http://stackoverflow.com/questions/779211/programmatically-managing-microsoft-access-attachment-typed-field-with-net
                DBEngine dbe = new DBEngine();
                Database db = dbe.OpenDatabase("PineSpringsPottery.accdb", false, false, "");
                Recordset rs = db.OpenRecordset("SELECT * FROM PIECE_CATALOG WHERE PIECE_CATALOG.PieceNo = " + currentPiece.pieceNo, RecordsetTypeEnum.dbOpenDynaset, 0, LockTypeEnum.dbOptimistic);
                rs.MoveFirst();
                rs.Edit();
                Recordset2 rs2 = (Recordset2)rs.Fields["Picture"].Value;
                //delete any existing photos - just have one photo per piece
                if (rs2.RecordCount != 0)
                    rs2.Delete();
                //if not just deleting photo, add new one
                if (fileName != "delete")
                {
                    rs2.AddNew();
                    Field2 f2 = (Field2)rs2.Fields["FileData"];
                    f2.LoadFromFile(fileName);
                    rs2._30_Update();
                }
                rs2.Close();
                rs._30_Update();
                rs.Close();
            }
        }

        //Make no changes and close form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Close();
        }

        //if x clicked, enable catalog again
        private void NewPiece_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
    }
}
