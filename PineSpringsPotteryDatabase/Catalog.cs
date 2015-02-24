using PineSpringsPotteryDatabase.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PineSpringsPotteryDatabase
{
    public partial class Catalog : Form
    {

        //Instance Variables
        private List<CatalogPiece> pieces;
        private List<Pattern> patterns;
        private int selectedPiece;
        private int selectedSize;
        private int selectedPattern;
        private Form parent;
        private LineItem selectedItem;
        private NewPiece addeditPiece;
        private NewPattern addEditPattern;

        //Constructor
        public Catalog(Form pParent)
        {
            InitializeComponent();
            parent = pParent;
            pieces = new List<CatalogPiece>();
            patterns = new List<Pattern>();
            selectedPiece = 0;
            selectedSize = 0;
            selectedPattern = 0;
        }

        //onload
        private void Catalog_Load(object sender, EventArgs e)
        {
            //only show extra options and add to list button if called by show, wishlist, order
            if (parent.GetType() != typeof(NewOrder) && parent.GetType() != typeof(ViewWishList) && parent.GetType() != typeof(NewShow))
            {
                pnlLineItem.Visible = false;
            }

            //wishlist options
            if(parent.GetType() == typeof(ViewWishList))
            {
                txtCardMessage.Visible = false;
                lblCardMessage.Visible = false;
                cbxGift.Visible = false;
                nudCustomPrice.Visible = false;
                cbCustomPrice.Visible = false;
                btnAddItem.Text = "Add To Wishlist";
            }
                //show options
            else if (parent.GetType() == typeof(NewShow))
            {
                txtCardMessage.Visible = false;
                lblCardMessage.Visible = false;
                cbxGift.Visible = false;
                nudCustomPrice.Visible = false;
                cbCustomPrice.Visible = false;
                btnAddItem.Text = "Add To Show";
            }
             //order options
            else
            {
                btnAddItem.Text = "Add To Order";
            }
            //get and show pices and patterns
            patterns = DatabaseAccess.GetPatterns();
            pieces = DatabaseAccess.GetPieces();
            ShowPieces();
            ShowPatterns();
        }

        //make sorted list of pieces
        public SortedList<int, CatalogPiece> GetPieceSortedList()
        {
            pieces = DatabaseAccess.GetPieces();
            SortedList<int, CatalogPiece> tempPieces = new SortedList<int, CatalogPiece>();
            foreach (CatalogPiece piece in pieces)
            {
                tempPieces.Add(piece.pieceNo, piece);
            }
            return tempPieces;
        }

        //make sorted list of patterns
        public SortedList<int, Pattern> GetPatternSortedList()
        {
            patterns = DatabaseAccess.GetPatterns();
            SortedList<int, Pattern> tempPatterns = new SortedList<int, Pattern>();
            foreach (Pattern pattern in patterns)
            {
                tempPatterns.Add(pattern.patternNo, pattern);
            }
            return tempPatterns;
        }

        //refresh pieces if one is added
        public void refreshPieces()
        {
            pieces = DatabaseAccess.GetPieces();
            ShowPieces();
        }

        //add pieces to listbox
        public void ShowPieces()
        {
           lbxPieces.DataSource = pieces;
        }

        //refresh patterns if one is added
        public void refreshPatterns()
        {
            patterns = DatabaseAccess.GetPatterns();
            ShowPatterns();
        }

        //add patterns to listbox
        public void ShowPatterns()
        {
            lbxPatterns.DataSource = patterns;
        }

        //display details of current selection
        private void displaySelection()
        {
            lblPieceName.Text = pieces[selectedPiece].pieceName;
            lblSize.Text = pieces[selectedPiece].sizeOptions[selectedSize].dimensions;
            lblPounds.Text = pieces[selectedPiece].sizeOptions[selectedSize].totalPounds.ToString();
            lblPrice.Text = string.Format("{0:C}", pieces[selectedPiece].sizeOptions[selectedSize].basePrice);
            lblDescription.Text = pieces[selectedPiece].description + '\n' + pieces[selectedPiece].sizeOptions[selectedSize].sizeDescription;
            lblPattern.Text = patterns[selectedPattern].patternName;

        }

        //get selected options and pass item to parent
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            selectedItem.pieceNo = pieces[selectedPiece].pieceNo;
            selectedItem.sizeNo = pieces[selectedPiece].sizeOptions[selectedSize].sizeNo;
            selectedItem.patternNo = patterns[selectedPattern].patternNo;
            selectedItem.quantity = (int)nudQuantity.Value;
            selectedItem.isGift = cbxGift.Checked;
            selectedItem.cardMessage = txtCardMessage.Text;
            if(cbCustomPrice.Checked)
                selectedItem.price = nudCustomPrice.Value;
            else
                selectedItem.price = pieces[selectedPiece].sizeOptions[selectedSize].basePrice;

            selectedItem.totalPrice = selectedItem.quantity * selectedItem.price;
            selectedItem.customizations = txtCustomizations.Text;
            if (parent.GetType() == typeof(NewOrder))
            {
                ((NewOrder)parent).addLineItem(selectedItem);
            }
            else if (parent.GetType() == typeof(ViewWishList))
            {
                ((ViewWishList)parent).getWishListItem(selectedItem);
            }
            else if (parent.GetType() == typeof(NewShow))
            {
                ((NewShow)parent).getShowPieceTaken(selectedItem);
            }
            this.Close();
        }

        //show form to add new pattern
        private void newPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addEditPattern == null || addEditPattern.IsDisposed)
                addEditPattern = new NewPattern(this, new Pattern());
            this.Enabled = false;
            addEditPattern.Show();
        }

        //show form to edit pattern
        private void patternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addEditPattern == null || addEditPattern.IsDisposed)
                addEditPattern = new NewPattern(this, patterns[selectedPattern]);
            this.Enabled = false;
            addEditPattern.Show();
        }

        //show form to add a piece
        private void newPieceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(addeditPiece == null || addeditPiece.IsDisposed)
                addeditPiece = new NewPiece(this, new CatalogPiece());
            this.Enabled = false;
            addeditPiece.Show();
        }

        //show form to edit piece
        private void selectedPieceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(addeditPiece == null || addeditPiece.IsDisposed)
                addeditPiece = new NewPiece(this, pieces[selectedPiece]);
            this.Enabled = false;
            addeditPiece.Show();
        }

        //change selected piece and display correct sizes
        private void lbxPieces_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPiece = pieces.FindIndex(piece => piece.pieceName == ((ListBox)sender).SelectedValue.ToString());
            lbxSizes.DataSource = pieces[selectedPiece].sizeOptions;
            displaySelection();
            pbxPiece.Image = pieces[selectedPiece].picture;
        }

        //only show pieces of search criteria
        private void txtPieceSearch_TextChanged(object sender, EventArgs e)
        {
            List<string> newlist = new List<string>();
            for (int i = 0; i < pieces.Count; i++)
            {
                if(pieces[i].pieceName.ToLower().Contains(txtPieceSearch.Text.ToLower()))
                {
                    newlist.Add(pieces[i].pieceName);
                }
            }
            lbxPieces.DataSource = newlist;

        }

        //change selected size
        private void lbxSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSize = ((ListBox)sender).SelectedIndex;
            displaySelection();
        }
        
        //change selected pattern 
        private void lbxPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPattern = patterns.FindIndex(pattern => pattern.patternName == ((ListBox)sender).SelectedValue.ToString());
            pbxPattern.Image = patterns[selectedPattern].patternPicture;
            displaySelection();
        }

        //only show patterns that fit search
        private void txtPatternSearch_TextChanged(object sender, EventArgs e)
        {
            List<string> newlist = new List<string>();
            for (int i = 0; i < patterns.Count; i++)
            {
                if (patterns[i].patternName.ToLower().Contains(txtPatternSearch.Text.ToLower()))
                {
                    newlist.Add(patterns[i].patternName);
                }
            }
            lbxPatterns.DataSource = newlist;
        }


    }
}
