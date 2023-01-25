using MySql.Data.MySqlClient;
using Shawarma.DataAccess;
using Shawarma.Models;

namespace Shawarma.Logic
{
    public class OrdersManager
    {
        private OrdersStorage ordersStorage;
        public OrdersManager(MySqlConnection conn)
        {
            ordersStorage = new OrdersStorage();
        }

        public int LastOrderId
        {
            get { return ordersStorage.GetLastOrderID(); }
        }

        public List<Order> Orders { get { return convertOTDOrderListToOrderList(ordersStorage.GetOrders()); } }

        public bool AddOrder(Order order, int makerId)
        {
            if (ordersStorage.AddOrder(convertToOrderOTD(order), makerId))
            {
                return true;
            }
            return false;
        }

        //ToDo: Get better name for this method
        public int CreateOrder(int personId)
        {
            if (!PersonHasOrderCreated(personId))
            {
                AddOrder(new Order(), personId);
            }
            return GetOrderIdByPersonIdIfOrderIsCreated(personId);
        }

        public Order GetOrder(int orderId)
        {
            OrderOTD orderOTD = ordersStorage.GetOrder(orderId);
            if (orderOTD == null || orderOTD.Id == 0) 
            {
                return null;
            }

            Order order = new Order(orderOTD);
            if (order == null)
            {
                return null;
            }
            return order;
        }

        public List<Item> GetItemsPerOrder(int orderId) 
        {
           return convertOTDItemListToItemsList(ordersStorage.GetItemsPerOrder(orderId));
        }  

        public bool RemoveOrder(int orderId)
        {
            if (ordersStorage.RemoveOrder(orderId))
            {
                return true;
            }

            return false;
        }

        public bool PersonHasOrderCreated(int personId)
        {
            if (ordersStorage.PersonHasOrderCreated(personId))
            {
                return true;
            }
            return false;
        }

        public int GetOrderIdByPersonIdIfOrderIsCreated(int personId)
        {
            return ordersStorage.GetOrderIdByPersonIdIfOrderIsCreated(personId);
        }

        public List<Order> GetDoneOrders(int personId) 
        { 
            List<Order> doneOrders = new List<Order>();
            foreach (int orderId in ordersStorage.GetOrdersIdByPersonIdIfOrderDone(personId)) 
            {
                doneOrders.Add(new Order(ordersStorage.GetOrder(orderId)));
            }
            return doneOrders;
        }

        public List<int> GetOrderIdByPersonIdIfOrderDone(int personId)
        {
            return ordersStorage.GetOrdersIdByPersonIdIfOrderDone(personId);
        }

        private OrderOTD convertToOrderOTD(Order order) 
        {
            if (order == null) 
            {
                return null;
            }
            OrderOTD orderOTD = new OrderOTD()
            {
                Id = order.Id,
                PersonID = order.PersonID,
                Note = order.Note

            };

            return orderOTD;
        }

        private List<Item> convertOTDItemListToItemsList(List<ItemOTD> itemOTDs) 
        {
            List<Item> convertedList = new List<Item>();
            foreach (ItemOTD itemOTD in itemOTDs) 
            {
                if (itemOTD is NormalItemOTD) 
                {
                    convertedList.Add(new NormalItem(itemOTD));
                }
                if (itemOTD is SummerItemOTD)
                {
                    convertedList.Add(new SummerItem(itemOTD));
                }
                if (itemOTD is HoildayItemOTD)
                {
                    convertedList.Add(new HoildayItem(itemOTD));
                }
                
            }
            return convertedList;
        }

        private List<Order> convertOTDOrderListToOrderList(List<OrderOTD> orderOTDs) 
        {
            List<Order> orders = new List<Order>();
            foreach (OrderOTD orderOTD in orderOTDs) 
            {
                orders.Add(new Order(orderOTD));
            }
            return orders;
        }
    }
    
}
