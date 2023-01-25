namespace Shawarma
{
    partial class Home
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
            this.btUserFrom = new System.Windows.Forms.Button();
            this.btOrderForm = new System.Windows.Forms.Button();
            this.btMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btUserFrom
            // 
            this.btUserFrom.AutoSize = true;
            this.btUserFrom.Location = new System.Drawing.Point(-3, 403);
            this.btUserFrom.Name = "btUserFrom";
            this.btUserFrom.Size = new System.Drawing.Size(267, 46);
            this.btUserFrom.TabIndex = 3;
            this.btUserFrom.Text = "Users";
            this.btUserFrom.UseVisualStyleBackColor = true;
            this.btUserFrom.Click += new System.EventHandler(this.btUserFrom_Click_1);
            // 
            // btOrderForm
            // 
            this.btOrderForm.AutoSize = true;
            this.btOrderForm.Location = new System.Drawing.Point(254, 403);
            this.btOrderForm.Name = "btOrderForm";
            this.btOrderForm.Size = new System.Drawing.Size(280, 46);
            this.btOrderForm.TabIndex = 4;
            this.btOrderForm.Text = "Orders";
            this.btOrderForm.UseVisualStyleBackColor = true;
            this.btOrderForm.Click += new System.EventHandler(this.btOrderForm_Click);
            // 
            // btMenu
            // 
            this.btMenu.AutoSize = true;
            this.btMenu.Location = new System.Drawing.Point(530, 403);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(270, 46);
            this.btMenu.TabIndex = 5;
            this.btMenu.Text = "Menu";
            this.btMenu.UseVisualStyleBackColor = true;
            this.btMenu.Click += new System.EventHandler(this.btMenu_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btMenu);
            this.Controls.Add(this.btOrderForm);
            this.Controls.Add(this.btUserFrom);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btUserFrom;
        private Button btOrderForm;
        private Button btMenu;
    }
}