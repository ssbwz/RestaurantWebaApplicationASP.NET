using Shawarma.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shawarma
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btUserFrom_Click_1(object sender, EventArgs e)
        {
            if (Login.CurrentPerson.UserType == Enum.UserType.EMPLOYEE)
            {
                Message newMessage = new Message("You don't have access to user management");
                newMessage.ShowDialog();
                return;
            }
            UserHandling newUserHandling = new UserHandling();
            this.Hide();
            newUserHandling.ShowDialog();
            this.Close();
        }

        private void btMenu_Click(object sender, EventArgs e)
        {
            if(Login.CurrentPerson.UserType == Enum.UserType.EMPLOYEE) 
            {
                Message newMessage = new Message("You don't have access to menu");
                newMessage.ShowDialog();
                return;
            }
            MenuHandling newMenuHandling = new MenuHandling();
            this.Hide();
            newMenuHandling.ShowDialog();
            this.Close();
        }

        private void btOrderForm_Click(object sender, EventArgs e)
        {
            OrderHandling newOrderHandling = new OrderHandling();
            this.Hide();
            newOrderHandling.ShowDialog();
            this.Close();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
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
                    Connection.CloseConnection();
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }
        }
        
    }
}
