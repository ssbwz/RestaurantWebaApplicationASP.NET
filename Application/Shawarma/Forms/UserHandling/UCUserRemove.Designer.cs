namespace Shawarma
{
    partial class UCUserRemove
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
            this.lbShowPersons = new System.Windows.Forms.ListBox();
            this.gbDelete = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIdFind = new System.Windows.Forms.TextBox();
            this.btFind = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUsernameFind = new System.Windows.Forms.TextBox();
            this.tbPhoneNumberFind = new System.Windows.Forms.TextBox();
            this.tbEmailFind = new System.Windows.Forms.TextBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEmailSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbfirstNameSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLastNameSearch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPhoneNumberSearch = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbUsernameSearch = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rbEmployeeSearch = new System.Windows.Forms.RadioButton();
            this.rdClientSearch = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.gbDelete.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbShowPersons
            // 
            this.lbShowPersons.FormattingEnabled = true;
            this.lbShowPersons.HorizontalScrollbar = true;
            this.lbShowPersons.ItemHeight = 20;
            this.lbShowPersons.Location = new System.Drawing.Point(16, 156);
            this.lbShowPersons.Name = "lbShowPersons";
            this.lbShowPersons.ScrollAlwaysVisible = true;
            this.lbShowPersons.Size = new System.Drawing.Size(684, 64);
            this.lbShowPersons.TabIndex = 41;
            this.lbShowPersons.DoubleClick += new System.EventHandler(this.lbShowPersons_DoubleClick);
            // 
            // gbDelete
            // 
            this.gbDelete.Controls.Add(this.label2);
            this.gbDelete.Controls.Add(this.tbIdFind);
            this.gbDelete.Controls.Add(this.btFind);
            this.gbDelete.Controls.Add(this.lbInfo);
            this.gbDelete.Controls.Add(this.btDelete);
            this.gbDelete.Controls.Add(this.label6);
            this.gbDelete.Controls.Add(this.label5);
            this.gbDelete.Controls.Add(this.label4);
            this.gbDelete.Controls.Add(this.tbUsernameFind);
            this.gbDelete.Controls.Add(this.tbPhoneNumberFind);
            this.gbDelete.Controls.Add(this.tbEmailFind);
            this.gbDelete.Location = new System.Drawing.Point(16, 218);
            this.gbDelete.Name = "gbDelete";
            this.gbDelete.Size = new System.Drawing.Size(684, 147);
            this.gbDelete.TabIndex = 40;
            this.gbDelete.TabStop = false;
            this.gbDelete.Text = "Delete";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "ID";
            // 
            // tbIdFind
            // 
            this.tbIdFind.Location = new System.Drawing.Point(7, 50);
            this.tbIdFind.Name = "tbIdFind";
            this.tbIdFind.Size = new System.Drawing.Size(76, 27);
            this.tbIdFind.TabIndex = 38;
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(520, 48);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(145, 29);
            this.btFind.TabIndex = 37;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(4, 102);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(101, 20);
            this.lbInfo.TabIndex = 36;
            this.lbInfo.Text = "User Info here";
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(520, 98);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(145, 29);
            this.btDelete.TabIndex = 35;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Phone number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Email";
            // 
            // tbUsernameFind
            // 
            this.tbUsernameFind.Location = new System.Drawing.Point(95, 50);
            this.tbUsernameFind.Name = "tbUsernameFind";
            this.tbUsernameFind.Size = new System.Drawing.Size(125, 27);
            this.tbUsernameFind.TabIndex = 23;
            // 
            // tbPhoneNumberFind
            // 
            this.tbPhoneNumberFind.Location = new System.Drawing.Point(357, 50);
            this.tbPhoneNumberFind.Name = "tbPhoneNumberFind";
            this.tbPhoneNumberFind.Size = new System.Drawing.Size(145, 27);
            this.tbPhoneNumberFind.TabIndex = 22;
            // 
            // tbEmailFind
            // 
            this.tbEmailFind.Location = new System.Drawing.Point(226, 50);
            this.tbEmailFind.Name = "tbEmailFind";
            this.tbEmailFind.Size = new System.Drawing.Size(125, 27);
            this.tbEmailFind.TabIndex = 21;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.rbAdmin);
            this.gbSearch.Controls.Add(this.btSearch);
            this.gbSearch.Controls.Add(this.label8);
            this.gbSearch.Controls.Add(this.tbEmailSearch);
            this.gbSearch.Controls.Add(this.label9);
            this.gbSearch.Controls.Add(this.tbfirstNameSearch);
            this.gbSearch.Controls.Add(this.label10);
            this.gbSearch.Controls.Add(this.tbLastNameSearch);
            this.gbSearch.Controls.Add(this.label11);
            this.gbSearch.Controls.Add(this.tbPhoneNumberSearch);
            this.gbSearch.Controls.Add(this.label12);
            this.gbSearch.Controls.Add(this.tbUsernameSearch);
            this.gbSearch.Controls.Add(this.label13);
            this.gbSearch.Controls.Add(this.rbEmployeeSearch);
            this.gbSearch.Controls.Add(this.rdClientSearch);
            this.gbSearch.Location = new System.Drawing.Point(16, 10);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(685, 140);
            this.gbSearch.TabIndex = 39;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(520, 98);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(145, 29);
            this.btSearch.TabIndex = 36;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "Username";
            // 
            // tbEmailSearch
            // 
            this.tbEmailSearch.Location = new System.Drawing.Point(337, 47);
            this.tbEmailSearch.Name = "tbEmailSearch";
            this.tbEmailSearch.Size = new System.Drawing.Size(125, 27);
            this.tbEmailSearch.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(521, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 47;
            this.label9.Text = "Phone number";
            // 
            // tbfirstNameSearch
            // 
            this.tbfirstNameSearch.Location = new System.Drawing.Point(7, 47);
            this.tbfirstNameSearch.MaxLength = 40;
            this.tbfirstNameSearch.Name = "tbfirstNameSearch";
            this.tbfirstNameSearch.Size = new System.Drawing.Size(125, 27);
            this.tbfirstNameSearch.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(337, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 46;
            this.label10.Text = "Email";
            // 
            // tbLastNameSearch
            // 
            this.tbLastNameSearch.Location = new System.Drawing.Point(179, 47);
            this.tbLastNameSearch.MaxLength = 40;
            this.tbLastNameSearch.Name = "tbLastNameSearch";
            this.tbLastNameSearch.Size = new System.Drawing.Size(125, 27);
            this.tbLastNameSearch.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(179, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 45;
            this.label11.Text = "Last Name";
            // 
            // tbPhoneNumberSearch
            // 
            this.tbPhoneNumberSearch.Location = new System.Drawing.Point(521, 47);
            this.tbPhoneNumberSearch.Name = "tbPhoneNumberSearch";
            this.tbPhoneNumberSearch.Size = new System.Drawing.Size(145, 27);
            this.tbPhoneNumberSearch.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 44;
            this.label12.Text = "First Name";
            // 
            // tbUsernameSearch
            // 
            this.tbUsernameSearch.Location = new System.Drawing.Point(337, 102);
            this.tbUsernameSearch.Name = "tbUsernameSearch";
            this.tbUsernameSearch.Size = new System.Drawing.Size(125, 27);
            this.tbUsernameSearch.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 20);
            this.label13.TabIndex = 43;
            this.label13.Text = "User Type:";
            // 
            // rbEmployeeSearch
            // 
            this.rbEmployeeSearch.AutoSize = true;
            this.rbEmployeeSearch.Location = new System.Drawing.Point(89, 80);
            this.rbEmployeeSearch.Name = "rbEmployeeSearch";
            this.rbEmployeeSearch.Size = new System.Drawing.Size(96, 24);
            this.rbEmployeeSearch.TabIndex = 41;
            this.rbEmployeeSearch.Text = "Employee";
            this.rbEmployeeSearch.UseVisualStyleBackColor = true;
            // 
            // rdClientSearch
            // 
            this.rdClientSearch.AutoSize = true;
            this.rdClientSearch.Checked = true;
            this.rdClientSearch.Location = new System.Drawing.Point(204, 82);
            this.rdClientSearch.Name = "rdClientSearch";
            this.rdClientSearch.Size = new System.Drawing.Size(68, 24);
            this.rdClientSearch.TabIndex = 42;
            this.rdClientSearch.TabStop = true;
            this.rdClientSearch.Text = "Client";
            this.rdClientSearch.UseVisualStyleBackColor = true;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Location = new System.Drawing.Point(89, 110);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(74, 24);
            this.rbAdmin.TabIndex = 49;
            this.rbAdmin.Text = "Admin";
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // UCUserRemove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbShowPersons);
            this.Controls.Add(this.gbDelete);
            this.Controls.Add(this.gbSearch);
            this.Name = "UCUserRemove";
            this.Size = new System.Drawing.Size(716, 402);
            this.gbDelete.ResumeLayout(false);
            this.gbDelete.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbShowPersons;
        private GroupBox gbDelete;
        private Button btDelete;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox tbUsernameFind;
        private TextBox tbPhoneNumberFind;
        private TextBox tbEmailFind;
        private GroupBox gbSearch;
        private Button btSearch;
        private Label label8;
        private TextBox tbEmailSearch;
        private Label label9;
        private TextBox tbfirstNameSearch;
        private Label label10;
        private TextBox tbLastNameSearch;
        private Label label11;
        private TextBox tbPhoneNumberSearch;
        private Label label12;
        private TextBox tbUsernameSearch;
        private Label label13;
        private RadioButton rbEmployeeSearch;
        private RadioButton rdClientSearch;
        private Label label2;
        private TextBox tbIdFind;
        private Button btFind;
        private Label lbInfo;
        private RadioButton rbAdmin;
    }
}
