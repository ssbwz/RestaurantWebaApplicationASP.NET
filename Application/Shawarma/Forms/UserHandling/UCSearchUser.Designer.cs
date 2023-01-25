namespace Shawarma.Forms.UserHandling
{
    partial class UCSearchUser
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
            this.btSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.lbShowPersons = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdClient = new System.Windows.Forms.RadioButton();
            this.rdEmployee = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(524, 89);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(145, 29);
            this.btSearch.TabIndex = 43;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Phone number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "First Name";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(340, 89);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(125, 27);
            this.tbUsername.TabIndex = 37;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(524, 34);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(145, 27);
            this.tbPhoneNumber.TabIndex = 36;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(340, 34);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(125, 27);
            this.tbEmail.TabIndex = 35;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(182, 34);
            this.tbLastName.MaxLength = 40;
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(125, 27);
            this.tbLastName.TabIndex = 34;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(10, 34);
            this.tbFirstName.MaxLength = 40;
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(125, 27);
            this.tbFirstName.TabIndex = 33;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Location = new System.Drawing.Point(117, 114);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(74, 24);
            this.rbAdmin.TabIndex = 48;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Admin";
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // lbShowPersons
            // 
            this.lbShowPersons.FormattingEnabled = true;
            this.lbShowPersons.HorizontalScrollbar = true;
            this.lbShowPersons.ItemHeight = 20;
            this.lbShowPersons.Location = new System.Drawing.Point(10, 155);
            this.lbShowPersons.Name = "lbShowPersons";
            this.lbShowPersons.ScrollAlwaysVisible = true;
            this.lbShowPersons.Size = new System.Drawing.Size(677, 204);
            this.lbShowPersons.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "User Type:";
            // 
            // rdClient
            // 
            this.rdClient.AutoSize = true;
            this.rdClient.Checked = true;
            this.rdClient.Location = new System.Drawing.Point(239, 84);
            this.rdClient.Name = "rdClient";
            this.rdClient.Size = new System.Drawing.Size(68, 24);
            this.rdClient.TabIndex = 45;
            this.rdClient.TabStop = true;
            this.rdClient.Text = "Client";
            this.rdClient.UseVisualStyleBackColor = true;
            // 
            // rdEmployee
            // 
            this.rdEmployee.AutoSize = true;
            this.rdEmployee.Location = new System.Drawing.Point(117, 84);
            this.rdEmployee.Name = "rdEmployee";
            this.rdEmployee.Size = new System.Drawing.Size(96, 24);
            this.rdEmployee.TabIndex = 44;
            this.rdEmployee.TabStop = true;
            this.rdEmployee.Text = "Employee";
            this.rdEmployee.UseVisualStyleBackColor = true;
            // 
            // UCSearchUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbAdmin);
            this.Controls.Add(this.lbShowPersons);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdClient);
            this.Controls.Add(this.rdEmployee);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbPhoneNumber);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.Name = "UCSearchUser";
            this.Size = new System.Drawing.Size(697, 381);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btSearch;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox tbUsername;
        private TextBox tbPhoneNumber;
        private TextBox tbEmail;
        private TextBox tbLastName;
        private TextBox tbFirstName;
        private RadioButton rbAdmin;
        private ListBox lbShowPersons;
        private Label label1;
        private RadioButton rdClient;
        private RadioButton rdEmployee;
    }
}
