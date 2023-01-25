using Shawarma_website.Models;
using Shawarma_website.Enum;
using Shawarma_website.DataAccess;

namespace Shawarma_website.Logic
{
    public class PersonBase
    {
        PersonStorage PersonStorage = new PersonStorage();
        public PersonBase()
        {

        }
        public List<Person> Persons
        {
            get;
            set;
        }
        public string AddPerson(Person p)
        {
            Person findedPerson = PersonStorage.GetPerson(PersonStorage.GetIDByUsername(p.Username));
            if (findedPerson != null)
            {
                return "usernameDuplicate";
            }
            if (PersonStorage.AddPerson(p) == "success")
            {
                return "success";
            }
            if (PersonStorage.AddPerson(p) == "emailDuplicate")
            {
                return "emailDuplicate";
            }
            if (PersonStorage.AddPerson(p) == "phoneNumberDuplicate")
            {
                return "phoneNumberDuplicate";
            }
            if (PersonStorage.AddPerson(p) == "usernameDuplicate")
            {
                return "usernameDuplicate";
            }
            if (PersonStorage.AddPerson(p) == "connectionIssue")
            {
                return "connectionIssue";
            }
            if (PersonStorage.AddPerson(p) == "NotAdded")
            {
                return "NotAdded";
            }
            return "exception";
        }
        public List<Person> GetPersons()
        {
            return PersonStorage.GetPersons();
        }
        public List<Person> SearchPerson(string firstName, string lastName, string email, string phoneNumber, string username, string userType)
        {
            List<Person> filteredPersons = new List<Person>();
            //Persons = PersonStorage.GetPersons();
            if (Persons == null)
            {
                return null;
            }

            foreach (Person person in Persons)
            {
                if (Convert.ToString(person.UserType) == userType)
                {
                    if (!string.IsNullOrEmpty(firstName))
                    {
                        filterByValue(person, firstName, "firstName");
                    }
                    if (!string.IsNullOrEmpty(lastName))
                    {
                        filterByValue(person, lastName, "lastName");
                    }
                    if (!string.IsNullOrEmpty(email))
                    {
                        filterByValue(person, email, "email");
                    }
                    if (!string.IsNullOrEmpty(phoneNumber))
                    {
                        filterByValue(person, phoneNumber, "phoneNumber");
                    }
                    if (!string.IsNullOrEmpty(username))
                    {
                        filterByValue(person, username, "username");
                    }
                    if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(username))
                    {
                        filteredPersons.Add(person);
                    }
                }

            }
            return filteredPersons;

            void filterByValue(Person person, string value, string type)
            {
                if (type == "firstName" && value.Length <= person.FirstName.Length)
                {
                    if (value == person.FirstName.Substring(0, value.Length))
                    {
                        filteredPersons.Add(person);
                    }
                }
                if (type == "lastName" && value.Length <= person.LastName.Length)
                {
                    if (value == person.LastName.Substring(0, value.Length))
                    {
                        filteredPersons.Add(person);
                    }
                }
                if (type == "email" && value.Length <= person.Email.Length)
                {
                    if (value == person.Email.Substring(0, value.Length))
                    {
                        filteredPersons.Add(person);
                    }
                }
                if (type == "phoneNumber" && value.Length <= person.PhoneNumber.Length)
                {
                    if (value == person.PhoneNumber.Substring(0, value.Length))
                    {
                        filteredPersons.Add(person);
                    }
                }
                if (type == "username" && value.Length <= person.Username.Length)
                {
                    if (value == person.Username.Substring(0, value.Length))
                    {
                        filteredPersons.Add(person);
                    }
                }
            }
        }
        public Person GetPersonId(int id)
        {
            Person person = PersonStorage.GetPerson(id);
            if (person == null)
            {
                return null;
            }
            return person;
        }
        //take out this method 
        public Person GetPersonByUsername(string username)
        {
            Person person = PersonStorage.GetPerson(PersonStorage.GetIDByUsername(username));
            return person == null ? null : person;
        }
        public Person GetPersonByEmail(string email)
        {
            Person person = PersonStorage.GetPerson(PersonStorage.GetIDByEmail(email));
            return person == null ? null : person;
        }
        public Person GetPersonByPhoneNumber(string phoneNumber)
        {
            Person person = PersonStorage.GetPerson(PersonStorage.GetIDByPhoneNumber(phoneNumber));
            return person == null ? null : person;
        }


        public bool RemovePerson(Person person)
        {
            if (PersonStorage.DeletePerson(person))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string UpdatePerson(Person person)
        {
            string result = PersonStorage.UpdatePerson(person);

            if (result == "success")
            {
                return "success";
            }
            if (result == "emailDuplicate")
            {
                return "emailDuplicate";
            }
            if (result == "phoneNumberDuplicate")
            {
                return "phoneNumberDuplicate";
            }
            if (result == "usernameDuplicate")
            {
                return "usernameDuplicate";
            }
            if (result == "connectionIssue")
            {
                return "connectionIssue";
            }
            if (result == "notUpdated")
            {
                return "notUpdated";
            }
            return "exception";
        }

    }
}
