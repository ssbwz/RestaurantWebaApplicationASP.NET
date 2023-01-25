
using Shawarma.DataAccess;
using Shawarma.Logic;
using Shawarma.Models;
using Shawarma.Enum;

namespace Shawarma
{
    public partial class Login : Form
     {
        //ToDo: Remove the static Manager
        public static ItemManager ItemManager = new ItemManager();
         public static OrderManager OrderManager = new OrderManager();
         public static NavigationManager Navigation = new NavigationManager();
         public static Person CurrentPerson;

         public Login()
         {
             InitializeComponent();
         }

         private void btLogin_Click(object sender, EventArgs e)
         {
             if (string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrEmpty(tbPassword.Text))
             {
                 Message newMeesage = new Message("Please fill the Username and the Password");
                 newMeesage.ShowDialog();
                 return;
             }

             string username = tbUserName.Text;
             string password = tbPassword.Text;

             CurrentPerson = Navigation.GivingAccess(username, password);

            if (CurrentPerson == null)
            {
                Message newMessage = new Message("Please check the Username and the Password");
                newMessage.ShowDialog();
                return;
            }
            /*else if (CurrentPerson.UserType == UserType.CLIENT)
            {
                Message newMessage = new Message("You can't log in with client account");
                newMessage.ShowDialog();
                return;
            }*/
            else
            {
                Home home = new Home();
                this.Hide();
                home.ShowDialog();
                this.Close();
            }
         }

         private void lbHavingTroubles_DoubleClick(object sender, EventArgs e)
         {
             Message newMeesage = new Message("Please Contact the admin to help you");
             newMeesage.ShowDialog();
         }

         private void Login_FormClosing(object sender, FormClosingEventArgs e)
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
             }}
        
         }
     }




