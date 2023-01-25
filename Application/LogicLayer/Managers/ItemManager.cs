using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Shawarma.DataAccess;
using Shawarma.Models;
using Shawarma.Enum;

namespace Shawarma.Logic
{
    public class ItemManager
    {
        private ItemStorage itemStorage;

        public ItemManager()
        {
            itemStorage = new ItemStorage();
        }

        public int LastItemId
        {
            get { return itemStorage.GetTheLastID(); }
        }

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();

            foreach (ItemOTD itemOTD in itemStorage.GetItems()) 
            {
                items.Add(checkingItem(itemOTD));
            }

            return items;
        }

        public Item GetItem(int id)
        {
            Item item = checkingItem(itemStorage.GetItem(id));

            if (item != null)
            {
                return item;
            }

            return null;

        }

        //ToDo: Change the lists to data grids
        public List<Item> SearchItem(string name, string description, string price, string category, string type)
        {
            try
            {
                List<Item> filteredItems = new List<Item>();

                foreach (Item item in GetItems())
                {

                    if ("Normal" == type && item is NormalItem)
                    {
                        NormalItem normalItem = (NormalItem)item;
                        if (!string.IsNullOrEmpty(name))
                        {
                            filterByValue(normalItem, name, "name");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            filterByValue(normalItem, description, "description");
                        }
                        if (!string.IsNullOrEmpty(price))
                        {
                            filterByValue(normalItem, price, "price");
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            filterByValue(normalItem, category, "category");
                        }
                        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price) && string.IsNullOrEmpty(category))
                        {
                            filteredItems.Add(normalItem);
                        }
                        if (name == " " && description == " " && price == " " && category == " ")
                        {
                            filteredItems.Add(normalItem);
                        }
                    }
                    if ("Summar" == type && item is SummerItem)
                    {
                        SummerItem summerItem = (SummerItem)item;
                        if (!string.IsNullOrEmpty(name))
                        {
                            filterByValue(summerItem, name, "name");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            filterByValue(summerItem, description, "description");
                        }
                        if (!string.IsNullOrEmpty(price))
                        {
                            filterByValue(summerItem, price, "price");
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            filterByValue(summerItem, category, "category");
                        }
                        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price) && string.IsNullOrEmpty(category))
                        {
                            filteredItems.Add(summerItem);
                        }
                        if (name == " " && description == " " && price == " " && category == " ")
                        {
                            filteredItems.Add(summerItem);
                        }
                    }
                    if ("Holiday" == type && item is HoildayItem)
                    {
                        HoildayItem hoildayItem = (HoildayItem)item;
                        if (!string.IsNullOrEmpty(name))
                        {
                            filterByValue(hoildayItem, name, "name");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            filterByValue(hoildayItem, description, "description");
                        }
                        if (!string.IsNullOrEmpty(price))
                        {
                            filterByValue(hoildayItem, price, "price");
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            filterByValue(hoildayItem, category, "category");
                        }
                        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price) && string.IsNullOrEmpty(category))
                        {
                            filteredItems.Add(hoildayItem);
                        }
                        if (name == " " && description == " " && price == " " && category == " ")
                        {
                            filteredItems.Add(hoildayItem);
                        }
                    }
                    if (" " == type)
                    {
                        if (!string.IsNullOrEmpty(name))
                        {
                            filterByValue(item, name, "name");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            filterByValue(item, description, "description");
                        }
                        if (!string.IsNullOrEmpty(price))
                        {
                            filterByValue(item, price, "price");
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            filterByValue(item, category, "category");
                        }
                        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price) && string.IsNullOrEmpty(category))
                        {
                            filteredItems.Add(item);
                        }
                        if (name == " " && description == " " && price == " " && category == " ")
                        {
                            filteredItems.Add(item);
                        }
                    }


                }
                return filteredItems;

                void filterByValue(Item item, string value, string type)
                {
                    if (type == "name" && value.Length <= item.Name.Length)
                    {
                        if (value == item.Name.Substring(0, value.Length))
                        {
                            filteredItems.Add(item);
                        }
                    }
                    if (type == "description" && value.Length <= item.Description.Length)
                    {
                        if (value == item.Description.Substring(0, value.Length))
                        {
                            filteredItems.Add(item);
                        }
                    }
                    if (type == "price" && value.Length <= Convert.ToString(item.Price).Length)
                    {
                        string priceInString = Convert.ToString(item.Price);
                        if (value == priceInString.Substring(0, value.Length))
                        {
                            filteredItems.Add(item);
                        }
                    }
                    if (type == "category" && Convert.ToString(item.Category) == value)
                    {
                        filteredItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /*
        public static List<Item> SearchItemStatic(string name, string description, string price, string category, string type)
        {
            try
            {
                List<Item> filteredItems = new List<Item>();

                foreach (Item item in Login.ItemManager.GetItems())
                {

                    if ("Normal" == type && item is NormalItem)
                    {
                        NormalItem normalItem = (NormalItem)item;
                        if (!string.IsNullOrEmpty(name))
                        {
                            filterByValue(normalItem, name, "name");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            filterByValue(normalItem, description, "description");
                        }
                        if (!string.IsNullOrEmpty(price))
                        {
                            filterByValue(normalItem, price, "price");
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            filterByValue(normalItem, category, "category");
                        }
                        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price) && string.IsNullOrEmpty(category))
                        {
                            filteredItems.Add(normalItem);
                        }
                        if (name == " " && description == " " && price == " " && category == " ")
                        {
                            filteredItems.Add(normalItem);
                        }
                    }
                    if ("Summar" == type && item is SummerItem)
                    {
                        SummerItem summerItem = (SummerItem)item;
                        if (!string.IsNullOrEmpty(name))
                        {
                            filterByValue(summerItem, name, "name");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            filterByValue(summerItem, description, "description");
                        }
                        if (!string.IsNullOrEmpty(price))
                        {
                            filterByValue(summerItem, price, "price");
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            filterByValue(summerItem, category, "category");
                        }
                        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price) && string.IsNullOrEmpty(category))
                        {
                            filteredItems.Add(summerItem);
                        }
                        if (name == " " && description == " " && price == " " && category == " ")
                        {
                            filteredItems.Add(summerItem);
                        }
                    }
                    if ("Holiday" == type && item is HoildayItem)
                    {
                        HoildayItem hoildayItem = (HoildayItem)item;
                        if (!string.IsNullOrEmpty(name))
                        {
                            filterByValue(hoildayItem, name, "name");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            filterByValue(hoildayItem, description, "description");
                        }
                        if (!string.IsNullOrEmpty(price))
                        {
                            filterByValue(hoildayItem, price, "price");
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            filterByValue(hoildayItem, category, "category");
                        }
                        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price) && string.IsNullOrEmpty(category))
                        {
                            filteredItems.Add(hoildayItem);
                        }
                        if (name == " " && description == " " && price == " " && category == " ")
                        {
                            filteredItems.Add(hoildayItem);
                        }
                    }
                    if (" " == type)
                    {
                        if (!string.IsNullOrEmpty(name))
                        {
                            filterByValue(item, name, "name");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            filterByValue(item, description, "description");
                        }
                        if (!string.IsNullOrEmpty(price))
                        {
                            filterByValue(item, price, "price");
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            filterByValue(item, category, "category");
                        }
                        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price) && string.IsNullOrEmpty(category))
                        {
                            filteredItems.Add(item);
                        }
                        if (name == " " && description == " " && price == " " && category == " ")
                        {
                            filteredItems.Add(item);
                        }
                    }
                }
                return filteredItems;

                void filterByValue(Item item, string value, string type)
                {
                    if (type == "name" && value.Length <= item.Name.Length)
                    {
                        if (value == item.Name.Substring(0, value.Length))
                        {
                            filteredItems.Add(item);
                        }
                    }
                    if (type == "description" && value.Length <= item.Description.Length)
                    {
                        if (value == item.Description.Substring(0, value.Length))
                        {
                            filteredItems.Add(item);
                        }
                    }
                    if (type == "price" && value.Length <= Convert.ToString(item.Price).Length)
                    {
                        string priceInString = Convert.ToString(item.Price);
                        if (value == priceInString.Substring(0, value.Length))
                        {
                            filteredItems.Add(item);
                        }
                    }
                    if (type == "category" && Convert.ToString(item.Category) == value)
                    {
                        filteredItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }*/

        public bool AddItem(Item item)
        {
            try
            {
                if (itemStorage.AddItem(convertItemToItemOTD(item)))
                {
                    return true;
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("connectionIssue"))
                {
                    Connection.Reconnect();
                    return false;
                }
            }
            return false;
        }

        public bool RemoveItem(int id)
        {
            Item i = GetItem(id);
            if (i != null)
            {
                itemStorage.DeleteItem(i.Id);
                return true;
            }
            return false;
        }
        public int GetTheLast() 
        {
            return itemStorage.GetTheLastID();
        }

        public bool AdjustItem(Item item)
        {
            if (itemStorage.UpdateItem(convertItemToItemOTD(item)))
            {
                return true;
            }
            return false;
        }

        public string GetDishType(int itemId) 
        {
            return itemStorage.GetDishType(itemId);
        } 

        private ItemOTD convertItemToItemOTD(Item item) 
        {
            if (item is HoildayItem)
            {
                HoildayItemOTD hoildayItemOTD = new HoildayItemOTD()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Discount = item.Discount,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Category = item.Category

                };
                return hoildayItemOTD;
            }
            if (item is SummerItem)
            {
                SummerItemOTD summerItemOTD = new SummerItemOTD()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Discount = item.Discount,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Category = item.Category
                };
                return summerItemOTD;
            }
            if(item is NormalItem)
            {
                NormalItemOTD normalItemOTD = new NormalItemOTD()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Discount = item.Discount,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Category = item.Category
                };
                return normalItemOTD;
            }
            return null;
        }

        private Item checkingItem(ItemOTD itemOTD) 
        {
            if (itemOTD is HoildayItemOTD) 
            {
                return new HoildayItem(itemOTD);
            }
            if (itemOTD is SummerItemOTD) 
            {
                return new SummerItem(itemOTD);
            }
            if (itemOTD is NormalItemOTD)
            {
                return new NormalItem(itemOTD);
            }
            return null;
        }

    }
}
