using MySql.Data.MySqlClient;
using DataAccessLayer.Interfaces;
using Shawarma.Models;

namespace Shawarma.Logic
{
    public class PersonManager
    {
        private IPersonRepository repository;

        public PersonManager(IPersonRepository repository)
        {
           this.repository = repository;
        }

        public List<Person> Persons
        {
            get;
            set;
        }

        public bool AddPerson(Person person)
        {
            PersonOTD personOTD = repository.GetPersonById(repository.GetIDByUsername(person.Username));
            if (personOTD != null)
            {
                return false;
            }

            if (repository.AddPerson(convertPersonToPersonOTD(person)))
            {
                return true;
            }

            return false;
        }

        public List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();
            foreach (PersonOTD personOTD in repository.GetPersons())
            {
                persons.Add(new Person(personOTD));
            }
            return persons;
        }

        public List<Person> SearchPerson(string firstName, string lastName, string email, string phoneNumber, string username, string userType)
        {
            List<Person> filteredPersons = new List<Person>();
            Persons = GetPersons();
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
            PersonOTD personOTD = repository.GetPersonById(id);
            if (personOTD == null)
            {
                return null;
            }
            Person person = new Person(repository.GetPersonById(id));

            if (person == null)
            {
                return null;
            }
            return person;
        }

        public Person GetPersonByUsername(string username)
        {
            PersonOTD personOTD = repository.GetPersonById(repository.GetIDByUsername(username));
            if (personOTD == null)
            {
                return null;
            }
            Person person = new Person(personOTD);
            return person == null ? null : person;
        }

        public Person GetPersonByEmail(string email)
        {
            PersonOTD personOTD = repository.GetPersonById(repository.GetIDByEmail(email));
            if (personOTD == null)
            {
                return null;
            }
            Person person = new Person(personOTD);
            return person == null ? null : person;
        }

        public Person GetPersonByPhoneNumber(string phoneNumber)
        {
            PersonOTD personOTD = repository.GetPersonById(repository.GetIDByPhoneNumber(phoneNumber));
            if (personOTD == null) 
            {
                return null;
            }

            Person person = new Person(personOTD);
            return person;
        }

        public bool RemovePerson(Person person)
        {
            if (repository.DeletePerson(convertPersonToPersonOTD(person)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePerson(Person person)
        { 
          return repository.UpdatePerson(convertPersonToPersonOTD(person));
        }

        private PersonOTD convertPersonToPersonOTD(Person person)
        {
            if (person == null)
            {
                return null;
            }
            PersonOTD personOTD = new PersonOTD()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                Username = person.Username,
                Password = person.Password,
                UserType = person.UserType,
                Salt = person.Salt
            };
            return personOTD;
        }
    }

}
