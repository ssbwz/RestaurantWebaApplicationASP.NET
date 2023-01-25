using MySql.Data.MySqlClient;
using Shawarma.DataAccess;
using Shawarma.Enum;
using Shawarma.Models;

namespace Shawarma.Logic
{
    public class OrderManager
    {

        private OrderStorage orderStorage;
        private OrdersStorage ordersStorage;

        public OrderManager()
        {
            orderStorage = new OrderStorage();
            ordersStorage = new OrdersStorage();
        }

        public bool AddingItemInOrder(Item item, int orderId)
        {
            if (ordersStorage.GetOrder(orderId) == null)
            {
                return false;
            }
            if (orderStorage.IsItemInOrder(orderId, item.Id))
            {
                return IncreaseQuantity(orderId, item.Id); ;
            }
            if (orderStorage.AddItem(orderId, convertItemTOOTDItem(item)))
            {
                return true;
            }
            return false;
        }

        public double GetTotal(int orderId)
        {
            double total = 0;

            foreach (int itemId in orderStorage.GetItemsIdList(orderId))
            {
                total += orderStorage.GetTotalPerItem(orderId, itemId);
            }

            return total;
        }

        public OrderStatus GetOrderStatus(int orderId)
        {
            return orderStorage.GetOrderStatus(orderId);
        }

        public void ChangeOrderStatus(int orderId, OrderStatus orderStatus)
        {
            orderStorage.ChangeStatus(orderId, orderStatus);
        }

        public void UpdateNote(int orderId, string note)
        {
            orderStorage.UpdateOrderNote(orderId, note);
        }

        public bool IncreaseQuantity(int orderId, int itemId)
        {
            if (orderStorage.AdjustQuantity(orderId, itemId, "+"))
            {
                return true;
            }
            return false;
        }

        public bool DecreaseQuantity(int orderId, int itemId)
        {
            if (orderStorage.GetItemQuantity(orderId, itemId) == 0)
            {
                return false;
            }
            if (orderStorage.AdjustQuantity(orderId, itemId, "-"))
            {
                return true;
            }
            return false;
        }

        public bool IsOrderSent(int orderId)
        {
            return orderStorage.IsOrderProcessed(orderId);
        }

        public bool RemoveItemInOrder(int orderId, int itemId)
        {
            if (orderStorage.GetItemQuantity(orderId, itemId) > 1)
            {
                DecreaseQuantity(orderId, itemId);
                return true;
            }
            orderStorage.RemoveItem(orderId, itemId);
            return true;
        }

        private ItemOTD convertItemTOOTDItem(Item item)
        {
            if (item == null)
            {
                return null;
            }
            if (item is NormalItem)
            {
                NormalItemOTD normalItemOTD = new NormalItemOTD()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Category = item.Category
                };
                return normalItemOTD;
            }
            if (item is HoildayItem)
            {
                HoildayItemOTD hoildayItemOTD = new HoildayItemOTD()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
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
                    Price = item.Price,
                    Category = item.Category
                };
                return summerItemOTD;
            }
            return null;
        }

    }
}
