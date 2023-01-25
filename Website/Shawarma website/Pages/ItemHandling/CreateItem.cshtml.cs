using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma.Logic;
using Shawarma.Models;
using Shawarma.DataAccess;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace Shawarma_website.Pages.ItemHandling
{
    [Authorize(Roles = "ADMIN")]
    public class CreateItemModel : PageModel
    {
        private ItemManager itemManager;
        public string Message;

        public string Type { get; set; }

        [BindProperty]
        public NormalItem NormalItem { get; set; }

        [BindProperty]
        public HoildayItem HoildayItem { get; set; }

        [BindProperty]
        public SummerItem SummerItem { get; set; }


        public IActionResult OnGet()
        {
            try
            {
                itemManager = new ItemManager();
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();

                return Redirect("/Error"); ;
            }
            return Page();
        }

        public void OnPostAdd()
        {
            try
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

                List<string> vs = new List<string>();
                foreach (string modelstate in ViewData.ModelState.Keys)
                {
                    vs.Add(modelstate);
                }

                ModelState.Remove("Name");
                ModelState.Remove("Description");


                if (ModelState.IsValid)
                {
                    if (vs[2].Contains("Summer"))
                    {
                        SummerItem = new SummerItem(SummerItem.Name, SummerItem.Description, SummerItem.Price, SummerItem.Category);

                        itemManager.AddItem(SummerItem);
                        Message = "Successfully added";
                        return;
                    }
                    else if (vs[2].Contains("Hoilday"))
                    {
                        HoildayItem = new HoildayItem(HoildayItem.Name, HoildayItem.Description, HoildayItem.Price, HoildayItem.Category);

                        itemManager.AddItem(HoildayItem);
                        Message = "Successfully added";
                        return;
                    }
                    else if (vs[2].Contains("Normal"))
                    {
                        NormalItem = new NormalItem(NormalItem.Name, NormalItem.Description, NormalItem.Price, NormalItem.Category);

                        itemManager.AddItem(NormalItem);
                        Message = "Successfully added";
                        return;
                    }
                }
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

        public void OnPostSelectItemType(string type)
        {
            Type = type;
        }

    }
}
