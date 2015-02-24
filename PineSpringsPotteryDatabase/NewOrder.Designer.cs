namespace PineSpringsPotteryDatabase
{
    partial class NewOrder
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label notesLabel;
            System.Windows.Forms.Label orderDateLabel1;
            System.Windows.Forms.Label showNoLabel;
            System.Windows.Forms.Label subtotalLabel1;
            System.Windows.Forms.Label discountLabel;
            System.Windows.Forms.Label taxLabel;
            System.Windows.Forms.Label totalLabel1;
            System.Windows.Forms.Label lblAmountDue;
            System.Windows.Forms.Label amountPaidLabel;
            System.Windows.Forms.Label paymentTypeLabel;
            System.Windows.Forms.Label lblNewTotal;
            System.Windows.Forms.Label lblShipping;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOrder));
            this.btnSelectCustomer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvLineItems = new System.Windows.Forms.DataGridView();
            this.PieceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Customizations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isGift = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CardMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pineSpringsPotteryDataSet = new PineSpringsPotteryDatabase.PineSpringsPotteryDataSet();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.grpDiscount = new System.Windows.Forms.GroupBox();
            this.nudDollarDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblOr = new System.Windows.Forms.Label();
            this.nudPercentDiscount = new System.Windows.Forms.NumericUpDown();
            this.rbDollarDiscount = new System.Windows.Forms.RadioButton();
            this.rbPercent = new System.Windows.Forms.RadioButton();
            this.ccbCustomerCredit = new System.Windows.Forms.CheckBox();
            this.btnSelectShow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.orderNoTextBox = new System.Windows.Forms.TextBox();
            this.orderDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.showNoTextBox = new System.Windows.Forms.TextBox();
            this.subtotalTextBox = new System.Windows.Forms.TextBox();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.taxTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.txtAmountDue = new System.Windows.Forms.TextBox();
            this.paymentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.taxableCheckBox = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtCustomerCredit = new System.Windows.Forms.TextBox();
            this.txtNewTotal = new System.Windows.Forms.TextBox();
            this.lblLeftOverCreditLabel = new System.Windows.Forms.Label();
            this.cbPaidFull = new System.Windows.Forms.CheckBox();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.lblLeftOverCredit = new System.Windows.Forms.Label();
            this.cbShipping = new System.Windows.Forms.CheckBox();
            this.lblCheckNo = new System.Windows.Forms.Label();
            this.ordersBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.customerNoTextBox = new System.Windows.Forms.TextBox();
            this.nudShipping = new System.Windows.Forms.NumericUpDown();
            this.nudAmountPaid = new System.Windows.Forms.NumericUpDown();
            this.txtShowName = new System.Windows.Forms.TextBox();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.btnRemoveShow = new System.Windows.Forms.Button();
            this.oRDERSTableAdapter = new PineSpringsPotteryDatabase.PineSpringsPotteryDataSetTableAdapters.ORDERSTableAdapter();
            this.tableAdapterManager = new PineSpringsPotteryDatabase.PineSpringsPotteryDataSetTableAdapters.TableAdapterManager();
            firstNameLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            orderDateLabel1 = new System.Windows.Forms.Label();
            showNoLabel = new System.Windows.Forms.Label();
            subtotalLabel1 = new System.Windows.Forms.Label();
            discountLabel = new System.Windows.Forms.Label();
            taxLabel = new System.Windows.Forms.Label();
            totalLabel1 = new System.Windows.Forms.Label();
            lblAmountDue = new System.Windows.Forms.Label();
            amountPaidLabel = new System.Windows.Forms.Label();
            paymentTypeLabel = new System.Windows.Forms.Label();
            lblNewTotal = new System.Windows.Forms.Label();
            lblShipping = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pineSpringsPotteryDataSet)).BeginInit();
            this.grpDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDollarDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingNavigator)).BeginInit();
            this.ordersBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShipping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountPaid)).BeginInit();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(11, 72);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(85, 13);
            firstNameLabel.TabIndex = 29;
            firstNameLabel.Text = "Customer Name:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(538, 25);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(38, 13);
            notesLabel.TabIndex = 33;
            notesLabel.Text = "Notes:";
            // 
            // orderDateLabel1
            // 
            orderDateLabel1.AutoSize = true;
            orderDateLabel1.Location = new System.Drawing.Point(11, 101);
            orderDateLabel1.Name = "orderDateLabel1";
            orderDateLabel1.Size = new System.Drawing.Size(62, 13);
            orderDateLabel1.TabIndex = 67;
            orderDateLabel1.Text = "Order Date:";
            // 
            // showNoLabel
            // 
            showNoLabel.AutoSize = true;
            showNoLabel.Location = new System.Drawing.Point(11, 41);
            showNoLabel.Name = "showNoLabel";
            showNoLabel.Size = new System.Drawing.Size(68, 13);
            showNoLabel.TabIndex = 68;
            showNoLabel.Text = "Show Name:";
            // 
            // subtotalLabel1
            // 
            subtotalLabel1.AutoSize = true;
            subtotalLabel1.Location = new System.Drawing.Point(212, 375);
            subtotalLabel1.Name = "subtotalLabel1";
            subtotalLabel1.Size = new System.Drawing.Size(49, 13);
            subtotalLabel1.TabIndex = 69;
            subtotalLabel1.Text = "Subtotal:";
            // 
            // discountLabel
            // 
            discountLabel.AutoSize = true;
            discountLabel.Location = new System.Drawing.Point(210, 401);
            discountLabel.Name = "discountLabel";
            discountLabel.Size = new System.Drawing.Size(84, 13);
            discountLabel.TabIndex = 70;
            discountLabel.Text = "Discount/Credit:";
            // 
            // taxLabel
            // 
            taxLabel.AutoSize = true;
            taxLabel.Location = new System.Drawing.Point(235, 456);
            taxLabel.Name = "taxLabel";
            taxLabel.Size = new System.Drawing.Size(28, 13);
            taxLabel.TabIndex = 71;
            taxLabel.Text = "Tax:";
            // 
            // totalLabel1
            // 
            totalLabel1.AutoSize = true;
            totalLabel1.Location = new System.Drawing.Point(212, 501);
            totalLabel1.Name = "totalLabel1";
            totalLabel1.Size = new System.Drawing.Size(34, 13);
            totalLabel1.TabIndex = 72;
            totalLabel1.Text = "Total:";
            // 
            // lblAmountDue
            // 
            lblAmountDue.AutoSize = true;
            lblAmountDue.Location = new System.Drawing.Point(438, 481);
            lblAmountDue.Name = "lblAmountDue";
            lblAmountDue.Size = new System.Drawing.Size(69, 13);
            lblAmountDue.TabIndex = 74;
            lblAmountDue.Text = "Amount Due:";
            // 
            // amountPaidLabel
            // 
            amountPaidLabel.AutoSize = true;
            amountPaidLabel.Location = new System.Drawing.Point(437, 405);
            amountPaidLabel.Name = "amountPaidLabel";
            amountPaidLabel.Size = new System.Drawing.Size(70, 13);
            amountPaidLabel.TabIndex = 75;
            amountPaidLabel.Text = "Amount Paid:";
            // 
            // paymentTypeLabel
            // 
            paymentTypeLabel.AutoSize = true;
            paymentTypeLabel.Location = new System.Drawing.Point(439, 431);
            paymentTypeLabel.Name = "paymentTypeLabel";
            paymentTypeLabel.Size = new System.Drawing.Size(78, 13);
            paymentTypeLabel.TabIndex = 76;
            paymentTypeLabel.Text = "Payment Type:";
            // 
            // lblNewTotal
            // 
            lblNewTotal.AutoSize = true;
            lblNewTotal.Location = new System.Drawing.Point(212, 431);
            lblNewTotal.Name = "lblNewTotal";
            lblNewTotal.Size = new System.Drawing.Size(59, 13);
            lblNewTotal.TabIndex = 86;
            lblNewTotal.Text = "New Total:";
            // 
            // lblShipping
            // 
            lblShipping.AutoSize = true;
            lblShipping.Location = new System.Drawing.Point(235, 479);
            lblShipping.Name = "lblShipping";
            lblShipping.Size = new System.Drawing.Size(51, 13);
            lblShipping.TabIndex = 93;
            lblShipping.Text = "Shipping:";
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Location = new System.Drawing.Point(247, 68);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(97, 23);
            this.btnSelectCustomer.TabIndex = 3;
            this.btnSelectCustomer.Text = "Select Customer";
            this.btnSelectCustomer.UseVisualStyleBackColor = true;
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(771, 441);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Order";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(47, 137);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 7;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(139, 20);
            this.txtName.TabIndex = 2;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // dgvLineItems
            // 
            this.dgvLineItems.AllowUserToAddRows = false;
            this.dgvLineItems.AllowUserToOrderColumns = true;
            this.dgvLineItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PieceName,
            this.Size,
            this.Pattern,
            this.Quantity,
            this.Price,
            this.TotalPrice,
            this.Status,
            this.Customizations,
            this.isGift,
            this.CardMessage});
            this.dgvLineItems.Location = new System.Drawing.Point(12, 166);
            this.dgvLineItems.MultiSelect = false;
            this.dgvLineItems.Name = "dgvLineItems";
            this.dgvLineItems.Size = new System.Drawing.Size(873, 201);
            this.dgvLineItems.TabIndex = 50;
            this.dgvLineItems.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItems_CellContentDoubleClick);
            this.dgvLineItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItems_CellValueChanged);
            this.dgvLineItems.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvLineItems_UserDeletingRow);
            // 
            // PieceName
            // 
            this.PieceName.HeaderText = "Piece";
            this.PieceName.Name = "PieceName";
            this.PieceName.ReadOnly = true;
            this.PieceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PieceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PieceName.Width = 105;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Size.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Size.Width = 60;
            // 
            // Pattern
            // 
            this.Pattern.HeaderText = "Pattern";
            this.Pattern.Name = "Pattern";
            this.Pattern.ReadOnly = true;
            this.Pattern.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pattern.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MaxInputLength = 10;
            this.Quantity.Name = "Quantity";
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Quantity.Width = 65;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MaxInputLength = 10;
            this.Price.Name = "Price";
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 75;
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "TotalPrice";
            this.TotalPrice.MaxInputLength = 10;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalPrice.Width = 75;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "\"ORDERED\"",
            "\"MADE\"",
            "\"DELIVERED\"",
            "\"RETURNED\"",
            "\"CANCELLED\""});
            this.Status.Name = "Status";
            // 
            // Customizations
            // 
            this.Customizations.HeaderText = "Customizations";
            this.Customizations.MaxInputLength = 255;
            this.Customizations.Name = "Customizations";
            this.Customizations.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Customizations.Width = 150;
            // 
            // isGift
            // 
            this.isGift.HeaderText = "Gift";
            this.isGift.Name = "isGift";
            this.isGift.Width = 50;
            // 
            // CardMessage
            // 
            this.CardMessage.HeaderText = "Card Message";
            this.CardMessage.MaxInputLength = 255;
            this.CardMessage.Name = "CardMessage";
            this.CardMessage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CardMessage.Width = 125;
            // 
            // txtNotes
            // 
            this.txtNotes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "Notes", true));
            this.txtNotes.Location = new System.Drawing.Point(530, 41);
            this.txtNotes.MaxLength = 255;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(355, 102);
            this.txtNotes.TabIndex = 6;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "ORDERS";
            this.ordersBindingSource.DataSource = this.pineSpringsPotteryDataSet;
            // 
            // pineSpringsPotteryDataSet
            // 
            this.pineSpringsPotteryDataSet.DataSetName = "PineSpringsPotteryDataSet";
            this.pineSpringsPotteryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.Location = new System.Drawing.Point(350, 68);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(92, 23);
            this.btnAddNewCustomer.TabIndex = 4;
            this.btnAddNewCustomer.Text = "New Customer";
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // grpDiscount
            // 
            this.grpDiscount.Controls.Add(this.nudDollarDiscount);
            this.grpDiscount.Controls.Add(this.lblOr);
            this.grpDiscount.Controls.Add(this.nudPercentDiscount);
            this.grpDiscount.Controls.Add(this.rbDollarDiscount);
            this.grpDiscount.Controls.Add(this.rbPercent);
            this.grpDiscount.Location = new System.Drawing.Point(14, 373);
            this.grpDiscount.Name = "grpDiscount";
            this.grpDiscount.Size = new System.Drawing.Size(178, 123);
            this.grpDiscount.TabIndex = 55;
            this.grpDiscount.TabStop = false;
            this.grpDiscount.Text = "Discount/Host Credit";
            // 
            // nudDollarDiscount
            // 
            this.nudDollarDiscount.DecimalPlaces = 2;
            this.nudDollarDiscount.Location = new System.Drawing.Point(103, 76);
            this.nudDollarDiscount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudDollarDiscount.Name = "nudDollarDiscount";
            this.nudDollarDiscount.Size = new System.Drawing.Size(59, 20);
            this.nudDollarDiscount.TabIndex = 55;
            this.nudDollarDiscount.ValueChanged += new System.EventHandler(this.txtDollarDiscount_ValueChanged);
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(46, 53);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(18, 13);
            this.lblOr.TabIndex = 4;
            this.lblOr.Text = "Or";
            // 
            // nudPercentDiscount
            // 
            this.nudPercentDiscount.Location = new System.Drawing.Point(75, 26);
            this.nudPercentDiscount.Name = "nudPercentDiscount";
            this.nudPercentDiscount.Size = new System.Drawing.Size(57, 20);
            this.nudPercentDiscount.TabIndex = 3;
            this.nudPercentDiscount.ValueChanged += new System.EventHandler(this.nudPercentDiscount_ValueChanged);
            // 
            // rbDollarDiscount
            // 
            this.rbDollarDiscount.AutoSize = true;
            this.rbDollarDiscount.Location = new System.Drawing.Point(6, 74);
            this.rbDollarDiscount.Name = "rbDollarDiscount";
            this.rbDollarDiscount.Size = new System.Drawing.Size(91, 17);
            this.rbDollarDiscount.TabIndex = 2;
            this.rbDollarDiscount.Text = "Dollar Amount";
            this.rbDollarDiscount.UseVisualStyleBackColor = true;
            // 
            // rbPercent
            // 
            this.rbPercent.AutoSize = true;
            this.rbPercent.Checked = true;
            this.rbPercent.Location = new System.Drawing.Point(6, 25);
            this.rbPercent.Name = "rbPercent";
            this.rbPercent.Size = new System.Drawing.Size(62, 17);
            this.rbPercent.TabIndex = 1;
            this.rbPercent.TabStop = true;
            this.rbPercent.Text = "Percent";
            this.rbPercent.UseVisualStyleBackColor = true;
            this.rbPercent.CheckedChanged += new System.EventHandler(this.rbPercent_CheckedChanged);
            // 
            // ccbCustomerCredit
            // 
            this.ccbCustomerCredit.AutoSize = true;
            this.ccbCustomerCredit.Location = new System.Drawing.Point(14, 502);
            this.ccbCustomerCredit.Name = "ccbCustomerCredit";
            this.ccbCustomerCredit.Size = new System.Drawing.Size(119, 17);
            this.ccbCustomerCredit.TabIndex = 56;
            this.ccbCustomerCredit.Text = "Use Previous Credit";
            this.ccbCustomerCredit.UseVisualStyleBackColor = true;
            this.ccbCustomerCredit.CheckedChanged += new System.EventHandler(this.ccbCustomerCredit_CheckedChanged);
            // 
            // btnSelectShow
            // 
            this.btnSelectShow.Location = new System.Drawing.Point(247, 38);
            this.btnSelectShow.Name = "btnSelectShow";
            this.btnSelectShow.Size = new System.Drawing.Size(75, 23);
            this.btnSelectShow.TabIndex = 1;
            this.btnSelectShow.Text = "Select Show";
            this.btnSelectShow.UseVisualStyleBackColor = true;
            this.btnSelectShow.Click += new System.EventHandler(this.btnSelectShow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(777, 481);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 28);
            this.btnCancel.TabIndex = 58;
            this.btnCancel.Text = "Cancel/Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // orderNoTextBox
            // 
            this.orderNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "OrderNo", true));
            this.orderNoTextBox.Location = new System.Drawing.Point(585, 89);
            this.orderNoTextBox.Name = "orderNoTextBox";
            this.orderNoTextBox.ReadOnly = true;
            this.orderNoTextBox.Size = new System.Drawing.Size(100, 20);
            this.orderNoTextBox.TabIndex = 67;
            // 
            // orderDateDateTimePicker
            // 
            this.orderDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ordersBindingSource, "OrderDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.orderDateDateTimePicker.Location = new System.Drawing.Point(102, 101);
            this.orderDateDateTimePicker.Name = "orderDateDateTimePicker";
            this.orderDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.orderDateDateTimePicker.TabIndex = 5;
            this.orderDateDateTimePicker.ValueChanged += new System.EventHandler(this.orderDateDateTimePicker1_ValueChanged);
            this.orderDateDateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.orderDateDateTimePicker_Validating);
            this.orderDateDateTimePicker.Validated += new System.EventHandler(this.orderDateDateTimePicker_Validated);
            // 
            // showNoTextBox
            // 
            this.showNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "ShowNo", true));
            this.showNoTextBox.Location = new System.Drawing.Point(102, 41);
            this.showNoTextBox.Name = "showNoTextBox";
            this.showNoTextBox.ReadOnly = true;
            this.showNoTextBox.Size = new System.Drawing.Size(139, 20);
            this.showNoTextBox.TabIndex = 999;
            this.showNoTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.showNoTextBox_Validating);
            // 
            // subtotalTextBox
            // 
            this.subtotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "Subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.subtotalTextBox.Location = new System.Drawing.Point(300, 372);
            this.subtotalTextBox.Name = "subtotalTextBox";
            this.subtotalTextBox.ReadOnly = true;
            this.subtotalTextBox.Size = new System.Drawing.Size(100, 20);
            this.subtotalTextBox.TabIndex = 70;
            this.subtotalTextBox.Text = "0.00";
            // 
            // discountTextBox
            // 
            this.discountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "Discount", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.discountTextBox.Location = new System.Drawing.Point(300, 398);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.ReadOnly = true;
            this.discountTextBox.Size = new System.Drawing.Size(100, 20);
            this.discountTextBox.TabIndex = 71;
            this.discountTextBox.Text = "0.00";
            // 
            // taxTextBox
            // 
            this.taxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "Tax", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.taxTextBox.Location = new System.Drawing.Point(300, 449);
            this.taxTextBox.Name = "taxTextBox";
            this.taxTextBox.ReadOnly = true;
            this.taxTextBox.Size = new System.Drawing.Size(100, 20);
            this.taxTextBox.TabIndex = 72;
            this.taxTextBox.Text = "0.00";
            // 
            // totalTextBox
            // 
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "Total", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalTextBox.Location = new System.Drawing.Point(300, 501);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalTextBox.TabIndex = 73;
            this.totalTextBox.Text = "0.00";
            // 
            // txtAmountDue
            // 
            this.txtAmountDue.Location = new System.Drawing.Point(523, 479);
            this.txtAmountDue.Name = "txtAmountDue";
            this.txtAmountDue.ReadOnly = true;
            this.txtAmountDue.Size = new System.Drawing.Size(121, 20);
            this.txtAmountDue.TabIndex = 75;
            // 
            // paymentTypeComboBox
            // 
            this.paymentTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.ordersBindingSource, "PaymentType", true));
            this.paymentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentTypeComboBox.FormattingEnabled = true;
            this.paymentTypeComboBox.Location = new System.Drawing.Point(523, 425);
            this.paymentTypeComboBox.Name = "paymentTypeComboBox";
            this.paymentTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.paymentTypeComboBox.TabIndex = 77;
            this.paymentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.paymentTypeComboBox_SelectedIndexChanged);
            // 
            // taxableCheckBox
            // 
            this.taxableCheckBox.Checked = true;
            this.taxableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.taxableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ordersBindingSource, "Taxable", true));
            this.taxableCheckBox.Location = new System.Drawing.Point(217, 451);
            this.taxableCheckBox.Name = "taxableCheckBox";
            this.taxableCheckBox.Size = new System.Drawing.Size(104, 24);
            this.taxableCheckBox.TabIndex = 78;
            this.taxableCheckBox.UseVisualStyleBackColor = true;
            this.taxableCheckBox.CheckedChanged += new System.EventHandler(this.taxableCheckBox_CheckedChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(782, 399);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 28);
            this.btnEdit.TabIndex = 82;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtCustomerCredit
            // 
            this.txtCustomerCredit.Location = new System.Drawing.Point(139, 501);
            this.txtCustomerCredit.Name = "txtCustomerCredit";
            this.txtCustomerCredit.ReadOnly = true;
            this.txtCustomerCredit.Size = new System.Drawing.Size(50, 20);
            this.txtCustomerCredit.TabIndex = 85;
            this.txtCustomerCredit.Text = "0.00";
            // 
            // txtNewTotal
            // 
            this.txtNewTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "NewSubtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtNewTotal.Location = new System.Drawing.Point(300, 424);
            this.txtNewTotal.Name = "txtNewTotal";
            this.txtNewTotal.ReadOnly = true;
            this.txtNewTotal.Size = new System.Drawing.Size(100, 20);
            this.txtNewTotal.TabIndex = 87;
            this.txtNewTotal.Text = "0.00";
            // 
            // lblLeftOverCreditLabel
            // 
            this.lblLeftOverCreditLabel.AutoSize = true;
            this.lblLeftOverCreditLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLeftOverCreditLabel.Location = new System.Drawing.Point(520, 502);
            this.lblLeftOverCreditLabel.Name = "lblLeftOverCreditLabel";
            this.lblLeftOverCreditLabel.Size = new System.Drawing.Size(81, 13);
            this.lblLeftOverCreditLabel.TabIndex = 88;
            this.lblLeftOverCreditLabel.Text = "Left Over Credit";
            // 
            // cbPaidFull
            // 
            this.cbPaidFull.AutoSize = true;
            this.cbPaidFull.Location = new System.Drawing.Point(496, 375);
            this.cbPaidFull.Name = "cbPaidFull";
            this.cbPaidFull.Size = new System.Drawing.Size(80, 17);
            this.cbPaidFull.TabIndex = 89;
            this.cbPaidFull.Text = "Paid in full?";
            this.cbPaidFull.UseVisualStyleBackColor = true;
            this.cbPaidFull.CheckedChanged += new System.EventHandler(this.cbPaidFull_CheckedChanged);
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "CheckNo", true));
            this.txtCheckNo.Location = new System.Drawing.Point(523, 453);
            this.txtCheckNo.MaxLength = 20;
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(121, 20);
            this.txtCheckNo.TabIndex = 91;
            // 
            // lblLeftOverCredit
            // 
            this.lblLeftOverCredit.AutoSize = true;
            this.lblLeftOverCredit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLeftOverCredit.Location = new System.Drawing.Point(607, 503);
            this.lblLeftOverCredit.Name = "lblLeftOverCredit";
            this.lblLeftOverCredit.Size = new System.Drawing.Size(28, 13);
            this.lblLeftOverCredit.TabIndex = 92;
            this.lblLeftOverCredit.Text = "0.00";
            // 
            // cbShipping
            // 
            this.cbShipping.Location = new System.Drawing.Point(217, 474);
            this.cbShipping.Name = "cbShipping";
            this.cbShipping.Size = new System.Drawing.Size(104, 24);
            this.cbShipping.TabIndex = 95;
            this.cbShipping.UseVisualStyleBackColor = true;
            this.cbShipping.CheckedChanged += new System.EventHandler(this.cbShipping_CheckedChanged);
            // 
            // lblCheckNo
            // 
            this.lblCheckNo.AutoSize = true;
            this.lblCheckNo.Location = new System.Drawing.Point(442, 454);
            this.lblCheckNo.Name = "lblCheckNo";
            this.lblCheckNo.Size = new System.Drawing.Size(58, 13);
            this.lblCheckNo.TabIndex = 96;
            this.lblCheckNo.Text = "Check No:";
            // 
            // ordersBindingNavigator
            // 
            this.ordersBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.ordersBindingNavigator.BindingSource = this.ordersBindingSource;
            this.ordersBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.ordersBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.ordersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.ordersBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.ordersBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.ordersBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.ordersBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.ordersBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.ordersBindingNavigator.Name = "ordersBindingNavigator";
            this.ordersBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.ordersBindingNavigator.Size = new System.Drawing.Size(900, 25);
            this.ordersBindingNavigator.TabIndex = 97;
            this.ordersBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // customerNoTextBox
            // 
            this.customerNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordersBindingSource, "CustomerNo", true));
            this.customerNoTextBox.Location = new System.Drawing.Point(102, 69);
            this.customerNoTextBox.Name = "customerNoTextBox";
            this.customerNoTextBox.ReadOnly = true;
            this.customerNoTextBox.Size = new System.Drawing.Size(100, 20);
            this.customerNoTextBox.TabIndex = 1000;
            this.customerNoTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.customerNoTextBox_Validating);
            // 
            // nudShipping
            // 
            this.nudShipping.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ordersBindingSource, "Shipping", true));
            this.nudShipping.DecimalPlaces = 2;
            this.nudShipping.Location = new System.Drawing.Point(300, 475);
            this.nudShipping.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudShipping.Name = "nudShipping";
            this.nudShipping.Size = new System.Drawing.Size(100, 20);
            this.nudShipping.TabIndex = 99;
            this.nudShipping.ValueChanged += new System.EventHandler(this.nudShipping_ValueChanged);
            // 
            // nudAmountPaid
            // 
            this.nudAmountPaid.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ordersBindingSource, "AmountPaid", true));
            this.nudAmountPaid.DecimalPlaces = 2;
            this.nudAmountPaid.Location = new System.Drawing.Point(524, 398);
            this.nudAmountPaid.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAmountPaid.Name = "nudAmountPaid";
            this.nudAmountPaid.Size = new System.Drawing.Size(120, 20);
            this.nudAmountPaid.TabIndex = 100;
            this.nudAmountPaid.ValueChanged += new System.EventHandler(this.nudAmountPaid_ValueChanged);
            // 
            // txtShowName
            // 
            this.txtShowName.Location = new System.Drawing.Point(102, 41);
            this.txtShowName.Name = "txtShowName";
            this.txtShowName.ReadOnly = true;
            this.txtShowName.Size = new System.Drawing.Size(139, 20);
            this.txtShowName.TabIndex = 101;
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.Location = new System.Drawing.Point(449, 68);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCustomer.TabIndex = 1001;
            this.btnRemoveCustomer.Text = "Remove";
            this.btnRemoveCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            // 
            // btnRemoveShow
            // 
            this.btnRemoveShow.Location = new System.Drawing.Point(328, 38);
            this.btnRemoveShow.Name = "btnRemoveShow";
            this.btnRemoveShow.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveShow.TabIndex = 1002;
            this.btnRemoveShow.Text = "Remove";
            this.btnRemoveShow.UseVisualStyleBackColor = true;
            this.btnRemoveShow.Click += new System.EventHandler(this.btnRemoveShow_Click);
            // 
            // oRDERSTableAdapter
            // 
            this.oRDERSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CUSTOMERTableAdapter = null;
            this.tableAdapterManager.EXPENSE_TYPETableAdapter = null;
            this.tableAdapterManager.EXPENSE1TableAdapter = null;
            this.tableAdapterManager.EXPENSETableAdapter = null;
            this.tableAdapterManager.GUESTLISTTableAdapter = null;
            this.tableAdapterManager.LINEITEMTableAdapter = null;
            this.tableAdapterManager.ORDERSTableAdapter = this.oRDERSTableAdapter;
            this.tableAdapterManager.PATTERNTableAdapter = null;
            this.tableAdapterManager.PIECE_CATALOGTableAdapter = null;
            this.tableAdapterManager.PIECE_SIZETableAdapter = null;
            this.tableAdapterManager.SHOW_TYPETableAdapter = null;
            this.tableAdapterManager.ShowPiecesTableAdapter = null;
            this.tableAdapterManager.SHOWTableAdapter = null;
            this.tableAdapterManager.totalSalesQueryTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = PineSpringsPotteryDatabase.PineSpringsPotteryDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WISHLISTTableAdapter = null;
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 536);
            this.Controls.Add(this.btnRemoveShow);
            this.Controls.Add(this.btnRemoveCustomer);
            this.Controls.Add(this.txtShowName);
            this.Controls.Add(this.nudAmountPaid);
            this.Controls.Add(this.nudShipping);
            this.Controls.Add(this.ordersBindingNavigator);
            this.Controls.Add(this.lblCheckNo);
            this.Controls.Add(lblShipping);
            this.Controls.Add(this.lblLeftOverCredit);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.cbPaidFull);
            this.Controls.Add(this.lblLeftOverCreditLabel);
            this.Controls.Add(lblNewTotal);
            this.Controls.Add(this.txtNewTotal);
            this.Controls.Add(this.txtCustomerCredit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(paymentTypeLabel);
            this.Controls.Add(this.paymentTypeComboBox);
            this.Controls.Add(amountPaidLabel);
            this.Controls.Add(lblAmountDue);
            this.Controls.Add(this.txtAmountDue);
            this.Controls.Add(totalLabel1);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(taxLabel);
            this.Controls.Add(this.taxTextBox);
            this.Controls.Add(discountLabel);
            this.Controls.Add(this.discountTextBox);
            this.Controls.Add(subtotalLabel1);
            this.Controls.Add(this.subtotalTextBox);
            this.Controls.Add(showNoLabel);
            this.Controls.Add(this.showNoTextBox);
            this.Controls.Add(orderDateLabel1);
            this.Controls.Add(this.orderDateDateTimePicker);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectShow);
            this.Controls.Add(this.ccbCustomerCredit);
            this.Controls.Add(this.grpDiscount);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.dgvLineItems);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSelectCustomer);
            this.Controls.Add(notesLabel);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(this.taxableCheckBox);
            this.Controls.Add(this.cbShipping);
            this.Controls.Add(this.customerNoTextBox);
            this.Controls.Add(this.orderNoTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewOrder";
            this.Text = "Order Information";
            this.Load += new System.EventHandler(this.NewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pineSpringsPotteryDataSet)).EndInit();
            this.grpDiscount.ResumeLayout(false);
            this.grpDiscount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDollarDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingNavigator)).EndInit();
            this.ordersBindingNavigator.ResumeLayout(false);
            this.ordersBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShipping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountPaid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvLineItems;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.GroupBox grpDiscount;
        private System.Windows.Forms.RadioButton rbDollarDiscount;
        private System.Windows.Forms.RadioButton rbPercent;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.NumericUpDown nudPercentDiscount;
        private System.Windows.Forms.CheckBox ccbCustomerCredit;
        private System.Windows.Forms.Button btnSelectShow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox orderNoTextBox;
        private System.Windows.Forms.DateTimePicker orderDateDateTimePicker;
        private System.Windows.Forms.TextBox showNoTextBox;
        private System.Windows.Forms.TextBox subtotalTextBox;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.TextBox taxTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.TextBox txtAmountDue;
        private System.Windows.Forms.ComboBox paymentTypeComboBox;
        private System.Windows.Forms.CheckBox taxableCheckBox;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtCustomerCredit;
        private System.Windows.Forms.TextBox txtNewTotal;
        private System.Windows.Forms.Label lblLeftOverCreditLabel;
        private System.Windows.Forms.CheckBox cbPaidFull;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label lblLeftOverCredit;
        private System.Windows.Forms.CheckBox cbShipping;
        private System.Windows.Forms.Label lblCheckNo;
        private System.Windows.Forms.BindingNavigator ordersBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private PineSpringsPotteryDataSet pineSpringsPotteryDataSet;
        private PineSpringsPotteryDataSetTableAdapters.ORDERSTableAdapter oRDERSTableAdapter;
        private PineSpringsPotteryDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox customerNoTextBox;
        private System.Windows.Forms.NumericUpDown nudDollarDiscount;
        private System.Windows.Forms.NumericUpDown nudShipping;
        private System.Windows.Forms.NumericUpDown nudAmountPaid;
        private System.Windows.Forms.TextBox txtShowName;
        private System.Windows.Forms.Button btnRemoveCustomer;
        private System.Windows.Forms.Button btnRemoveShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn PieceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pattern;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customizations;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isGift;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardMessage;
    }
}