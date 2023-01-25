using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma.DataAccess;
using Shawarma.Enum;
using Shawarma.Logic;
using Shawarma.Models;
using MySql.Data.MySqlClient;
using DataAccessLayer.Interfaces;

namespace Shawarma_website.Pages
{
    [Authorize]
    public class ViewOrderModel : PageModel
    {
        private OrderManager orderManager;
        private OrdersManager ordersManager;
        private PersonManager personManager;
        private IPersonRepository repostory = new PersonStorage();

        public List<Order> CleintOrders
        {
            get
            {
                try
                {
                    return ordersManager.GetDoneOrders(userId);
                    Message = string.Empty;
                }
                catch (AggregateException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return new List<Order>();
                }
                catch (InvalidOperationException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return new List<Order>();
                }
                catch (MySqlException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return new List<Order>();
                }
                catch (Exception)
                {
                    Message = "Something went wrong";
                    return new List<Order>();
                }
            }
        }

        [BindProperty]
        public Order CurrentOrder
        {
            get
            {
                try
                {
                    ordersManager = new OrdersManager(Connection.Connect);
                    Message = string.Empty;
                    int orderid = ordersManager.GetOrderIdByPersonIdIfOrderIsCreated(userId);
                    if (orderid != 0)
                    {
                        return ordersManager.GetOrder(orderid);
                    }

                    return null;
                }
                catch (AggregateException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return null;
                }
                catch (InvalidOperationException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return null;
                }
                catch (MySqlException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return null;
                }
                catch (Exception)
                {
                    Message = "Something went wrong";
                    return null;
                }
            }
        }

        public Order SelectedOrder
        {
            get;
            set;
        }

        public Person CurrentPerson
        {
            get
            {
                try
                {
                    Message = string.Empty;
                    return personManager.GetPersonId(userId);
                }
                catch (AggregateException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return null;
                }
                catch (InvalidOperationException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return null;
                }
                catch (MySqlException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return null;
                }
                catch (Exception)
                {
                    Message = "Something went wrong";
                    return null;
                }
            }
        }

        private int userId { get { return Convert.ToInt32(User.FindFirst("id").Value); } }

        public string Status
        {
            get
            {
                try
                {
                    Message = string.Empty;
                    return GetStatusInString(CurrentOrder.OrderStatus);
                }
                catch (AggregateException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return string.Empty;
                }
                catch (InvalidOperationException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return string.Empty;
                }
                catch (MySqlException)
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                    return string.Empty;
                }
                catch (Exception)
                {
                    Message = "Something went wrong";
                    return string.Empty;
                }
            }
        }

        public string Name
        {
            get
            {
                return CurrentPerson.FirstName + " " + CurrentPerson.LastName;
            }
        }

        public string Message { get; set; }


        public IActionResult OnGet()
        {
            try
            {
                orderManager = new OrderManager();
                ordersManager = new OrdersManager(Connection.Connect);
                personManager = new PersonManager(repostory);

                SelectedOrder = CurrentOrder;
                Message = string.Empty;
            }
            catch (Exception)
            {
                Connection.CloseConnection();
                return Redirect("/Error");
            }
            return Page();
        }

        public void OnPostDelete(int itemId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("id").Value);
                ordersManager = new OrdersManager(Connection.Connect);
                int orderId = ordersManager.GetOrderIdByPersonIdIfOrderIsCreated(userId);

                orderManager.RemoveItemInOrder(orderId, itemId);
                OnGet();
                Message = string.Empty;
            }
            catch (AggregateException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (InvalidOperationException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (MySqlException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (Exception)
            {
                Message = "Something went wrong";
            }
        }

        public void OnPostSendOrder(string note)
        {
            try
            {
                orderManager = new OrderManager();
                orderManager.ChangeOrderStatus(CurrentOrder.Id, OrderStatus.SENT);
                orderManager.UpdateNote(CurrentOrder.Id, note);
                OnGet();
                Message = string.Empty;
            }
            catch (AggregateException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (InvalidOperationException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (MySqlException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (Exception)
            {
                Message = "Something went wrong";
            }
        }

        public double GetTotal(int orderId)
        {
            try
            {
                Message = string.Empty;
                orderManager = new OrderManager();
                return orderManager.GetTotal(orderId);
            }
            catch (AggregateException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return 0;
            }
            catch (InvalidOperationException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return 0;
            }
            catch (MySqlException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return 0;
            }
            catch (Exception)
            {
                Message = "Something went wrong";
                return 0;
            }
        }

        public void OnPostSelected(int orderId)
        {
            try
            {
                ordersManager = new OrdersManager(Connection.Connect);

                SelectedOrder = ordersManager.GetOrder(orderId);
            }
            catch (AggregateException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (InvalidOperationException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (MySqlException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
            }
            catch (Exception) 
            {
                Message = "Something went wrong";
            }
        }

        public List<Item> GetItemsPerOrder(int orderId)
        {
            try
            {
                ordersManager = new OrdersManager(Connection.Connect);

                return ordersManager.GetItemsPerOrder(orderId);
                Message = string.Empty;
            }
            catch (AggregateException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return new List<Item>();
            }
            catch (InvalidOperationException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return new List<Item>();
            }
            catch (MySqlException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return new List<Item>();
            }
            catch (Exception)
            {

                Message = "Something went wrong";
                return new List<Item>();
            }
        }

        private string GetStatusInString(OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.SENT: return "Sent";
                case OrderStatus.ACCEPTED: return "Accepted";
                case OrderStatus.PREPARING: return "Preparing";
                case OrderStatus.DONE: return "Done";
                default: return "Created";
            }

        }
    }
}
