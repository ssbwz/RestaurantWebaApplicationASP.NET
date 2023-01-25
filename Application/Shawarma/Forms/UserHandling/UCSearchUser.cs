
using Shawarma.DataAccess;
using Shawarma.Enum;
using Shawarma.Logic;
using Shawarma.Models;
using MySql.Data.MySqlClient;
using DataAccessLayer.Interfaces;

namespace Shawarma.Forms.UserHandling
{
    public partial class UCSearchUser : UserControl
    {
        private PersonManager personManager;
        private IPersonRepository repostiroy = new PersonStorage();

        public UCSearchUser()
        {
            try
            {
                InitializeComponent();

                personManager = new PersonManager(repostiroy);
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                Message newMessage1 = new Message("Something went wrong.");
                newMessage1.ShowDialog();
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = tbFirstName.Text;
                string lastName = tbLastName.Text;
                string email = tbEmail.Text;
                string phoneNumeber = tbPhoneNumber.Text;
                string username = tbUsername.Text;
                List<Person> persons = personManager.SearchPerson(firstName, lastName, email, phoneNumeber, username, getSelectedType().ToString());
                printPerons(lbShowPersons, persons, "All");
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Fatal"))
                {
                    Message message = new Message("Connection Error make sure that you are connected.");
                    message.ShowDialog();
                    Connection.CloseConnection();
                    return;
                }
            }
            catch (AggregateException)
            {
                Message message = new Message("Connection Error make sure that you are connected.");
                message.ShowDialog();
                Connection.CloseConnection();
            }
            catch (InvalidOperationException)
            {
                Message newMessage = new Message("Connection Error make sure that you are connected.");
                newMessage.ShowDialog();
                Connection.CloseConnection();
            }
            catch (Exception)
            {
                Message newMessage1 = new Message("Something went wrong.");
                newMessage1.ShowDialog();
                Connection.CloseConnection();
            }
        }

        public void printPerons(ListBox listBox, List<Person> persons, string type)
        {
                listBox.Items.Clear();
                foreach (Person person in persons)
                {
                    listBox.Items.Add(person.ToString(type));
                }
        }

        private UserType getSelectedType()
        {
            if (rdClient.Checked)
            {
                return UserType.CLIENT;
            }
            else if (rdEmployee.Checked)
            {
                return UserType.EMPLOYEE;
            }
            else
            {
                return UserType.ADMIN;
            }
        }
    }
}
