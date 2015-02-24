namespace PineSpringsPotteryDatabase
{
    partial class NewPiece
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPiece));
            this.lblPieceName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPieceName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnRemovePicture = new System.Windows.Forms.Button();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.pbxNewPiecePicture = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPiece = new System.Windows.Forms.Button();
            this.tableAddSizes = new System.Windows.Forms.TableLayoutPanel();
            this.lblPounds = new System.Windows.Forms.Label();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.lblSizeDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnAddSize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewPiecePicture)).BeginInit();
            this.tableAddSizes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPieceName
            // 
            this.lblPieceName.AutoSize = true;
            this.lblPieceName.Location = new System.Drawing.Point(22, 22);
            this.lblPieceName.Name = "lblPieceName";
            this.lblPieceName.Size = new System.Drawing.Size(68, 13);
            this.lblPieceName.TabIndex = 0;
            this.lblPieceName.Text = "Piece Name:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(21, 47);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // txtPieceName
            // 
            this.txtPieceName.Location = new System.Drawing.Point(97, 14);
            this.txtPieceName.MaxLength = 50;
            this.txtPieceName.Name = "txtPieceName";
            this.txtPieceName.Size = new System.Drawing.Size(176, 20);
            this.txtPieceName.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(97, 41);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(176, 108);
            this.txtDescription.TabIndex = 2;
            // 
            // btnRemovePicture
            // 
            this.btnRemovePicture.Location = new System.Drawing.Point(156, 372);
            this.btnRemovePicture.Name = "btnRemovePicture";
            this.btnRemovePicture.Size = new System.Drawing.Size(85, 40);
            this.btnRemovePicture.TabIndex = 4;
            this.btnRemovePicture.Text = "Remove Picture";
            this.btnRemovePicture.UseVisualStyleBackColor = true;
            this.btnRemovePicture.Click += new System.EventHandler(this.btnRemovePicture_Click);
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(50, 372);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(85, 37);
            this.btnAddPicture.TabIndex = 3;
            this.btnAddPicture.Text = "Add/Change Picture";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // pbxNewPiecePicture
            // 
            this.pbxNewPiecePicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbxNewPiecePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxNewPiecePicture.Location = new System.Drawing.Point(25, 166);
            this.pbxNewPiecePicture.Name = "pbxNewPiecePicture";
            this.pbxNewPiecePicture.Size = new System.Drawing.Size(250, 200);
            this.pbxNewPiecePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxNewPiecePicture.TabIndex = 5;
            this.pbxNewPiecePicture.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(389, 434);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 101;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddPiece
            // 
            this.btnAddPiece.Location = new System.Drawing.Point(283, 434);
            this.btnAddPiece.Name = "btnAddPiece";
            this.btnAddPiece.Size = new System.Drawing.Size(75, 23);
            this.btnAddPiece.TabIndex = 100;
            this.btnAddPiece.Text = "Add Piece";
            this.btnAddPiece.UseVisualStyleBackColor = true;
            this.btnAddPiece.Click += new System.EventHandler(this.btnAddPiece_Click);
            // 
            // tableAddSizes
            // 
            this.tableAddSizes.AutoScroll = true;
            this.tableAddSizes.ColumnCount = 5;
            this.tableAddSizes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableAddSizes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableAddSizes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableAddSizes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableAddSizes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableAddSizes.Controls.Add(this.lblPounds, 0, 0);
            this.tableAddSizes.Controls.Add(this.lblDimensions, 1, 0);
            this.tableAddSizes.Controls.Add(this.lblSizeDescription, 2, 0);
            this.tableAddSizes.Controls.Add(this.lblPrice, 3, 0);
            this.tableAddSizes.Location = new System.Drawing.Point(297, 47);
            this.tableAddSizes.Name = "tableAddSizes";
            this.tableAddSizes.RowCount = 1;
            this.tableAddSizes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 362F));
            this.tableAddSizes.Size = new System.Drawing.Size(464, 362);
            this.tableAddSizes.TabIndex = 10;
            // 
            // lblPounds
            // 
            this.lblPounds.AutoSize = true;
            this.lblPounds.Location = new System.Drawing.Point(3, 0);
            this.lblPounds.Name = "lblPounds";
            this.lblPounds.Size = new System.Drawing.Size(58, 26);
            this.lblPounds.TabIndex = 2;
            this.lblPounds.Text = "Pounds of Clay";
            // 
            // lblDimensions
            // 
            this.lblDimensions.AutoSize = true;
            this.lblDimensions.Location = new System.Drawing.Point(78, 0);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(61, 13);
            this.lblDimensions.TabIndex = 3;
            this.lblDimensions.Text = "Dimensions";
            // 
            // lblSizeDescription
            // 
            this.lblSizeDescription.AutoSize = true;
            this.lblSizeDescription.Location = new System.Drawing.Point(193, 0);
            this.lblSizeDescription.Name = "lblSizeDescription";
            this.lblSizeDescription.Size = new System.Drawing.Size(83, 13);
            this.lblSizeDescription.TabIndex = 4;
            this.lblSizeDescription.Text = "Size Description";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(343, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Price ";
            // 
            // btnAddSize
            // 
            this.btnAddSize.Location = new System.Drawing.Point(473, 11);
            this.btnAddSize.Name = "btnAddSize";
            this.btnAddSize.Size = new System.Drawing.Size(75, 23);
            this.btnAddSize.TabIndex = 99;
            this.btnAddSize.Text = "Add Size";
            this.btnAddSize.UseVisualStyleBackColor = true;
            this.btnAddSize.Click += new System.EventHandler(this.btnAddSize_Click);
            // 
            // NewPiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 469);
            this.Controls.Add(this.btnAddSize);
            this.Controls.Add(this.tableAddSizes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddPiece);
            this.Controls.Add(this.btnRemovePicture);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.pbxNewPiecePicture);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPieceName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPieceName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewPiece";
            this.Text = "Add/ Edit Piece";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewPiece_FormClosing);
            this.Load += new System.EventHandler(this.NewPiece_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewPiecePicture)).EndInit();
            this.tableAddSizes.ResumeLayout(false);
            this.tableAddSizes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPieceName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtPieceName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnRemovePicture;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.PictureBox pbxNewPiecePicture;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddPiece;
        private System.Windows.Forms.TableLayoutPanel tableAddSizes;
        private System.Windows.Forms.Label lblPounds;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.Label lblSizeDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnAddSize;
    }
}