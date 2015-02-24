namespace PineSpringsPotteryDatabase
{
    partial class ViewWishList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewWishList));
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.WishlistItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PieceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatternName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customizations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(24, 164);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(56, 19);
            this.btnAddItem.TabIndex = 53;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(7, 17);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(85, 13);
            this.lblCustomer.TabIndex = 54;
            this.lblCustomer.Text = "Customer Name:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(96, 15);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(141, 20);
            this.txtCustomer.TabIndex = 55;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(486, 164);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(56, 19);
            this.btnBack.TabIndex = 56;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(250, 164);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(92, 19);
            this.btnRemoveItem.TabIndex = 57;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WishlistItemNo,
            this.PieceName,
            this.PatternName,
            this.TotalPounds,
            this.Customizations,
            this.Quantity,
            this.WishDate});
            this.dataGridView1.Location = new System.Drawing.Point(10, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(564, 122);
            this.dataGridView1.TabIndex = 58;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // WishlistItemNo
            // 
            this.WishlistItemNo.HeaderText = "Item No";
            this.WishlistItemNo.Name = "WishlistItemNo";
            this.WishlistItemNo.ReadOnly = true;
            this.WishlistItemNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PieceName
            // 
            this.PieceName.HeaderText = "Piece Name";
            this.PieceName.Name = "PieceName";
            this.PieceName.ReadOnly = true;
            this.PieceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PatternName
            // 
            this.PatternName.HeaderText = "Pattern Name";
            this.PatternName.Name = "PatternName";
            this.PatternName.ReadOnly = true;
            this.PatternName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalPounds
            // 
            this.TotalPounds.HeaderText = "Clay Size";
            this.TotalPounds.Name = "TotalPounds";
            this.TotalPounds.ReadOnly = true;
            this.TotalPounds.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Customizations
            // 
            this.Customizations.HeaderText = "Customizations";
            this.Customizations.Name = "Customizations";
            this.Customizations.ReadOnly = true;
            this.Customizations.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Customizations.Width = 105;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WishDate
            // 
            this.WishDate.HeaderText = "Date Wished";
            this.WishDate.Name = "WishDate";
            this.WishDate.ReadOnly = true;
            this.WishDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ViewWishList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 193);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnAddItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewWishList";
            this.Text = "Wish List";
            this.Load += new System.EventHandler(this.WishList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WishlistItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PieceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatternName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customizations;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn WishDate;
    }
}