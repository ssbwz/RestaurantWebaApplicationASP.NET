using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Shawarma.DataAccess;
using Shawarma.Enum;
using Shawarma.Logic;
using Shawarma.Models;

namespace ShawarmaTest
{
    [TestClass]
    public class OrderManagerTest
    {
        private OrderManager orderManager = new OrderManager();
        private OrdersManager ordersManager = new OrdersManager(Connection.Connect);
        private ItemManager itemManager = new ItemManager();

        [TestMethod]
        public void AddNewItemWithExistedOrder()
        {
            //Arrange
            itemManager.AddItem(new NormalItem("Tomato Soap", "With Fresh", 1.5, Category.STARTERS));
            ordersManager.AddOrder(new Order() { Note = "Give it to me after the drinks" }, 185);
            //Act
            Item item = itemManager.GetItem(itemManager.LastItemId);
            //Assert
            Assert.IsTrue(orderManager.AddingItemInOrder(item, ordersManager.LastOrderId), "It doesn't add item in existed order");

            ordersManager.RemoveOrder(ordersManager.LastOrderId);
            itemManager.RemoveItem(itemManager.LastItemId);
        }

        [TestMethod]
        public void AddNewItemWithNonexistedOrder()
        {
            //Arrange
            itemManager.AddItem(new NormalItem("Tomato Soap", "With Fresh", 1.5, Category.STARTERS));

            Item item = itemManager.GetItem(itemManager.LastItemId);

            try
            {
                //Act
                orderManager.AddingItemInOrder(item, -1);
            }
            catch (MySqlException ex)
            {
                //Assert
                Assert.IsTrue(ex.Message.Contains(
                     "Cannot add or update a child row: a foreign key constraint fails" +
                    " (`dbi488364`.`order_line`, CONSTRAINT `order_line_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `order` " +
                    "(`ID`) ON DELETE CASCADE)"),
                    "It does add item in Nonexisted order");

                itemManager.RemoveItem(itemManager.LastItemId);
            }
        }

        [TestMethod]
        public void AddingItemWithExistedOrder()
        {
            //Arrange
            itemManager.AddItem(new NormalItem("Tomato Soap", "With Fresh", 1.5, Category.STARTERS));
            ordersManager.AddOrder(new Order() { Note = "Give it to me after the drinks" }, 185);

            Item item = itemManager.GetItem(itemManager.LastItemId);
            //Act
            orderManager.AddingItemInOrder(item, ordersManager.LastOrderId);
            //Assert
            Assert.IsTrue(orderManager.AddingItemInOrder(item, ordersManager.LastOrderId), "It doesn't add item in existed order");

            ordersManager.RemoveOrder(ordersManager.LastOrderId);
            itemManager.RemoveItem(itemManager.LastItemId);
        }

        [TestMethod]
        public void IncreaseQuantity()
        {
            Order order = new Order() { Note = "Give it to me after the drinks" };
            itemManager.AddItem(new NormalItem("Tomato Soap", "With Fresh", 1.5, Category.STARTERS));
            //Act
            ordersManager.AddOrder(order, 185);
            orderManager.AddingItemInOrder(itemManager.GetItem(itemManager.LastItemId), ordersManager.LastOrderId);
            //Assert
            Assert.IsTrue(orderManager.IncreaseQuantity(ordersManager.LastOrderId, itemManager.LastItemId),"It doesn't increase item quantity");

            ordersManager.RemoveOrder(ordersManager.LastOrderId);
            itemManager.RemoveItem(itemManager.LastItemId);
        }

        [TestMethod]
        public void DecreaseQuantity()
        {
            Order order = new Order() { Note = "Give it to me after the drinks" };
            itemManager.AddItem(new NormalItem("Tomato Soap", "With Fresh", 1.5, Category.STARTERS));
            //Act
            ordersManager.AddOrder(order, 185);
            orderManager.AddingItemInOrder(itemManager.GetItem(itemManager.LastItemId), ordersManager.LastOrderId);
            orderManager.IncreaseQuantity(ordersManager.LastOrderId, itemManager.LastItemId);
            //Assert
            Assert.IsTrue(orderManager.DecreaseQuantity(ordersManager.LastOrderId, itemManager.LastItemId),"It doesn't decrease quantity");

            itemManager.RemoveItem(itemManager.LastItemId);
            ordersManager.RemoveOrder(ordersManager.LastOrderId);
        }

        //ToDO: Check quantity not decrease it
        [TestMethod]
        public void RemoveItemInExistedOrder()
        {
            //Arrange
            Order order = new Order() { Note = "Give it to me after the drinks" };
            itemManager.AddItem(new NormalItem("Tomato Soap", "With Fresh", 1.5, Category.STARTERS));
            //Act
            ordersManager.AddOrder(order, 185);
            orderManager.AddingItemInOrder(itemManager.GetItem(itemManager.LastItemId), ordersManager.LastOrderId);
            //Assert
            Assert.IsTrue(orderManager.RemoveItemInOrder(ordersManager.LastOrderId, itemManager.LastItemId),"It doesn't remove item in existed order");

            itemManager.RemoveItem(itemManager.LastItemId);
            ordersManager.RemoveOrder(ordersManager.LastOrderId);
        }

        [TestMethod]
        public void RemoveNonexistedItemInExistedOrder()
        {
            //Arrange
            Order order = new Order() { Note = "Give it to me after the drinks" };
            //Act
            ordersManager.AddOrder(order, 185);
            //Assert
            Assert.IsFalse(orderManager.RemoveItemInOrder(ordersManager.LastOrderId, itemManager.LastItemId),"It add nonexisted item in Order");

            ordersManager.RemoveOrder(ordersManager.LastOrderId);
        }

        [TestMethod]
        public void GetOrderStatusWhenOrderJustGetCreated()
        {
            //Arrange
            Order order = new Order() { Note = "Give it to me after the drinks" };
            //Act
            ordersManager.AddOrder(order, 185);
            //Assert
            Assert.AreEqual(OrderStatus.CREATED,orderManager.GetOrderStatus(ordersManager.LastOrderId), "It doesn't return status as Created");

            ordersManager.RemoveOrder(ordersManager.LastOrderId);
        }
    
    }
    
    
}
