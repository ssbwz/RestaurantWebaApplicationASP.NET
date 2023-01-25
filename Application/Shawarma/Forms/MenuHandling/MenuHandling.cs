using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shawarma.DataAccess;

namespace Shawarma
{
    public partial class MenuHandling : Form
    {   
        public MenuHandling()
        {
            InitializeComponent();
            ucCreateItem.Visible = false;
            ucSearchItem.Visible = false;
            ucUpdateItem.Visible = false;
            ucRemoveItem.Visible = false;
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

        private void btCreateDish_Click(object sender, EventArgs e)
        {
            flibing(ucCreateItem);
            ucSearchItem.Visible = false;
            ucUpdateItem.Visible = false;
            ucRemoveItem.Visible = false;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            flibing(ucSearchItem);
            ucCreateItem.Visible = false;
            ucUpdateItem.Visible = false;
            ucRemoveItem.Visible = false;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            flibing(ucUpdateItem);
            ucCreateItem.Visible = false;
            ucSearchItem.Visible = false;
            ucRemoveItem.Visible = false;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            flibing(ucRemoveItem);
            ucCreateItem.Visible=false;
            ucSearchItem.Visible = false;
            ucUpdateItem.Visible = false;
        }

        private void flibing(UserControl userControl)
        {
            if (userControl.Visible == false)
            {
                userControl.Visible = true;
                return;
            }

            if (userControl.Visible == true)
            {
                userControl.Visible = false;
                return;
            }
        }

        private void MenuHandling_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to close the application?",
                    "Shawarma",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                   // Connection.CloseConnection();
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }
        }
        
    }
}
