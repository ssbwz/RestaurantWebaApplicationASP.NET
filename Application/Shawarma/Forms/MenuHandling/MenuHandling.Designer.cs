namespace Shawarma
{
    partial class MenuHandling
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
            this.btRemove = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.btCreateDish = new System.Windows.Forms.Button();
            this.ucCreateItem = new Shawarma.UCCreateItem();
            this.ucSearchItem = new Shawarma.UCSearchItem();
            this.ucUpdateItem = new Shawarma.UCUpdateItem();
            this.ucRemoveItem = new Shawarma.UCRemoveItem();
            this.btHome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(422, -3);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(142, 57);
            this.btRemove.TabIndex = 9;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(281, -3);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(145, 57);
            this.btUpdate.TabIndex = 8;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btSearch
            // 
            this.btSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSearch.Location = new System.Drawing.Point(136, -3);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(151, 57);
            this.btSearch.TabIndex = 7;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btCreateDish
            // 
            this.btCreateDish.AutoEllipsis = true;
            this.btCreateDish.Location = new System.Drawing.Point(0, -4);
            this.btCreateDish.Name = "btCreateDish";
            this.btCreateDish.Size = new System.Drawing.Size(140, 58);
            this.btCreateDish.TabIndex = 6;
            this.btCreateDish.Text = "Create Dish";
            this.btCreateDish.UseVisualStyleBackColor = true;
            this.btCreateDish.Click += new System.EventHandler(this.btCreateDish_Click);
            // 
            // ucCreateItem
            // 
            this.ucCreateItem.Location = new System.Drawing.Point(0, 56);
            this.ucCreateItem.Name = "ucCreateItem";
            this.ucCreateItem.Size = new System.Drawing.Size(718, 404);
            this.ucCreateItem.TabIndex = 10;
            // 
            // ucSearchItem
            // 
            this.ucSearchItem.Location = new System.Drawing.Point(3, 56);
            this.ucSearchItem.Name = "ucSearchItem";
            this.ucSearchItem.Size = new System.Drawing.Size(718, 404);
            this.ucSearchItem.TabIndex = 11;
            // 
            // ucUpdateItem
            // 
            this.ucUpdateItem.Location = new System.Drawing.Point(0, 56);
            this.ucUpdateItem.Name = "ucUpdateItem";
            this.ucUpdateItem.Size = new System.Drawing.Size(718, 404);
            this.ucUpdateItem.TabIndex = 12;
            // 
            // ucRemoveItem
            // 
            this.ucRemoveItem.Location = new System.Drawing.Point(0, 56);
            this.ucRemoveItem.Name = "ucRemoveItem";
            this.ucRemoveItem.Size = new System.Drawing.Size(718, 404);
            this.ucRemoveItem.TabIndex = 13;
            // 
            // btHome
            // 
            this.btHome.Location = new System.Drawing.Point(559, -3);
            this.btHome.Name = "btHome";
            this.btHome.Size = new System.Drawing.Size(159, 57);
            this.btHome.TabIndex = 14;
            this.btHome.Text = "Home";
            this.btHome.UseVisualStyleBackColor = true;
            this.btHome.Click += new System.EventHandler(this.btHome_Click);
            // 
            // MenuHandling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 457);
            this.Controls.Add(this.btHome);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btCreateDish);
            this.Controls.Add(this.ucUpdateItem);
            this.Controls.Add(this.ucSearchItem);
            this.Controls.Add(this.ucCreateItem);
            this.Controls.Add(this.ucRemoveItem);
            this.Name = "MenuHandling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuHandling";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuHandling_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btRemove;
        private Button btUpdate;
        private Button btSearch;
        private Button btCreateDish;
        private UCCreateItem ucCreateItem;
        private UCSearchItem ucSearchItem;
        private UCUpdateItem ucUpdateItem;
        private UCRemoveItem ucRemoveItem;
        private Button btHome;
    }
}