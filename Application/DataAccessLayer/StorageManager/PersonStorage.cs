using MySql.Data.MySqlClient;
using Shawarma.Enum;
using Shawarma.Models;
using DataAccessLayer.Interfaces;


namespace Shawarma.DataAccess
{
    public class PersonStorage : IPersonRepository
    {
        public PersonStorage()
        {
        }

        public MySqlConnection connection { get { return Connection.Connect; } }

        public bool AddPerson(PersonOTD p)
        {
            string sql = "INSERT INTO `person` (`ID`, `FirstName`, `LastName`, `Username`, `Password`, `Email`, `PhoneNumber`, `Type`,`salt`) VALUES (NULL, @FIRSTNAME, @LASTNAME, @USERNAME, @PASSWORD, @EMAIL, @PHONENUMBER,@TYPE,@SALT);";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@FIRSTNAME", p.FirstName);
            cmd.Parameters.AddWithValue("@LASTNAME", p.LastName);
            cmd.Parameters.AddWithValue("@USERNAME", p.Username);
            cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
            cmd.Parameters.AddWithValue("@EMAIL", p.Email);
            cmd.Parameters.AddWithValue("@PHONENUMBER", p.PhoneNumber);
            cmd.Parameters.AddWithValue("@TYPE", p.UserType.ToString());
            cmd.Parameters.AddWithValue("@SALT",p.Salt);

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public List<PersonOTD> GetPersons()
        {
            MySqlDataReader reader = null;
            List<PersonOTD> persons = new List<PersonOTD>();

            string sql = $"SELECT ID,FirstName,LastName,Username,Password,Email,PhoneNumber,Type FROM person";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader[7].ToString() == "CLIENT")
                {
                    persons.Add(new PersonOTD(Convert.ToInt32(reader[0]), UserType.CLIENT, Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[6]), Convert.ToString(reader[5]), Convert.ToString(reader[3]), Convert.ToString(reader[4])));
                }
                if (reader[7].ToString() == "EMPLOYEE")
                {
                    persons.Add(new PersonOTD(Convert.ToInt32(reader[0]), UserType.EMPLOYEE, Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[6]), Convert.ToString(reader[5]), Convert.ToString(reader[3]), Convert.ToString(reader[4])));
                }
                if (reader[7].ToString() == "ADMIN")
                {
                    persons.Add(new PersonOTD(Convert.ToInt32(reader[0]), UserType.ADMIN, Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[6]), Convert.ToString(reader[5]), Convert.ToString(reader[3]), Convert.ToString(reader[4])));
                }
            }
            reader.Close();
            return persons;
        }

        public PersonOTD GetPersonById(int id)
        {
            MySqlDataReader reader = null;

            if (id == -1)
            {
                return null;
            }

            PersonOTD person = null;

            string sql = $"SELECT ID,FirstName,LastName,Username,Password,Email,PhoneNumber,Type,salt FROM person WHERE ID = @ID";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@ID", id);

            reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                person = new PersonOTD();
                person.Id = Convert.ToInt32(reader[0]);
                person.FirstName = Convert.ToString(reader[1]);
                person.LastName = Convert.ToString(reader[2]);
                person.Username = Convert.ToString(reader[3]);
                person.Password = Convert.ToString(reader[4]);
                person.Email = Convert.ToString(reader[5]);
                person.PhoneNumber = Convert.ToString(reader[6]);
                person.Salt = Convert.ToString(reader[8]);
                if (reader[7].ToString() == "CLIENT")
                {
                    person.UserType = UserType.CLIENT;
                }
                if (reader[7].ToString() == "EMPLOYEE")
                {
                    person.UserType = UserType.EMPLOYEE;
                }
                if (reader[7].ToString() == "ADMIN")
                {
                    person.UserType = UserType.ADMIN;
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

        public int GetIDByUsername(string username)
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

        public int GetIDByEmail(string email)
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

        public int GetIDByPhoneNumber(string phoneNumber)
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

        public bool UpdatePerson(PersonOTD p)
        {
    
            MySqlCommand cmd = new MySqlCommand("UPDATE `person` SET`FirstName`=@FIRSTNAME,`LastName`=@LASTNAME,`Username`=@USERNAME,`Password`=@PASSWORD,`Email`=@EMAIL,`PhoneNumber`=@PHONENUMBER,`Type`=@TYPE WHERE id =  @ID"
                , connection);

            cmd.Parameters.AddWithValue("@ID", p.Id);
            cmd.Parameters.AddWithValue("@FIRSTNAME", p.FirstName);
            cmd.Parameters.AddWithValue("@LASTNAME", p.LastName);
            cmd.Parameters.AddWithValue("@USERNAME", p.Username);
            cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
            cmd.Parameters.AddWithValue("@EMAIL", p.Email);
            cmd.Parameters.AddWithValue("@PHONENUMBER", p.PhoneNumber);
            cmd.Parameters.AddWithValue("TYPE", p.UserType.ToString());

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeletePerson(PersonOTD person)
        {
            int id = 0;
            if (person == null)
            {
                return false;
            }
            if (GetIDByEmail(person.Email) == GetIDByPhoneNumber(person.PhoneNumber) && GetIDByPhoneNumber(person.PhoneNumber) == GetIDByUsername(person.Username))
            {
                id = GetIDByUsername(person.Username);
            }

            if (id == -1 || id == 0)
            {
                return false;
            }
            //ToDo: Figure out a way how to Delete it from the table or keep it. 
            string sql = "Delete from `person` WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@ID", id);

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

    }
}
