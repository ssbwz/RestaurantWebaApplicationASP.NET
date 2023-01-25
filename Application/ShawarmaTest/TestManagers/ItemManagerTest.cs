using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shawarma.Logic;
using Shawarma.DataAccess;
using System.Collections.Generic;
using System;
using Shawarma.Models;
using Shawarma.Enum;


namespace ShawarmaTest
{
    [TestClass]
    public class ItemStorageTest
    {
        private ItemManager itemManager = new ItemManager();

        [TestMethod]
        public void AddingNormalItemInRightFormat()
        {
            //Arrange
            NormalItem normalItem = new NormalItem("Beef Shawarma", "Lekker shawarma", 8.5, Category.SANDWICHES);
            //Act

            //Assert
            Assert.IsTrue(itemManager.AddItem(normalItem), "Normal item doesn't get added in the right format");
        }

        [TestMethod]
        public void AddingSummerItemInRightFormat()
        {
            //Arrange
            SummerItem summerItem = new SummerItem("Beef Shawarma", "Lekker shawarma", 8.5, Category.SANDWICHES);
            //Act
            //Assert
            Assert.IsTrue(itemManager.AddItem(summerItem), "Summer item doesn't get added in the right format");
        }

        [TestMethod]
        public void AddingHoidlayItemInRightFormat()
        {
            //Arrange
            HoildayItem hoildayItem = new HoildayItem("Beef Shawarma", "Lekker shawarma", 8.5, Category.SANDWICHES);
            //Act
            //Assert
            Assert.IsTrue(itemManager.AddItem(hoildayItem), "Hoilday item doesn't get added in the right format");
        }

        [TestMethod]
        public void AddingItemInWithOutConnectionFormat()
        {
            //Arrange
            HoildayItem hoildayItem = new HoildayItem("Beef Shawarma", "Lekker shawarma", 8.5, Category.SANDWICHES);
            //Act
            Connection.CloseConnection();
            //Assert
            Assert.IsFalse(itemManager.AddItem(hoildayItem), "Hoilday item shouldn't get added in the wrong format");
        }

        [TestMethod]
        public void GettingItemsWithConnection()
        {
            //Arrange
            bool isItem = false;
            //Act
            List<Item> items = new List<Item>();
            if (items.GetType() == itemManager.GetItems().GetType())
            {
                isItem = true;
            }
            //Assert
            Assert.IsTrue(isItem, "It doesn't get an items");
        }

        [TestMethod]
        public void GettingItemsWithoutConnection()
        {
            //Arrange
            //Act
            Connection.CloseConnection();
            //Assert
            Assert.ThrowsException<System.InvalidOperationException>(() => itemManager.GetItems(), "It doesnt throw InvalidOperationException ");
        }

        [TestMethod]
        public void GetingItemWithRightId()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsNotNull(itemManager.GetItem(itemManager.GetTheLast()), "It doesnt get the expected item");
        }

        [TestMethod]
        public void GetingItemWithWrongId()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(null, itemManager.GetItem(-1000), "It doesn't return null");
        }

        [TestMethod]
        public void RemveItemWithRightId()
        {
            //Arrange
            itemManager.AddItem(new NormalItem("Hot Pizza", "Lekker", 5.5, Category.DISHES));
            //Act
            int lastId = itemManager.GetTheLast();
            //Assert
            Assert.IsTrue(itemManager.RemoveItem(lastId), "It doesn't delete item.");
        }

        [TestMethod]
        public void RemveItemWithWrongId()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsFalse(itemManager.RemoveItem(-1000), "It doesn't delete item.");
        }

        [TestMethod]
        public void adjustExcitedItem()
        {
            //Arrange
            itemManager.AddItem(new NormalItem("Hot Pizza", "Lekker", 5.5, Category.DISHES));
            //Act
            Item adjutItem = itemManager.GetItem(itemManager.GetTheLast());
            adjutItem.Name = "Potato";
            //Assert
            Assert.IsTrue(itemManager.AdjustItem(adjutItem), "It doesn't adjust item.");
        }
    
    }
   
}

