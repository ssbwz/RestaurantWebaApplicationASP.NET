namespace Shawarma
{
    partial class UCCreateOrder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.lbShowItems = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdSummerItem = new System.Windows.Forms.RadioButton();
            this.rdHoildayItem = new System.Windows.Forms.RadioButton();
            this.rdNormalItem = new System.Windows.Forms.RadioButton();
            this.cbCatergory = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbOrderList = new System.Windows.Forms.ListBox();
            this.lbShowOrderNumber = new System.Windows.Forms.Label();
            this.lbShowUserWhoMadeOrder = new System.Windows.Forms.Label();
            this.btMakeOrder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdAll);
            this.groupBox1.Controls.Add(this.lbShowItems);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbPrice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdSummerItem);
            this.groupBox1.Controls.Add(this.rdHoildayItem);
            this.groupBox1.Controls.Add(this.rdNormalItem);
            this.groupBox1.Controls.Add(this.cbCatergory);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Location = new System.Drawing.Point(3, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 192);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Dishes";
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.Location = new System.Drawing.Point(564, 58);
            this.rdAll.Name = "rdAll";
            this.rdAll.Size = new System.Drawing.Size(81, 24);
            this.rdAll.TabIndex = 33;
            this.rdAll.Text = "All Dish";
            this.rdAll.UseVisualStyleBackColor = true;
            this.rdAll.CheckedChanged += new System.EventHandler(this.rdAll_CheckedChanged);
            // 
            // lbShowItems
            // 
            this.lbShowItems.FormattingEnabled = true;
            this.lbShowItems.HorizontalScrollbar = true;
            this.lbShowItems.ItemHeight = 20;
            this.lbShowItems.Location = new System.Drawing.Point(6, 82);
            this.lbShowItems.Name = "lbShowItems";
            this.lbShowItems.ScrollAlwaysVisible = true;
            this.lbShowItems.Size = new System.Drawing.Size(698, 104);
            this.lbShowItems.TabIndex = 32;

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(181, 45);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(85, 27);
            this.tbPrice.TabIndex = 20;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // rdSummerItem
            // 
            this.rdSummerItem.AutoSize = true;
            this.rdSummerItem.Location = new System.Drawing.Point(564, 28);
            this.rdSummerItem.Name = "rdSummerItem";
            this.rdSummerItem.Size = new System.Drawing.Size(118, 24);
            this.rdSummerItem.TabIndex = 16;
            this.rdSummerItem.Text = "Summar Dish";
            this.rdSummerItem.UseVisualStyleBackColor = true;
            this.rdSummerItem.CheckedChanged += new System.EventHandler(this.rdSummerItem_CheckedChanged);
            // 
            // rdHoildayItem
            // 
            this.rdHoildayItem.AutoSize = true;
            this.rdHoildayItem.Location = new System.Drawing.Point(443, 58);
            this.rdHoildayItem.Name = "rdHoildayItem";
            this.rdHoildayItem.Size = new System.Drawing.Size(115, 24);
            this.rdHoildayItem.TabIndex = 15;
            this.rdHoildayItem.Text = "Hoilday Dish";
            this.rdHoildayItem.UseVisualStyleBackColor = true;
            this.rdHoildayItem.CheckedChanged += new System.EventHandler(this.rdHoildayItem_CheckedChanged);
            // 
            // rdNormalItem
            // 
            this.rdNormalItem.AutoSize = true;
            this.rdNormalItem.Checked = true;
            this.rdNormalItem.Location = new System.Drawing.Point(445, 28);
            this.rdNormalItem.Name = "rdNormalItem";
            this.rdNormalItem.Size = new System.Drawing.Size(113, 24);
            this.rdNormalItem.TabIndex = 14;
            this.rdNormalItem.TabStop = true;
            this.rdNormalItem.Text = "Normal Dish";
            this.rdNormalItem.UseVisualStyleBackColor = true;
            this.rdNormalItem.CheckedChanged += new System.EventHandler(this.rdNormalItem_CheckedChanged);
            // 
            // cbCatergory
            // 
            this.cbCatergory.FormattingEnabled = true;
            this.cbCatergory.Location = new System.Drawing.Point(282, 46);
            this.cbCatergory.Name = "cbCatergory";
            this.cbCatergory.Size = new System.Drawing.Size(157, 28);
            this.cbCatergory.TabIndex = 13;
            this.cbCatergory.SelectedIndexChanged += new System.EventHandler(this.cbCatergory_SelectedIndexChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(18, 45);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(157, 27);
            this.tbName.TabIndex = 11;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbOrderList);
            this.groupBox2.Location = new System.Drawing.Point(6, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(707, 115);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order List";
            // 
            // lbOrderList
            // 
            this.lbOrderList.FormattingEnabled = true;
            this.lbOrderList.HorizontalScrollbar = true;
            this.lbOrderList.ItemHeight = 20;
            this.lbOrderList.Location = new System.Drawing.Point(3, 26);
            this.lbOrderList.Name = "lbOrderList";
            this.lbOrderList.ScrollAlwaysVisible = true;
            this.lbOrderList.Size = new System.Drawing.Size(704, 84);
            this.lbOrderList.TabIndex = 34;
            // 
            // lbShowOrderNumber
            // 
            this.lbShowOrderNumber.AutoSize = true;
            this.lbShowOrderNumber.Location = new System.Drawing.Point(14, 7);
            this.lbShowOrderNumber.Name = "lbShowOrderNumber";
            this.lbShowOrderNumber.Size = new System.Drawing.Size(109, 20);
            this.lbShowOrderNumber.TabIndex = 35;
            this.lbShowOrderNumber.Text = "Order number: ";
            // 
            // lbShowUserWhoMadeOrder
            // 
            this.lbShowUserWhoMadeOrder.AutoSize = true;
            this.lbShowUserWhoMadeOrder.Location = new System.Drawing.Point(209, 7);
            this.lbShowUserWhoMadeOrder.Name = "lbShowUserWhoMadeOrder";
            this.lbShowUserWhoMadeOrder.Size = new System.Drawing.Size(104, 20);
            this.lbShowUserWhoMadeOrder.TabIndex = 36;
            this.lbShowUserWhoMadeOrder.Text = "Order creater: ";
            // 
            // btMakeOrder
            // 
            this.btMakeOrder.Location = new System.Drawing.Point(595, 370);
            this.btMakeOrder.Name = "btMakeOrder";
            this.btMakeOrder.Size = new System.Drawing.Size(118, 29);
            this.btMakeOrder.TabIndex = 37;
            this.btMakeOrder.Text = "Make Order";
            this.btMakeOrder.UseVisualStyleBackColor = true;
            // 
            // UCCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btMakeOrder);
            this.Controls.Add(this.lbShowUserWhoMadeOrder);
            this.Controls.Add(this.lbShowOrderNumber);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCCreateOrder";
            this.Size = new System.Drawing.Size(716, 402);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private TextBox tbPrice;
        private Label label3;
        private Label label1;
        private RadioButton rdSummerItem;
        private RadioButton rdHoildayItem;
        private RadioButton rdNormalItem;
        private ComboBox cbCatergory;
        private TextBox tbName;
        private ListBox lbShowItems;
        private GroupBox groupBox2;
        private ListBox lbOrderList;
        private Label lbShowOrderNumber;
        private Label lbShowUserWhoMadeOrder;
        private Button btMakeOrder;
        private RadioButton rdAll;
    }
}
