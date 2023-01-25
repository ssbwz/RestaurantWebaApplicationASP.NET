using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma_website.DataAccess;
using Shawarma_website.Logic;
using Shawarma_website.Class;
using Shawarma_website.Enum;

namespace Shawarma_website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public static Connection connection;
        public static PersonBase PersonBase;
        public List<Item> Items { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            if (connection == null)
            {
                connection = new Connection();
                PersonBase = new PersonBase();
            }

        }

        public IActionResult OnGet(int? id)
        {
            if (connection.Connect.State != System.Data.ConnectionState.Open)
            {
                ErrorModel.Title = "Connection Error";
                ErrorModel.Description = "Please make sure that you are conneted with VPN";
                return RedirectToPage("Error");
            }
            PersonBase = new PersonBase();

            /*
                    Items.Add(new Item("COC", "Not nice", 1.5, Category.DRINKS));
                        Items.Add(new Item("Not COC", "Not nice", 3.5, Category.BURGERS));
            @foreach(var item in Model.Items)
            {
            <tr>
                <td>@item.Name</td>
                <td>Item.Price</td>
                <td><a href="/ItemHandling/ItemOverview=ID=@item.Id">view</a></td>
            </tr>    
            }
                    */
            return Page();
    
    }
        
       
    }
}