using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma_website.Class;
using Shawarma_website.Enum;

namespace Shawarma_website.Pages.ItemHandling
{
    public class ItemOverviewModel : PageModel
    {
        public List<Item> Items { get; set; }
        public void OnGet(int? id)
        {
            Items.Add(new Item("COC", "Not nice", 1.5, Category.DRINKS));
            Items.Add(new Item("Not COC", "Not nice", 3.5, Category.BURGERS));
        }
    }
}
