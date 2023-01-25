namespace Shawarma
{
    partial class OrderHandling
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
            this.ucPrepareOrder1 = new Shawarma.Forms.OrderHandling.UCPrepareOrder();
            this.label1 = new System.Windows.Forms.Label();
            this.btHome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucPrepareOrder1
            // 
            this.ucPrepareOrder1.Location = new System.Drawing.Point(-2, 49);
            this.ucPrepareOrder1.Name = "ucPrepareOrder1";
            this.ucPrepareOrder1.Size = new System.Drawing.Size(705, 394);
            this.ucPrepareOrder1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Preparing Order";
            // 
            // btHome
            // 
            this.btHome.Location = new System.Drawing.Point(548, 0);
            this.btHome.Name = "btHome";
            this.btHome.Size = new System.Drawing.Size(155, 46);
            this.btHome.TabIndex = 11;
            this.btHome.Text = "Home";
            this.btHome.UseVisualStyleBackColor = true;
            this.btHome.Click += new System.EventHandler(this.btHome_Click);
            // 
            // OrderHandling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 441);
            this.Controls.Add(this.btHome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucPrepareOrder1);
            this.Name = "OrderHandling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderHandling";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderHandling_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UCCreateOrder ucCreateOrder;
        private Forms.OrderHandling.UCPrepareOrder ucPrepareOrder1;
        private Label label1;
        private Button btHome;
    }
}