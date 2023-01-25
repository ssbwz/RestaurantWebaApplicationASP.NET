using MySql.Data.MySqlClient;
using DataAccessLayer.Interfaces;
using Shawarma.Enum;
using Shawarma.Logic;
using Shawarma.Models;
using Shawarma.DataAccess;

namespace Shawarma.Forms.UserHandling
{
    public partial class UCCreateUser : UserControl
    {
        private PersonManager personManager;
        private SecurityManager securityManager = new SecurityManager();


        public UCCreateUser()
        {
            InitializeComponent();
            try
            {
                IPersonRepository repository = new PersonStorage();
                personManager = new PersonManager(repository);
            }
            catch (Exception)
            {
                Connection.CloseConnection();
            }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = tbFirstName.Text;
                string lastName = tbLastName.Text;
                string email = tbEmail.Text;
                string phoneNumeber = tbPhoneNumber.Text;
                string username = tbUsername.Text;
                string password = tbPassword.Text;

                if (string.IsNullOrEmpty(firstName))
                {
                    Message message = new Message("Please fill the first name.");
                    message.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(lastName))
                {
                    Message message = new Message("Please fill the last name.");
                    message.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(email))
                {
                    Message message = new Message("Please fill the email.");
                    message.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(phoneNumeber))
                {
                    Message message = new Message("Please fill the phone number.");
                    message.ShowDialog();
                    return;
                }

                if (!decimal.TryParse(phoneNumeber, out decimal phoneNumberInInt))
                {
                    Message message = new Message("Please fill the number in phone number field.");
                    message.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(username))
                {
                    Message message = new Message("Please fill the username.");
                    message.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    Message message = new Message("Please fill the password.");
                    message.ShowDialog();
                    return;
                }
                Person person = new Person(getSelectedType(), firstName, lastName, phoneNumeber, email, username, password);

                person.Salt = securityManager.GetNewSalt();
                person.Password = securityManager.GetHashWithSalt(person.Password, person.Salt);


                if (!personManager.AddPerson(person))
                {
                    if (personManager.GetPersonByUsername(username) != null)
                    {
                        Message message = new Message("The username already exist.");
                        message.ShowDialog();
                        return;
                    }
                    if (personManager.GetPersonByEmail(email) != null)
                    {

                    }
                }

                Message newMessage = new Message("Person created successfully.");
                newMessage.ShowDialog();
                CleanTextBoxs();
                printPerons(lbShowPersons, personManager.GetPersons(), "Name");
                return;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("PhoneNumber"))
                {
                    Message message = new Message("The phone number already exist.");
                    message.ShowDialog();
                }
                else if (ex.Message.Contains("Email"))
                {
                    Message message = new Message("The email already exist.");
                    message.ShowDialog();
                    return;
                }
                else if (ex.Message.Contains("Fatal"))
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

        private void CleanTextBoxs()
        {
            try
            {
                tbFirstName.Clear();
                tbLastName.Clear();
                tbEmail.Clear();
                tbPhoneNumber.Clear();
                tbUsername.Clear();
                tbPassword.Clear();
            }
            catch (Exception)
            {
                Message newMessage1 = new Message("Something went wrong.");
                newMessage1.ShowDialog();
            }
        }

        private void printPerons(ListBox listBox, List<Person> persons, string type)
        {
            listBox.Items.Clear();
            if (persons == null || listBox == null)
            {
                return;
            }
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
