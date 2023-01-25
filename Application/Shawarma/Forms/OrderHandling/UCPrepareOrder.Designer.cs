namespace Shawarma.Forms.OrderHandling
{
    partial class UCPrepareOrder
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
            this.lbShowOrder = new System.Windows.Forms.ListBox();
            this.lbShowItems = new System.Windows.Forms.ListBox();
            this.rbAccepted = new System.Windows.Forms.RadioButton();
            this.rbPreparing = new System.Windows.Forms.RadioButton();
            this.rbDone = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbSent = new System.Windows.Forms.RadioButton();
            this.btChangeStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbShowOrder
            // 
            this.lbShowOrder.FormattingEnabled = true;
            this.lbShowOrder.HorizontalScrollbar = true;
            this.lbShowOrder.ItemHeight = 20;
            this.lbShowOrder.Location = new System.Drawing.Point(3, 83);
            this.lbShowOrder.Name = "lbShowOrder";
            this.lbShowOrder.ScrollAlwaysVisible = true;
            this.lbShowOrder.Size = new System.Drawing.Size(698, 104);
            this.lbShowOrder.TabIndex = 33;
            this.lbShowOrder.DoubleClick += new System.EventHandler(this.lbShowOrder_DoubleClick);
            // 
            // lbShowItems
            // 
            this.lbShowItems.FormattingEnabled = true;
            this.lbShowItems.HorizontalScrollbar = true;
            this.lbShowItems.ItemHeight = 20;
            this.lbShowItems.Location = new System.Drawing.Point(3, 229);
            this.lbShowItems.Name = "lbShowItems";
            this.lbShowItems.ScrollAlwaysVisible = true;
            this.lbShowItems.Size = new System.Drawing.Size(698, 164);
            this.lbShowItems.TabIndex = 34;
            // 
            // rbAccepted
            // 
            this.rbAccepted.AutoSize = true;
            this.rbAccepted.Enabled = false;
            this.rbAccepted.Location = new System.Drawing.Point(202, 25);
            this.rbAccepted.Name = "rbAccepted";
            this.rbAccepted.Size = new System.Drawing.Size(93, 24);
            this.rbAccepted.TabIndex = 37;
            this.rbAccepted.Text = "Accepted";
            this.rbAccepted.UseVisualStyleBackColor = true;
            // 
            // rbPreparing
            // 
            this.rbPreparing.AutoSize = true;
            this.rbPreparing.Enabled = false;
            this.rbPreparing.Location = new System.Drawing.Point(337, 25);
            this.rbPreparing.Name = "rbPreparing";
            this.rbPreparing.Size = new System.Drawing.Size(94, 24);
            this.rbPreparing.TabIndex = 38;
            this.rbPreparing.Text = "Preparing";
            this.rbPreparing.UseVisualStyleBackColor = true;
            // 
            // rbDone
            // 
            this.rbDone.AutoSize = true;
            this.rbDone.Enabled = false;
            this.rbDone.Location = new System.Drawing.Point(497, 25);
            this.rbDone.Name = "rbDone";
            this.rbDone.Size = new System.Drawing.Size(66, 24);
            this.rbDone.TabIndex = 39;
            this.rbDone.Text = "Done";
            this.rbDone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Items";
            // 
            // rbSent
            // 
            this.rbSent.AutoSize = true;
            this.rbSent.Enabled = false;
            this.rbSent.Location = new System.Drawing.Point(51, 25);
            this.rbSent.Name = "rbSent";
            this.rbSent.Size = new System.Drawing.Size(59, 24);
            this.rbSent.TabIndex = 36;
            this.rbSent.Text = "Sent";
            this.rbSent.UseVisualStyleBackColor = true;
            // 
            // btChangeStatus
            // 
            this.btChangeStatus.Location = new System.Drawing.Point(578, 48);
            this.btChangeStatus.Name = "btChangeStatus";
            this.btChangeStatus.Size = new System.Drawing.Size(123, 29);
            this.btChangeStatus.TabIndex = 42;
            this.btChangeStatus.Text = "Change Status";
            this.btChangeStatus.UseVisualStyleBackColor = true;
            this.btChangeStatus.Click += new System.EventHandler(this.btChangeStatus_Click);
            // 
            // UCPrepareOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btChangeStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbDone);
            this.Controls.Add(this.rbPreparing);
            this.Controls.Add(this.rbAccepted);
            this.Controls.Add(this.rbSent);
            this.Controls.Add(this.lbShowItems);
            this.Controls.Add(this.lbShowOrder);
            this.Name = "UCPrepareOrder";
            this.Size = new System.Drawing.Size(716, 402);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbShowOrder;
        private ListBox lbShowItems;
        private RadioButton rbAccepted;
        private RadioButton rbPreparing;
        private RadioButton rbDone;
        private Label label1;
        private Label label2;
        private RadioButton rbSent;
        private Button btChangeStatus;
    }
}
