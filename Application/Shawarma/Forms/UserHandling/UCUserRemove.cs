using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using Shawarma.DataAccess;
using Shawarma.Logic;
using Shawarma.Models;


namespace Shawarma
{
    public partial class UCUserRemove : UserControl
    {
        private List<Person> persons;
        private Person findedPerson;
        private IPersonRepository repository = new PersonStorage();
        private PersonManager personManager;

        public UCUserRemove()
        {
            try
            {
                InitializeComponent();
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

                persons = personManager.SearchPerson(firstName, lastName, email, phoneNumeber, username, rdClientSearch.Checked ? "CLIENT" : "EMPLOYEE");
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

        private void btFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;

                if (!string.IsNullOrEmpty(tbIdFind.Text))
                {
                    id = Convert.ToInt32(tbIdFind.Text);
                }

                string email = tbEmailFind.Text;
                string phoneNumeber = tbPhoneNumberFind.Text;
                string username = tbUsernameFind.Text;

                if (!string.IsNullOrEmpty(email))
                {
                    findedPerson = personManager.GetPersonByEmail(email);
                }

                if (!string.IsNullOrEmpty(phoneNumeber))
                {
                    findedPerson = personManager.GetPersonByPhoneNumber(phoneNumeber);
                }

                if (!string.IsNullOrEmpty(username))
                {
                    findedPerson = personManager.GetPersonByUsername(username);
                }

                if (id != 0)
                {
                    findedPerson = personManager.GetPersonId(id);
                }

                if (findedPerson != null)
                {
                    lbInfo.Visible = true;
                    lbInfo.Text = findedPerson.ToString("BeforeDelete");
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

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (findedPerson == null)
                {
                    Message newMessage = new Message("Could not find the user to delete");
                    newMessage.ShowDialog();
                }
                if (personManager.RemovePerson(findedPerson))
                {
                    lbInfo.Text = "";
                    lbInfo.Visible = false;
                    Message newMessage = new Message($"Username: {findedPerson.Username} got deleted sussccfully.");
                    newMessage.ShowDialog();
                    btSearch_Click(sender, e);
                    findedPerson = null;
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

        private void printPerons(ListBox listBox, List<Person> persons, string type)
        {
            listBox.Items.Clear();
            foreach (Person person in persons)
            {
                listBox.Items.Add(person.ToString(type));
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
                findedPerson = personManager.GetPersonId(GetIDInListBox(lbShowPersons));
                if (findedPerson == null)
                {
                    Message newMessage = new Message("Please select user.");
                    newMessage.ShowDialog();
                    return;
                }
                lbInfo.Visible = true;
                lbInfo.Text = findedPerson.ToString("BeforeDelete");
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
    }
}
