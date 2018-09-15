namespace QuanLyQuanCafe
{
    partial class fTableManager
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelOrderFood = new System.Windows.Forms.Panel();
            this.numericUpDownFood = new System.Windows.Forms.NumericUpDown();
            this.buttonAddFood = new System.Windows.Forms.Button();
            this.comboBoxFood = new System.Windows.Forms.ComboBox();
            this.comboBoxCatetory = new System.Windows.Forms.ComboBox();
            this.panelListFood = new System.Windows.Forms.Panel();
            this.listViewFood = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelButton = new System.Windows.Forms.Panel();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSwichTable = new System.Windows.Forms.ComboBox();
            this.buttonSwitchTable = new System.Windows.Forms.Button();
            this.labelPercent = new System.Windows.Forms.Label();
            this.numericUpDownDiscountPercent = new System.Windows.Forms.NumericUpDown();
            this.buttonDiscount = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.flowLayoutPanelTable = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.panelOrderFood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFood)).BeginInit();
            this.panelListFood.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiscountPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1125, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.acountToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1125, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // acountToolStripMenuItem
            // 
            this.acountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountProfileToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.acountToolStripMenuItem.Name = "acountToolStripMenuItem";
            this.acountToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.acountToolStripMenuItem.Text = "Tài khoản";
            // 
            // accountProfileToolStripMenuItem
            // 
            this.accountProfileToolStripMenuItem.Name = "accountProfileToolStripMenuItem";
            this.accountProfileToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.accountProfileToolStripMenuItem.Text = "thông tin cá nhân";
            this.accountProfileToolStripMenuItem.Click += new System.EventHandler(this.accountProfileToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.logoutToolStripMenuItem.Text = "đăng xuất";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // panelOrderFood
            // 
            this.panelOrderFood.Controls.Add(this.numericUpDownFood);
            this.panelOrderFood.Controls.Add(this.buttonAddFood);
            this.panelOrderFood.Controls.Add(this.comboBoxFood);
            this.panelOrderFood.Controls.Add(this.comboBoxCatetory);
            this.panelOrderFood.Location = new System.Drawing.Point(635, 31);
            this.panelOrderFood.Name = "panelOrderFood";
            this.panelOrderFood.Size = new System.Drawing.Size(478, 65);
            this.panelOrderFood.TabIndex = 3;
            // 
            // numericUpDownFood
            // 
            this.numericUpDownFood.Location = new System.Drawing.Point(410, 25);
            this.numericUpDownFood.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownFood.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.numericUpDownFood.Name = "numericUpDownFood";
            this.numericUpDownFood.Size = new System.Drawing.Size(65, 22);
            this.numericUpDownFood.TabIndex = 3;
            this.numericUpDownFood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAddFood
            // 
            this.buttonAddFood.Location = new System.Drawing.Point(323, 4);
            this.buttonAddFood.Name = "buttonAddFood";
            this.buttonAddFood.Size = new System.Drawing.Size(80, 54);
            this.buttonAddFood.TabIndex = 2;
            this.buttonAddFood.Text = "Thêm món";
            this.buttonAddFood.UseVisualStyleBackColor = true;
            this.buttonAddFood.Click += new System.EventHandler(this.buttonAddFood_Click);
            // 
            // comboBoxFood
            // 
            this.comboBoxFood.FormattingEnabled = true;
            this.comboBoxFood.Location = new System.Drawing.Point(4, 34);
            this.comboBoxFood.Name = "comboBoxFood";
            this.comboBoxFood.Size = new System.Drawing.Size(303, 24);
            this.comboBoxFood.TabIndex = 1;
            // 
            // comboBoxCatetory
            // 
            this.comboBoxCatetory.FormattingEnabled = true;
            this.comboBoxCatetory.Location = new System.Drawing.Point(4, 4);
            this.comboBoxCatetory.Name = "comboBoxCatetory";
            this.comboBoxCatetory.Size = new System.Drawing.Size(303, 24);
            this.comboBoxCatetory.TabIndex = 0;
            this.comboBoxCatetory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCatetory_SelectedIndexChanged);
            // 
            // panelListFood
            // 
            this.panelListFood.Controls.Add(this.listViewFood);
            this.panelListFood.Location = new System.Drawing.Point(635, 102);
            this.panelListFood.Name = "panelListFood";
            this.panelListFood.Size = new System.Drawing.Size(478, 468);
            this.panelListFood.TabIndex = 4;
            // 
            // listViewFood
            // 
            this.listViewFood.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewFood.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewFood.GridLines = true;
            this.listViewFood.HoverSelection = true;
            this.listViewFood.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listViewFood.Location = new System.Drawing.Point(4, 4);
            this.listViewFood.Name = "listViewFood";
            this.listViewFood.Size = new System.Drawing.Size(471, 461);
            this.listViewFood.TabIndex = 0;
            this.listViewFood.UseCompatibleStateImageBehavior = false;
            this.listViewFood.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "tên món";
            this.columnHeader1.Width = 153;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "đơn giá";
            this.columnHeader2.Width = 71;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "số lượng";
            this.columnHeader3.Width = 53;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "thành tiền";
            this.columnHeader4.Width = 70;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.textBoxTotalPrice);
            this.panelButton.Controls.Add(this.label1);
            this.panelButton.Controls.Add(this.comboBoxSwichTable);
            this.panelButton.Controls.Add(this.buttonSwitchTable);
            this.panelButton.Controls.Add(this.labelPercent);
            this.panelButton.Controls.Add(this.numericUpDownDiscountPercent);
            this.panelButton.Controls.Add(this.buttonDiscount);
            this.panelButton.Controls.Add(this.buttonPay);
            this.panelButton.Location = new System.Drawing.Point(635, 576);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(478, 60);
            this.panelButton.TabIndex = 4;
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.textBoxTotalPrice.Location = new System.Drawing.Point(247, 26);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(120, 27);
            this.textBoxTotalPrice.TabIndex = 11;
            this.textBoxTotalPrice.Text = "0";
            this.textBoxTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tổng tiền";
            // 
            // comboBoxSwichTable
            // 
            this.comboBoxSwichTable.FormattingEnabled = true;
            this.comboBoxSwichTable.Location = new System.Drawing.Point(3, 32);
            this.comboBoxSwichTable.Name = "comboBoxSwichTable";
            this.comboBoxSwichTable.Size = new System.Drawing.Size(109, 24);
            this.comboBoxSwichTable.TabIndex = 4;
            // 
            // buttonSwitchTable
            // 
            this.buttonSwitchTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSwitchTable.Location = new System.Drawing.Point(4, 3);
            this.buttonSwitchTable.Name = "buttonSwitchTable";
            this.buttonSwitchTable.Size = new System.Drawing.Size(108, 28);
            this.buttonSwitchTable.TabIndex = 9;
            this.buttonSwitchTable.Text = "Chuyển bàn";
            this.buttonSwitchTable.UseVisualStyleBackColor = true;
            this.buttonSwitchTable.Click += new System.EventHandler(this.buttonSwitchTable_Click);
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(207, 37);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(20, 17);
            this.labelPercent.TabIndex = 8;
            this.labelPercent.Text = "%";
            // 
            // numericUpDownDiscountPercent
            // 
            this.numericUpDownDiscountPercent.Location = new System.Drawing.Point(147, 34);
            this.numericUpDownDiscountPercent.Name = "numericUpDownDiscountPercent";
            this.numericUpDownDiscountPercent.Size = new System.Drawing.Size(54, 22);
            this.numericUpDownDiscountPercent.TabIndex = 7;
            this.numericUpDownDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownDiscountPercent.ValueChanged += new System.EventHandler(this.numericUpDownDiscountPercent_ValueChanged);
            // 
            // buttonDiscount
            // 
            this.buttonDiscount.Location = new System.Drawing.Point(147, 3);
            this.buttonDiscount.Name = "buttonDiscount";
            this.buttonDiscount.Size = new System.Drawing.Size(80, 28);
            this.buttonDiscount.TabIndex = 6;
            this.buttonDiscount.Text = "Giảm giá";
            this.buttonDiscount.UseVisualStyleBackColor = true;
            this.buttonDiscount.Click += new System.EventHandler(this.buttonDiscount_Click);
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(387, 3);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(88, 54);
            this.buttonPay.TabIndex = 5;
            this.buttonPay.Text = "Thanh toán";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // flowLayoutPanelTable
            // 
            this.flowLayoutPanelTable.AutoScroll = true;
            this.flowLayoutPanelTable.Location = new System.Drawing.Point(13, 35);
            this.flowLayoutPanelTable.Name = "flowLayoutPanelTable";
            this.flowLayoutPanelTable.Size = new System.Drawing.Size(616, 601);
            this.flowLayoutPanelTable.TabIndex = 5;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 648);
            this.Controls.Add(this.flowLayoutPanelTable);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelListFood);
            this.Controls.Add(this.panelOrderFood);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý quán cafe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panelOrderFood.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFood)).EndInit();
            this.panelListFood.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiscountPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Panel panelOrderFood;
        private System.Windows.Forms.NumericUpDown numericUpDownFood;
        private System.Windows.Forms.Button buttonAddFood;
        private System.Windows.Forms.ComboBox comboBoxFood;
        private System.Windows.Forms.ComboBox comboBoxCatetory;
        private System.Windows.Forms.Panel panelListFood;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTable;
        private System.Windows.Forms.ListView listViewFood;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonDiscount;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownDiscountPercent;
        private System.Windows.Forms.ComboBox comboBoxSwichTable;
        private System.Windows.Forms.Button buttonSwitchTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Label label1;
    }
}