using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shawarma.Logic;
using Shawarma.DataAccess;
using Shawarma.Models;
using Shawarma.Enum;
using System;
using ShawarmaTest.MockRepo;
using DataAccessLayer.Interfaces;

namespace ShawarmaTest
{
    [TestClass]
    public class PersonManagerTest
    {

        private IPersonRepository repository = new MockPersonRepository();
        private PersonManager personManager { get { return new PersonManager(repository); } }

        [TestMethod]
        public void AddingPersonWithRightForm()
        {
            //Arrange
            personManager.RemovePerson(personManager.GetPersonByUsername("S"));

            Person person = new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S");
            //Act
            //Assert
            Assert.AreEqual(true, personManager.AddPerson(person), "It doesnt add person with right form");

            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
        }
        
        [TestMethod]
        public void GetExistedPersonWtihUsername()
        {

                //Arrange
                personManager.RemovePerson(personManager.GetPersonByPhoneNumber("06134557"));
                personManager.AddPerson(new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S"));

                Person person = new Person((int)(personManager.GetPersonByUsername("S").Id), UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S");
                //Act
                Person finedPerson = personManager.GetPersonByUsername(person.Username);
                //Assert
                Assert.AreEqual(person.Id, finedPerson.Id, "It does not find person with existed person with username.");

                personManager.RemovePerson(personManager.GetPersonByUsername("S"));

        }

        [TestMethod]
        public void GetUnexistedPersonIdWtihUsername()
        {
            //Arrange
            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            //Act
            //Assert
            Assert.AreEqual(null, personManager.GetPersonByUsername("S"), "It dose find unexisted person.");
        }

        [TestMethod]
        public void GetExistedPersonWtihPhoneNumber()
        {
            //Arrange
            personManager.RemovePerson(personManager.GetPersonByPhoneNumber("06134557"));
            personManager.AddPerson(new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S"));
            //Act
            
            Person finedPerson = personManager.GetPersonByPhoneNumber("06134557");
            //Assert
            Assert.AreEqual(finedPerson.PhoneNumber, "06134557", "It dose not find existed person with phone number.");
            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
        }
        
        [TestMethod]
        public void GetExistedPersonWtihEmail()
        {
            //Arrange
            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            personManager.AddPerson(new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S"));
            //Act
            Person finededPerson = personManager.GetPersonByEmail("Saeedwz@gmail.com");
            //Assert
            Assert.AreEqual(finededPerson.Email,"Saeedwz@gmail.com", "It doent find an existed person with email.");
            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
        }

        [TestMethod]
        public void DeletingExistedPerson()
        {
            //Arrange
            personManager.RemovePerson(personManager.GetPersonByPhoneNumber("06134557"));
            personManager.AddPerson(new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S"));
            //Act
            //Assert
            Assert.AreEqual(true, personManager.RemovePerson(personManager.GetPersonByUsername("S")), "It dosent delete existed");
        }

        [TestMethod]
        public void AddingPersonWithDuplicatedPhoneNumber()
        {
            //Arrange
            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            personManager.AddPerson(new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedw@gmail.com", "Sa", "123S"));

            try
            {
                //Act
                personManager.AddPerson(new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S"));
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {  //Assert
                Assert.AreEqual(true,ex.Message.Contains("PhoneNumber"),"It added person with dupicated phone number");
                personManager.RemovePerson(personManager.GetPersonByUsername("S"));
                personManager.RemovePerson(personManager.GetPersonByUsername("Sa"));
            }
           

        }

        [TestMethod]
        public void AddingPersonWithDuplicatedEmail()
        {
            //Arrange
            personManager.RemovePerson(personManager.GetPersonByUsername("Sa"));

            try
            {
                //Act
                personManager.AddPerson(new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedw@gmail.com", "Sa", "123S"));
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) {
                //Assert
                Assert.AreEqual(true, ex.Message.Contains("Email"), "It added person with duplicated email.");
                personManager.RemovePerson(personManager.GetPersonByUsername("Sa"));
            }
        }

        [TestMethod]
        public void GetPersonWithWrongId()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(null, personManager.GetPersonId(-1), "It got wrong person");
        }

    }
        
}