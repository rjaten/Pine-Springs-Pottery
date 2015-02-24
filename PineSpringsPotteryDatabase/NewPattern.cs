using Microsoft.Office.Interop.Access.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class NewPattern : Form
    {
        //instance variables
        private string connectionString;        //connection to db
        private OleDbConnection connection;
        private Form parent;                    //form that called this one
        private Pattern currentPattern;         //current pattern beign edited
        private String fileName;                //filename to photo uploaded

        //Constructor
        public NewPattern(Form pParent, Pattern pPattern)
        {
            parent = pParent;
            currentPattern = pPattern;
            fileName = "";
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\PineSpringsPottery.accdb";
            connection = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        //onLoad
        private void NewPattern_Load(object sender, EventArgs e)
        {
            //display current pattern info if not a new pattern
            if (currentPattern.patternNo != 0)
            {
                pbxNewPatternPicture.Image = currentPattern.patternPicture;
                txtPatternName.Text = currentPattern.patternName;
            }
        }

        //Close and make no changes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Close();
        }

        //Add picture to picbox loaded from selected file
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pbxNewPatternPicture.Image = new Bitmap(open.FileName);
                // image file path
                fileName = open.FileName;
            } 
        }

        //Remove photo
        private void btnRemovePicture_Click(object sender, EventArgs e)
        {
            pbxNewPatternPicture.Image = null;
            //flag to removecurrent photo from db
            fileName = "delete";
        }

        //Add/Edit Pattern
        private void btnAddPattern_Click(object sender, EventArgs e)
        {
            //require pattern name
            if (txtPatternName.Text == "")
            {
                MessageBox.Show("Pattern Name is required");
            }
            else
            {
                //new pattern
                if (currentPattern.patternNo == 0)
                {
                    insertNewPattern();
                }
                //editing current pattern
                else
                {
                    updatePattern();
                }
            }
        }

        //Add new Pattern
        private void insertNewPattern()
        {
            //connect to db
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //insert and get the newly generated PK
            String insert = @"INSERT INTO PATTERN (PatternName) VALUES (@PatternName);";
            string getnewpk = "Select @@Identity";
            OleDbCommand cmd = new OleDbCommand(insert, connection);
            cmd.Parameters.AddWithValue("@PatternName", txtPatternName.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = getnewpk;
            currentPattern.patternNo = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            //update photo
            insertPicture();

            //force catalog to show changes
            if (parent.GetType() == typeof(Catalog))
            {
                ((Catalog)parent).refreshPatterns();
            }
            parent.Enabled = true;
            this.Close();
            
        }

        //Edit existing Pattern
        private void updatePattern()
        {
            //connect to db
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //update pattern
            String insert = @"UPDATE PATTERN Set PatternName = @PatternName WHERE PatternNo = @PatternNo";
            OleDbCommand cmd = new OleDbCommand(insert, connection);
            cmd.Parameters.AddWithValue("@PatternName", txtPatternName.Text);
            cmd.Parameters.AddWithValue("@PatternNo", currentPattern.patternNo);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            connection.Close();

            //update photo
            insertPicture();

            //force catalog to show changes
            if (parent.GetType() == typeof(Catalog))
            {
                ((Catalog)parent).refreshPatterns();
            }
            parent.Enabled = true;
                this.Close();
        }

        //enable Catalog when X is clicked
        private void NewPattern_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }

        //Update Photo in DB
        private void insertPicture()
        {
            if (fileName != "")
            {
                //code from http://stackoverflow.com/questions/779211/programmatically-managing-microsoft-access-attachment-typed-field-with-net
                DBEngine dbe = new DBEngine();
                Database db = dbe.OpenDatabase("PineSpringsPottery.accdb", false, false, "");
                Recordset rs = db.OpenRecordset("SELECT * FROM PATTERN WHERE PATTERN.PatternNo = " + currentPattern.patternNo, RecordsetTypeEnum.dbOpenDynaset, 0, LockTypeEnum.dbOptimistic);
                rs.MoveFirst();
                rs.Edit();
                Recordset2 rs2 = (Recordset2)rs.Fields["PatternPicture"].Value;
                //delete previous pics
                if (rs2.RecordCount != 0)
                    rs2.Delete();
                //if not just deleting previous, add new
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
    }
}
