
using DataAccessLayer.Interfaces;
using Shawarma.Models;
using System;
using System.Collections.Generic;

namespace ShawarmaTest.MockRepo
{
    internal class MockPersonRepository : IPersonRepository
    {
        private List<PersonOTD> persons = new List<PersonOTD>();

        public MockPersonRepository()
        {
        }


        public bool AddPerson(PersonOTD p)
        {
            if (!persons.Contains(p)) {
                persons.Add(p);
                return true;
            }
            return false;
        }

        public List<PersonOTD> GetPersons()
        {
            return persons;
        }

        public PersonOTD GetPersonById(int id)
        {
            foreach (PersonOTD person in persons) 
            {
                if (person.Id == id) 
                {
                    return person;
                }
            }
            return null;
        }

        public int GetIDByUsername(string username)
        {
            foreach (PersonOTD person in persons)
            {
                if (person.Username == username)
                {
                    return Convert.ToInt32(person.Id);
                }
            }
            return -1;
        }

        public int GetIDByEmail(string email)
        {
            foreach (PersonOTD person in persons)
            {
                if (person.Email == email)
                {
                    return Convert.ToInt32(person.Id);
                }
            }
            return -1;
        }

        public int GetIDByPhoneNumber(string phoneNumber)
        {
            foreach (PersonOTD person in persons)
            {
                if (person.PhoneNumber == phoneNumber)
                {
                    return Convert.ToInt32(person.Id);
                }
            }
            return -1;
        }

        public bool UpdatePerson(PersonOTD p)
        {
            foreach (PersonOTD person in persons) 
            {
                if (person.Id == p.Id) 
                {
                    person.FirstName = p.FirstName;
                    person.LastName = p.LastName;
                    person.Email = p.Email;
                    person.PhoneNumber = p.PhoneNumber;
                    person.Username = p.Username;
                    person.Password = p.Password;
                    person.UserType = p.UserType;
                    person.Salt = p.Salt;
                    return true;
                }
            }
            return false;

        }

        public bool DeletePerson(PersonOTD p)
        {
            foreach (PersonOTD person in persons) 
            {
                if (p.Id == person.Id) 
                {
                    persons.Remove(person);
                    return true;
                }
            }
            return false;
        }
    }
}
