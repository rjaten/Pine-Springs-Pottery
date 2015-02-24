namespace PineSpringsPotteryDatabase
{
    partial class NewPattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPattern));
            this.pbxNewPatternPicture = new System.Windows.Forms.PictureBox();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.btnAddPattern = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemovePicture = new System.Windows.Forms.Button();
            this.lblPatternName = new System.Windows.Forms.Label();
            this.txtPatternName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewPatternPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxNewPatternPicture
            // 
            this.pbxNewPatternPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbxNewPatternPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxNewPatternPicture.Location = new System.Drawing.Point(24, 55);
            this.pbxNewPatternPicture.Name = "pbxNewPatternPicture";
            this.pbxNewPatternPicture.Size = new System.Drawing.Size(250, 200);
            this.pbxNewPatternPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxNewPatternPicture.TabIndex = 0;
            this.pbxNewPatternPicture.TabStop = false;
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(289, 55);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(83, 37);
            this.btnAddPicture.TabIndex = 1;
            this.btnAddPicture.Text = "Add/Change Picture";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // btnAddPattern
            // 
            this.btnAddPattern.Location = new System.Drawing.Point(108, 276);
            this.btnAddPattern.Name = "btnAddPattern";
            this.btnAddPattern.Size = new System.Drawing.Size(75, 23);
            this.btnAddPattern.TabIndex = 2;
            this.btnAddPattern.Text = "Add/Edit Pattern";
            this.btnAddPattern.UseVisualStyleBackColor = true;
            this.btnAddPattern.Click += new System.EventHandler(this.btnAddPattern_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(215, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRemovePicture
            // 
            this.btnRemovePicture.Location = new System.Drawing.Point(289, 98);
            this.btnRemovePicture.Name = "btnRemovePicture";
            this.btnRemovePicture.Size = new System.Drawing.Size(83, 36);
            this.btnRemovePicture.TabIndex = 4;
            this.btnRemovePicture.Text = "Remove Picture";
            this.btnRemovePicture.UseVisualStyleBackColor = true;
            this.btnRemovePicture.Click += new System.EventHandler(this.btnRemovePicture_Click);
            // 
            // lblPatternName
            // 
            this.lblPatternName.AutoSize = true;
            this.lblPatternName.Location = new System.Drawing.Point(12, 20);
            this.lblPatternName.Name = "lblPatternName";
            this.lblPatternName.Size = new System.Drawing.Size(75, 13);
            this.lblPatternName.TabIndex = 5;
            this.lblPatternName.Text = "Pattern Name:";
            // 
            // txtPatternName
            // 
            this.txtPatternName.Location = new System.Drawing.Point(93, 17);
            this.txtPatternName.MaxLength = 30;
            this.txtPatternName.Name = "txtPatternName";
            this.txtPatternName.Size = new System.Drawing.Size(116, 20);
            this.txtPatternName.TabIndex = 6;
            // 
            // NewPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 314);
            this.Controls.Add(this.txtPatternName);
            this.Controls.Add(this.lblPatternName);
            this.Controls.Add(this.btnRemovePicture);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddPattern);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.pbxNewPatternPicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewPattern";
            this.Text = "NewPattern";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewPattern_FormClosing);
            this.Load += new System.EventHandler(this.NewPattern_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewPatternPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxNewPatternPicture;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.Button btnAddPattern;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemovePicture;
        private System.Windows.Forms.Label lblPatternName;
        private System.Windows.Forms.TextBox txtPatternName;
    }
}