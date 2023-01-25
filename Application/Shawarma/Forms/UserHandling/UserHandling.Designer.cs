namespace Shawarma
{
    partial class UserHandling
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
            this.btCreateUser = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btHome = new System.Windows.Forms.Button();
            this.ucUserRemove = new Shawarma.UCUserRemove();
            this.ucCreateUser = new Shawarma.Forms.UserHandling.UCCreateUser();
            this.ucSearchUser = new Shawarma.Forms.UserHandling.UCSearchUser();
            this.ucUpdateUser = new Shawarma.UCUpdateUser();
            this.SuspendLayout();
            // 
            // btCreateUser
            // 
            this.btCreateUser.AutoEllipsis = true;
            this.btCreateUser.Location = new System.Drawing.Point(0, -4);
            this.btCreateUser.Name = "btCreateUser";
            this.btCreateUser.Size = new System.Drawing.Size(142, 57);
            this.btCreateUser.TabIndex = 2;
            this.btCreateUser.Text = "Create User";
            this.btCreateUser.UseVisualStyleBackColor = true;
            this.btCreateUser.Click += new System.EventHandler(this.btCreateUser_Click);
            // 
            // btSearch
            // 
            this.btSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSearch.Location = new System.Drawing.Point(135, -3);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(142, 57);
            this.btSearch.TabIndex = 3;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(271, -3);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(142, 57);
            this.btUpdate.TabIndex = 4;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(407, -3);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(142, 57);
            this.btRemove.TabIndex = 5;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btHome
            // 
            this.btHome.Location = new System.Drawing.Point(544, -3);
            this.btHome.Name = "btHome";
            this.btHome.Size = new System.Drawing.Size(155, 57);
            this.btHome.TabIndex = 10;
            this.btHome.Text = "Home";
            this.btHome.UseVisualStyleBackColor = true;
            this.btHome.Click += new System.EventHandler(this.btHome_Click);
            // 
            // ucUserRemove
            // 
            this.ucUserRemove.Location = new System.Drawing.Point(0, 59);
            this.ucUserRemove.Name = "ucUserRemove";
            this.ucUserRemove.Size = new System.Drawing.Size(699, 394);
            this.ucUserRemove.TabIndex = 13;
            // 
            // ucCreateUser
            // 
            this.ucCreateUser.Location = new System.Drawing.Point(0, 49);
            this.ucCreateUser.Name = "ucCreateUser";
            this.ucCreateUser.Size = new System.Drawing.Size(699, 391);
            this.ucCreateUser.TabIndex = 14;
            // 
            // ucSearchUser
            // 
            this.ucSearchUser.Location = new System.Drawing.Point(0, 49);
            this.ucSearchUser.Name = "ucSearchUser";
            this.ucSearchUser.Size = new System.Drawing.Size(699, 391);
            this.ucSearchUser.TabIndex = 15;
            // 
            // ucUpdateUser
            // 
            this.ucUpdateUser.Location = new System.Drawing.Point(0, 49);
            this.ucUpdateUser.Name = "ucUpdateUser";
            this.ucUpdateUser.Size = new System.Drawing.Size(699, 391);
            this.ucUpdateUser.TabIndex = 16;
            // 
            // UserHandling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(699, 441);
            this.Controls.Add(this.ucUpdateUser);
            this.Controls.Add(this.ucSearchUser);
            this.Controls.Add(this.ucCreateUser);
            this.Controls.Add(this.ucUserRemove);
            this.Controls.Add(this.btHome);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btCreateUser);
            this.Name = "UserHandling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserHandling";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserHandling_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private Button btCreateUser;
        private Button btSearch;
        private Button btUpdate;
        private Button btRemove;
        private Button btHome;
        private UCUserRemove ucUserRemove;
        private Forms.UserHandling.UCCreateUser ucCreateUser;
        private Forms.UserHandling.UCSearchUser ucSearchUser;
        private UCUpdateUser ucUpdateUser;
    }
}