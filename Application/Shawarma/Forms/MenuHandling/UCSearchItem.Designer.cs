namespace Shawarma
{
    partial class UCSearchItem
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdSummerItem = new System.Windows.Forms.RadioButton();
            this.rdHoildayItem = new System.Windows.Forms.RadioButton();
            this.rdNormalItem = new System.Windows.Forms.RadioButton();
            this.cbCatergory = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbShowItems = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbPrice);
            this.groupBox1.Controls.Add(this.btSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdSummerItem);
            this.groupBox1.Controls.Add(this.rdHoildayItem);
            this.groupBox1.Controls.Add(this.rdNormalItem);
            this.groupBox1.Controls.Add(this.cbCatergory);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 193);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Dish";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(342, 56);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(85, 27);
            this.tbPrice.TabIndex = 20;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(443, 127);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(157, 32);
            this.btSearch.TabIndex = 19;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // rdSummerItem
            // 
            this.rdSummerItem.AutoSize = true;
            this.rdSummerItem.Location = new System.Drawing.Point(0, 135);
            this.rdSummerItem.Name = "rdSummerItem";
            this.rdSummerItem.Size = new System.Drawing.Size(118, 24);
            this.rdSummerItem.TabIndex = 16;
            this.rdSummerItem.Text = "Summar Dish";
            this.rdSummerItem.UseVisualStyleBackColor = true;
            // 
            // rdHoildayItem
            // 
            this.rdHoildayItem.AutoSize = true;
            this.rdHoildayItem.Location = new System.Drawing.Point(0, 92);
            this.rdHoildayItem.Name = "rdHoildayItem";
            this.rdHoildayItem.Size = new System.Drawing.Size(115, 24);
            this.rdHoildayItem.TabIndex = 15;
            this.rdHoildayItem.Text = "Hoilday Dish";
            this.rdHoildayItem.UseVisualStyleBackColor = true;
            // 
            // rdNormalItem
            // 
            this.rdNormalItem.AutoSize = true;
            this.rdNormalItem.Checked = true;
            this.rdNormalItem.Location = new System.Drawing.Point(0, 57);
            this.rdNormalItem.Name = "rdNormalItem";
            this.rdNormalItem.Size = new System.Drawing.Size(113, 24);
            this.rdNormalItem.TabIndex = 14;
            this.rdNormalItem.TabStop = true;
            this.rdNormalItem.Text = "Normal Dish";
            this.rdNormalItem.UseVisualStyleBackColor = true;
            // 
            // cbCatergory
            // 
            this.cbCatergory.FormattingEnabled = true;
            this.cbCatergory.Location = new System.Drawing.Point(443, 57);
            this.cbCatergory.Name = "cbCatergory";
            this.cbCatergory.Size = new System.Drawing.Size(157, 28);
            this.cbCatergory.TabIndex = 13;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(179, 56);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(157, 27);
            this.tbName.TabIndex = 11;
            // 
            // lbShowItems
            // 
            this.lbShowItems.FormattingEnabled = true;
            this.lbShowItems.ItemHeight = 20;
            this.lbShowItems.Location = new System.Drawing.Point(2, 195);
            this.lbShowItems.Name = "lbShowItems";
            this.lbShowItems.Size = new System.Drawing.Size(711, 204);
            this.lbShowItems.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(179, 107);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(248, 52);
            this.tbDescription.TabIndex = 23;
            // 
            // UCSearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbShowItems);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCSearchItem";
            this.Size = new System.Drawing.Size(716, 402);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private TextBox tbPrice;
        private Button btSearch;
        private Label label3;
        private Label label1;
        private RadioButton rdSummerItem;
        private RadioButton rdHoildayItem;
        private RadioButton rdNormalItem;
        private ComboBox cbCatergory;
        private TextBox tbName;
        private ListBox lbShowItems;
        private Label label2;
        private TextBox tbDescription;
    }
}
