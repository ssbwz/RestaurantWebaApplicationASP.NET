using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma.DataAccess;
using Shawarma.Logic;
using Shawarma.Models;
using System.ComponentModel.DataAnnotations;

namespace Shawarma_website.Pages.ItemHandling
{
    [Authorize(Roles = "ADMIN")]
    public class UpdateItemModel : PageModel
    {
        private ItemManager itemManager;
        public string Message;

        [BindProperty]
        [Required(ErrorMessage = "Please select item type.")]
        public string Type { get; set; }


        [BindProperty]
        public NormalItem NormalItem { get; set; }

        [BindProperty]
        public HoildayItem HoildayItem { get; set; }

        [BindProperty]
        public SummerItem SummerItem { get; set; }

        public IActionResult OnGet(int id)
        {
            try
            {
                try
                {
                    itemManager = new ItemManager();
                }
                catch (Exception)
                {
                    Connection.CloseConnection();
                    return Redirect("/Error"); ;
                }
                GetItem(id);

                Message = String.Empty;
            }
            catch (Exception)
            {
                Message = "Something went wrong";
            }
            return Page();
        }


        public IActionResult OnPost(int id) 
        {
            try
            {
                try
                {
                    itemManager = new ItemManager();
                }
                catch (Exception)
                {
                    Connection.CloseConnection();
                    return Redirect("/Error"); ;
                }

                Type = itemManager.GetDishType(id);
                if (Type == "NORMAL")
                {
                    NormalItem.Id = id;
                    if (itemManager.AdjustItem(NormalItem))
                    {
                        Message = "Item Updated successfully";
                    }
                    return Page();
                }
                if (Type == "HOILDAY")
                {
                    HoildayItem.Id = id;
                    if (itemManager.AdjustItem(HoildayItem))
                    {
                        Message = "Item Updated successfully";
                    }
                    return Page();
                }
                if (Type == "SUMMER")
                {
                    SummerItem.Id = id;
                    if (itemManager.AdjustItem(SummerItem))
                    {
                        Message = "Item Updated successfully";
                    }
                    return Page();
                }
                Message = String.Empty;
            }
            catch (Exception) 
            {
                Message = "Something went wrong";
                return Page();
            }
            return Page();
        }

        private void GetItem(int id)
        {
            Type = itemManager.GetDishType(id);
            if (Type == "NORMAL")
            {
                NormalItem = (NormalItem)itemManager.GetItem(id);
            }
            if (Type == "HOILDAY")
            {
                HoildayItem = (HoildayItem)itemManager.GetItem(id);
            }
            if (Type == "SUMMER")
            {
                SummerItem = (SummerItem)itemManager.GetItem(id);
            }
        }
    }
}
