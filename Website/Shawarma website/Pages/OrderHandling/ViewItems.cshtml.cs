using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Shawarma.DataAccess;
using Shawarma.Logic;
using Shawarma.Models;

namespace Shawarma_website.Pages.ItemHandling
{
    [Authorize]
    public class ViewItemsModel : PageModel
    {
        private ItemManager itemManager;
        private OrderManager orderManager;
        private OrdersManager ordersManager;

        private int orderId { get; set; }

        private int userId { get { return Convert.ToInt32(User.FindFirst("id").Value); } }

        public string Message;

        public List<Item> items
        {
            get
            {
                try
                {
                    return itemManager.GetItems();
                    Message = String.Empty;
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
        }

        public IActionResult OnGet()
        {
            try
            {
                itemManager = new ItemManager();
                orderManager = new OrderManager();
                ordersManager = new OrdersManager(Connection.Connect);
            }
            catch (Exception)
            {
                Connection.CloseConnection();
                return Redirect("/Error");
            }
            return Page();
        }

        public void OnPostAdd(int id)
        {
            try
            {
                itemManager = new ItemManager();
                orderManager = new OrderManager();
                ordersManager = new OrdersManager(Connection.Connect);
                Item item = itemManager.GetItem(id);

                orderId = ordersManager.GetOrderIdByPersonIdIfOrderIsCreated(userId);

                if (orderManager.IsOrderSent(orderId) && orderId != 0)
                {
                    Message = "Your order already has been sent, you can't add items.";
                    return;
                }

                orderId = ordersManager.CreateOrder(userId);

                orderManager.AddingItemInOrder(item, orderId);
                Message = String.Empty;
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

    }
}
