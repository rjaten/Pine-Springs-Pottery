namespace PineSpringsPotteryDatabase
{
    partial class AddExpense
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
            System.Windows.Forms.Label expenseTypeLabel;
            System.Windows.Forms.Label expenseDateLabel;
            System.Windows.Forms.Label amountLabel;
            System.Windows.Forms.Label mileageLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpense));
            this.expenseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.expenseDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudMileage = new System.Windows.Forms.NumericUpDown();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.mapButton = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            expenseTypeLabel = new System.Windows.Forms.Label();
            expenseDateLabel = new System.Windows.Forms.Label();
            amountLabel = new System.Windows.Forms.Label();
            mileageLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMileage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // expenseTypeLabel
            // 
            expenseTypeLabel.AutoSize = true;
            expenseTypeLabel.Location = new System.Drawing.Point(11, 63);
            expenseTypeLabel.Name = "expenseTypeLabel";
            expenseTypeLabel.Size = new System.Drawing.Size(78, 13);
            expenseTypeLabel.TabIndex = 1;
            expenseTypeLabel.Text = "Expense Type:";
            // 
            // expenseDateLabel
            // 
            expenseDateLabel.AutoSize = true;
            expenseDateLabel.Location = new System.Drawing.Point(12, 37);
            expenseDateLabel.Name = "expenseDateLabel";
            expenseDateLabel.Size = new System.Drawing.Size(77, 13);
            expenseDateLabel.TabIndex = 3;
            expenseDateLabel.Text = "Expense Date:";
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new System.Drawing.Point(12, 93);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new System.Drawing.Size(90, 13);
            amountLabel.TabIndex = 5;
            amountLabel.Text = "Expense Amount:";
            // 
            // mileageLabel
            // 
            mileageLabel.AutoSize = true;
            mileageLabel.Location = new System.Drawing.Point(12, 122);
            mileageLabel.Name = "mileageLabel";
            mileageLabel.Size = new System.Drawing.Size(47, 13);
            mileageLabel.TabIndex = 7;
            mileageLabel.Text = "Mileage:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(11, 151);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 9;
            descriptionLabel.Text = "Description:";
            // 
            // expenseTypeComboBox
            // 
            this.expenseTypeComboBox.FormattingEnabled = true;
            this.expenseTypeComboBox.Location = new System.Drawing.Point(108, 60);
            this.expenseTypeComboBox.Name = "expenseTypeComboBox";
            this.expenseTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.expenseTypeComboBox.TabIndex = 2;
            // 
            // expenseDateDateTimePicker
            // 
            this.expenseDateDateTimePicker.Location = new System.Drawing.Point(108, 34);
            this.expenseDateDateTimePicker.Name = "expenseDateDateTimePicker";
            this.expenseDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.expenseDateDateTimePicker.TabIndex = 4;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(108, 145);
            this.descriptionTextBox.MaxLength = 255;
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(170, 77);
            this.descriptionTextBox.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(326, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expenseTypeToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.addToolStripMenuItem.Text = "Add...";
            // 
            // expenseTypeToolStripMenuItem
            // 
            this.expenseTypeToolStripMenuItem.Name = "expenseTypeToolStripMenuItem";
            this.expenseTypeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.expenseTypeToolStripMenuItem.Text = "Expense Type";
            this.expenseTypeToolStripMenuItem.Click += new System.EventHandler(this.expenseTypeToolStripMenuItem_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(27, 236);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(121, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudMileage
            // 
            this.nudMileage.DecimalPlaces = 2;
            this.nudMileage.Location = new System.Drawing.Point(108, 116);
            this.nudMileage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMileage.Name = "nudMileage";
            this.nudMileage.Size = new System.Drawing.Size(121, 20);
            this.nudMileage.TabIndex = 14;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(109, 88);
            this.nudAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 20);
            this.nudAmount.TabIndex = 15;
            // 
            // mapButton
            // 
            this.mapButton.Location = new System.Drawing.Point(239, 112);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(75, 23);
            this.mapButton.TabIndex = 16;
            this.mapButton.Text = "Map";
            this.mapButton.UseVisualStyleBackColor = true;
            this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(214, 236);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AddExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 280);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.mapButton);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.nudMileage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(mileageLabel);
            this.Controls.Add(amountLabel);
            this.Controls.Add(expenseDateLabel);
            this.Controls.Add(this.expenseDateDateTimePicker);
            this.Controls.Add(expenseTypeLabel);
            this.Controls.Add(this.expenseTypeComboBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AddExpense";
            this.Text = "Add Expense";
            this.Load += new System.EventHandler(this.AddExpense_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMileage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox expenseTypeComboBox;
        private System.Windows.Forms.DateTimePicker expenseDateDateTimePicker;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseTypeToolStripMenuItem;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudMileage;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Button mapButton;
        private System.Windows.Forms.Button btnDelete;
    }
}