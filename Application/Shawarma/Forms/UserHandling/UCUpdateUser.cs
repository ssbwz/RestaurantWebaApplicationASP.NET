using Shawarma.DataAccess;
using Shawarma.Enum;
using Shawarma.Logic;
using Shawarma.Models;
using MySql.Data.MySqlClient;
using DataAccessLayer.Interfaces;

namespace Shawarma
{
    public partial class UCUpdateUser : UserControl
    {
        private Person adjustedPerson;
        private List<Person> persons;
        private PersonManager personManager;
        private IPersonRepository repository = new PersonStorage();
        private SecurityManager securityManager = new SecurityManager();

        public UCUpdateUser()
        {
            try
            {
                InitializeComponent();
                UserInfoLocking(lbShowPersons.SelectedIndex);
                personManager = new PersonManager(repository);
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = tbfirstNameSearch.Text;
                string lastName = tbLastNameSearch.Text;
                string email = tbEmailSearch.Text;
                string phoneNumeber = tbPhoneNumberSearch.Text;
                string username = tbUsernameSearch.Text;

                persons = personManager.SearchPerson(firstName, lastName, email, phoneNumeber, username, getSelectedTypeForSearch().ToString());

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

        private void lbShowPersons_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lbShowPersons.Items.Count == 0)
                {
                    Message newMessage = new Message("There are no users in the list.");
                    newMessage.ShowDialog();
                    return;
                }
                adjustedPerson = personManager.GetPersonId(GetIDInListBox(lbShowPersons));

                if (adjustedPerson == null)
                {
                    Message newMessage = new Message("Please select user.");
                    newMessage.ShowDialog();
                    return;
                }
                UserInfoLocking(lbShowPersons.SelectedIndex);
                tbFirstName.Text = adjustedPerson.FirstName;
                tbLastName.Text = adjustedPerson.LastName;
                tbEmail.Text = adjustedPerson.Email;
                tbPhoneNumber.Text = adjustedPerson.PhoneNumber;
                tbUsername.Text = adjustedPerson.Username;
                if (adjustedPerson.UserType == UserType.EMPLOYEE)
                {
                    rdEmployee.Checked = true;
                }
                else if (adjustedPerson.UserType == UserType.CLIENT)
                {
                    rdClient.Checked = true;
                }
                else
                {
                    rbAdmin.Checked = true;
                }
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

        private void btSave_Click(object sender, EventArgs e)
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

                adjustedPerson.FirstName = firstName;
                adjustedPerson.LastName = lastName;
                adjustedPerson.Email = email;
                adjustedPerson.PhoneNumber = phoneNumeber;
                adjustedPerson.Username = username;

                if (!string.IsNullOrEmpty(password)) {
                    adjustedPerson.Password = securityManager.GetHashWithSalt(password,adjustedPerson.Salt);
                }

                adjustedPerson.UserType = getType();

                personManager.UpdatePerson(adjustedPerson);

                Message newMessage = new Message($"User: {adjustedPerson.Username} got updated successfully.");
                newMessage.ShowDialog();
                btSearch_Click(sender, e);
                return;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Email"))
                {
                    Message newMessage = new Message("The Email already exist.");
                    newMessage.ShowDialog();
                }
                if (ex.Message.Contains("PhoneNumber"))
                {
                    Message newMessage = new Message("The phone number already exist.");
                    newMessage.ShowDialog();
                }
                if (ex.Message.Contains("Username"))
                {
                    Message newMessage = new Message("The username already exist.");
                    newMessage.ShowDialog();
                }
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

        private int GetIDInListBox(ListBox listBox)
        {
            string selectedIndex = (string)listBox.SelectedItem;
            if (selectedIndex == null)
            {
                return -1;
            }
            int Lenght = selectedIndex.Length;
            if (listBox.SelectedItem == null)
            {
                return -1;
            }

            while (0 < Lenght)
            {
                string IDInString = selectedIndex.Substring(0, Lenght--);
                if (int.TryParse(IDInString, out int ID))
                {
                    ID = Convert.ToInt32(IDInString);
                    return ID;
                }
            }
            return -1;
        }

        private void UserInfoLocking(int selectedIndex)
        {
            if (selectedIndex == -1)
            {
                gbUserInfo.Enabled = false;
            }
            else
            {
                gbUserInfo.Enabled = true;
            }
        }

        private void printPerons(ListBox listBox, List<Person> persons, string type)
        {
            listBox.Items.Clear();
            foreach (Person person in persons)
            {
                listBox.Items.Add(person.ToString(type));
            }
        }

        private UserType getSelectedTypeForSearch()
        {
            if (rdClientSearch.Checked)
            {
                return UserType.CLIENT;
            }
            else if (rbEmployeeSearch.Checked)
            {
                return UserType.EMPLOYEE;
            }
            else
            {
                return UserType.ADMIN;
            }
        }

        private UserType getType()
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
