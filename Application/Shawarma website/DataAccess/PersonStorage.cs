using Shawarma_website.Enum;
using Shawarma_website.Models;
using MySql.Data.MySqlClient;
using Shawarma_website.Pages;
namespace Shawarma_website.DataAccess
{
    public class PersonStorage
    {
        private MySqlConnection connection = IndexModel.connection.Connect;
        public PersonStorage()
        {
        }

        public string AddPerson(Person p)
        {
            try
            {
                string sql = "INSERT INTO `person` (`ID`, `FirstName`, `LastName`, `Username`, `Password`, `Email`, `PhoneNumber`, `Type`) VALUES (NULL, @FIRSTNAME, @LASTNAME, @USERNAME, @PASSWORD, @EMAIL, @PHONENUMBER,@TYPE);";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@FIRSTNAME", p.FirstName);
                cmd.Parameters.AddWithValue("@LASTNAME", p.LastName);
                cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                cmd.Parameters.AddWithValue("@EMAIL", p.Email);
                cmd.Parameters.AddWithValue("@PHONENUMBER", p.PhoneNumber);
                cmd.Parameters.AddWithValue("@TYPE", "CLIENT");

                int effectedRows = cmd.ExecuteNonQuery();

                if (effectedRows == 1)
                {
                    return "success";
                }
                return "NotAdded";
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Email"))
                {
                    return "emailDuplicate";
                }
                if (ex.Message.Contains("PhoneNumber"))
                {
                    return "phoneNumberDuplicate";
                }
                return "exception";

            }
            catch (InvalidOperationException) 
            {
                reconnect();
                return "connectionIssue";
            }
            catch (Exception ex)
            {
                //Add Methods to save the errors
                return "exception";
            }
        }
        
        public List<Person> GetPersons()
        {
            MySqlDataReader reader = null;
            try
            {
                List<Person> persons = new List<Person>();

                string sql = $"SELECT ID,FirstName,LastName,Username,Password,Email,PhoneNumber,Type FROM person";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[7].ToString() == "CLIENT")
                    {
                        persons.Add(new Person(Convert.ToInt32(reader[0]), UserType.CLIENT, Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[6]), Convert.ToString(reader[5]), Convert.ToString(reader[3]), Convert.ToString(reader[4])));
                    }
                    if (reader[7].ToString() == "EMPLOYEE")
                    {
                        persons.Add(new Person(Convert.ToInt32(reader[0]), UserType.EMPLOYEE, Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[6]), Convert.ToString(reader[5]), Convert.ToString(reader[3]), Convert.ToString(reader[4])));
                    }
                }
                reader.Close();
                return persons;

            }
            catch (Exception ex)
            {
                //Add Methods to save the errors
                reader.Close();
                return null;
            }
        }

        public Person GetPerson(int id)
        {
            MySqlDataReader reader = null;
            try
            {
                if (id == -1)
                {
                    return null;
                }

                Person person = null;

                string sql = $"SELECT ID,FirstName,LastName,Username,Password,Email,PhoneNumber,Type FROM person WHERE ID = @ID";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@ID", id);

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    person = new Person();
                    person.Id = Convert.ToInt32(reader[0]);
                    person.FirstName = Convert.ToString(reader[1]);
                    person.LastName = Convert.ToString(reader[2]);
                    person.Username = Convert.ToString(reader[3]);
                    person.Password = Convert.ToString(reader[4]);
                    person.Email = Convert.ToString(reader[5]);
                    person.PhoneNumber = Convert.ToString(reader[6]);
                    if (reader[7].ToString() == "CLIENT")
                    {
                        person.UserType = UserType.CLIENT;
                    }
                    if (reader[7].ToString() == "EMPLOYEE")
                    {
                        person.UserType = UserType.EMPLOYEE;
                    }
                    reader.Close();
                    return person;
                }
                if (person == null)
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                //Add Methods to save the errors
                reader.Close();
                return null;
            }
        }

        public int GetIDByUsername(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    return -1;
                }
                string sql = $"SELECT ID FROM person WHERE username like @username;";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@username", username);

                object id = cmd.ExecuteScalar();

                if (id is not null)
                {
                    return Convert.ToInt32(id);
                }
                return -1;
            }
            catch (Exception ex)
            {
                //Add Methods to save the errors
                return -1;
            }
        }
        public int GetIDByEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return -1;
                }
                string sql = $"SELECT ID FROM person WHERE email like @email;";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@email", email);

                object id = cmd.ExecuteScalar();

                if (id is not null)
                {
                    return Convert.ToInt32(id);
                }
                return -1;
            }
            catch (Exception ex)
            {
                //Add Methods to save the errors
                return -1;
            }
        }
        public int GetIDByPhoneNumber(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    return -1;
                }
                string sql = $"SELECT ID FROM person WHERE PhoneNumber like @phoneNumber;";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                object id = cmd.ExecuteScalar();

                if (id is not null)
                {
                    return Convert.ToInt32(id);
                }
                return -1;
            }
            catch (Exception ex)
            {
                //Add Methods to save the errors
                return -1;
            }
        }
        public string UpdatePerson(Person p)
        {
            try
            {
                string sql = " ";
                if (p.UserType == UserType.EMPLOYEE)
                {
                    sql = "UPDATE `person` SET`FirstName`=@FIRSTNAME,`LastName`=@LASTNAME,`Username`=@USERNAME,`Password`=@PASSWORD,`Email`=@EMAIL,`PhoneNumber`=@PHONENUMBER,`Type`='EMPLOYEE' WHERE id = @ID";
                }
                else
                {
                    sql = "UPDATE `person` SET`FirstName`=@FIRSTNAME,`LastName`=@LASTNAME,`Username`=@USERNAME,`Password`=@PASSWORD,`Email`=@EMAIL,`PhoneNumber`=@PHONENUMBER,`Type`='CLIENT' WHERE id =  @ID";
                }

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@ID", p.Id);
                cmd.Parameters.AddWithValue("@FIRSTNAME", p.FirstName);
                cmd.Parameters.AddWithValue("@LASTNAME", p.LastName);
                cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                cmd.Parameters.AddWithValue("@EMAIL", p.Email);
                cmd.Parameters.AddWithValue("@PHONENUMBER", p.PhoneNumber);
                cmd.Parameters.AddWithValue("@TYPE", p.UserType);

                int effectedRows = cmd.ExecuteNonQuery();

                if (effectedRows == 1)
                {
                    return "success";
                }
                return "notUpdated";
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Email"))
                {
                    return "emailDuplicate";
                }
                if (ex.Message.Contains("PhoneNumber"))
                {
                    return "phoneNumberDuplicate";
                }
                return "exception";

            }
            catch (InvalidOperationException)
            {
                reconnect();
                return "connectionIssue";
            }
            catch (Exception ex)
            {
                //Add Methods to save the Errors
                return "exception";
            }
        }
        public bool DeletePerson(Person person)
        {
            try
            {
                int id = 0;
                if (GetIDByEmail(person.Email) == GetIDByPhoneNumber(person.PhoneNumber) && GetIDByPhoneNumber(person.PhoneNumber) == GetIDByUsername(person.Username))
                {
                    id = GetIDByUsername(person.Username);
                }

                if (id == -1 || id == 0)
                {
                    return false;
                }
                string sql = "DELETE FROM `person` WHERE id = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@ID", id);

                int effectedRows = cmd.ExecuteNonQuery();

                if (effectedRows == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //Add Methods to save the Errors
                return false;
            }
        }
        private void reconnect() 
        {
            IndexModel.connection.Reconnect();
            connection = IndexModel.connection.Connect;
        }
    }
}

