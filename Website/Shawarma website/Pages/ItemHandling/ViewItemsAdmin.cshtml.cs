using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma.Models;
using Shawarma.Logic;
using Shawarma.DataAccess;

namespace Shawarma_website.Pages.ItemHandling
{
    public class ViewItemsAdminModel : PageModel
    {
        private ItemManager itemManager;
        private string Message { get; set; }

        public List<Item> Items
        {
            get
            {
                try
                {
                    try
                    {
                        itemManager = new ItemManager();
                    }
                    catch (Exception ex)
                    {
                        Redirect("/Error");
                    }
                    Message = string.Empty;
                    return itemManager.GetItems();
                }
                catch (Exception)
                {
                    Message = "Something went wrong";
                }
                return new List<Item>();
            }
        }

        public IActionResult OnGet()
        {
            try
            {
                itemManager = new ItemManager();
            }
            catch (Exception ex)
            {
               Connection.CloseConnection();
               return Redirect("/Error");
            }
            return Page();
        }

        public void OnPostRemove(int id) 
        {
            try
            {
                itemManager = new ItemManager();
            }
            catch (Exception ex)
            {
              Connection.CloseConnection();
              Redirect("/Error");
            }

            try
            {
                itemManager.RemoveItem(id);
                Message = string.Empty;
            }
            catch (Exception) 
            {
                Message = "Something went wrong";
            }
        }

        public IActionResult OnPostUpdate(int id) 
        {
            return Redirect($"/ItemHandling/UpdateItem?id={id}");
        }

    }
}
