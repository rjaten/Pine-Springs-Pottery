namespace PineSpringsPotteryDatabase
{
    partial class AddExpenseType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpenseType));
            this.txtNewType = new System.Windows.Forms.TextBox();
            this.lblNewExpenseType = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewType
            // 
            this.txtNewType.Location = new System.Drawing.Point(53, 37);
            this.txtNewType.MaxLength = 255;
            this.txtNewType.Name = "txtNewType";
            this.txtNewType.Size = new System.Drawing.Size(207, 20);
            this.txtNewType.TabIndex = 0;
            // 
            // lblNewExpenseType
            // 
            this.lblNewExpenseType.AutoSize = true;
            this.lblNewExpenseType.Location = new System.Drawing.Point(12, 9);
            this.lblNewExpenseType.Name = "lblNewExpenseType";
            this.lblNewExpenseType.Size = new System.Drawing.Size(134, 13);
            this.lblNewExpenseType.TabIndex = 1;
            this.lblNewExpenseType.Text = "New Expense Type Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(62, 78);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(171, 78);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddExpenseType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 116);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblNewExpenseType);
            this.Controls.Add(this.txtNewType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddExpenseType";
            this.Text = "Add Expense Type";
            this.Load += new System.EventHandler(this.AddExpenseType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewType;
        private System.Windows.Forms.Label lblNewExpenseType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}