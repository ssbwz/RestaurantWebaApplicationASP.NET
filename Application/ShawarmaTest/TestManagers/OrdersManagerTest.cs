using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shawarma;
using Shawarma.DataAccess;
using Shawarma.Logic;
using MySql.Data.MySqlClient;
using Shawarma.Models;
using Shawarma.Enum;
using DataAccessLayer.Interfaces;

namespace ShawarmaTest
{
    [TestClass]
    public class OrdersManagerTest
    {
        private OrdersManager ordersManager = new OrdersManager(Connection.Connect);
        private IPersonRepository repository = new PersonStorage();
        private PersonManager personManager { get {return new PersonManager(repository); } } 

        [TestMethod]
        public void CreateOrderWithRightWay()
        {
            //Arrange
            Order order = new Order() { Note = "Bring it when we are leaving." };
            //Act
            //Assert
            Assert.IsTrue(ordersManager.AddOrder(order, 185), "It doesn't create order in the right way.");
        }

        [TestMethod]
        public void CreateOrderWithNonExcitedPerson()
        {
            //Arrange
            Order order = new Order() { Note = "Bring it when we are leaving." };
            //Act
            //Assert
            try
            {
                ordersManager.AddOrder(order, -1);
            }
            catch (MySqlException ex)
            {
                Assert.IsTrue(ex.Message.Contains("PersonId"), "It does create order without excited person");
            }
        }

        [TestMethod]
        public void GetExcitedOrder()
        {
            //Arrange
            Order order = new Order() { Note = "Bring it now." };
            //Act
            ordersManager.AddOrder(order, 185);
            //Assert
            Assert.AreEqual(order.Note, ordersManager.GetOrder(ordersManager.LastOrderId).Note, "It doesn't get same order");
        }

        [TestMethod]
        public void GetNotExcitedOrder()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsNull(ordersManager.GetOrder(-1).Note, "It does get order");
        }

        [TestMethod]
        public void RemoveExcitedOrder()
        {
            //Arrange
            Order order = new Order() { Note = "Bring it now." };
            //Act
            ordersManager.AddOrder(order, 185);
            //Assert
            Assert.IsTrue(ordersManager.RemoveOrder(ordersManager.LastOrderId), "It doesn't remove order");
        }

        [TestMethod]
        public void RemoveNonExcitedOrder()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsFalse(ordersManager.RemoveOrder(-1), "It does remove order");
        }

        [TestMethod]
        public void GetOrderIdByPersonIdInExsitedCreatedOrder()
        {
            //Arrange
            Order order = new Order() { Note = "Don't bring it now" };

            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            Person person = new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S");
            personManager.AddPerson(person);
            person = personManager.GetPersonByUsername(person.Username);
            //Act
            ordersManager.AddOrder(order, person.Id);
            //Assert
            Assert.AreEqual(ordersManager.LastOrderId,ordersManager.GetOrderIdByPersonIdIfOrderIsCreated(person.Id), "It doesnt get order id by person id");

            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            ordersManager.RemoveOrder(ordersManager.LastOrderId);
        }

        [TestMethod]
        public void CreateOrderWithExistedStatusOrderAsCREATED()
        {
            //Arrange
            Order order = new Order() { Note = "Don't bring it now" };

            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            Person person = new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S");
            personManager.AddPerson(person);
            person = personManager.GetPersonByUsername(person.Username);
            ordersManager.AddOrder(order, person.Id);
            //Act
            int res = ordersManager.CreateOrder(person.Id);
            //Assert
            Assert.AreEqual(ordersManager.LastOrderId,res, "It shouldn't make new order");

            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            ordersManager.RemoveOrder(ordersManager.LastOrderId);
        }

        [TestMethod]
        public void CreateOrderWithNonexistedStatusOrderAsCREATED()
        {
            //Arrange
            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            Person person = new Person(UserType.EMPLOYEE, "Saeed", "Ba Wazir", "06134557", "Saeedwz@gmail.com", "S", "123S");
            personManager.AddPerson(person);
            person = personManager.GetPersonByUsername(person.Username);
            //Act
            //Assert
            Assert.AreNotEqual(ordersManager.LastOrderId, ordersManager.CreateOrder(person.Id), "It should make new order");

            personManager.RemovePerson(personManager.GetPersonByUsername("S"));
            ordersManager.RemoveOrder(ordersManager.LastOrderId);
        }

    }
    
}
