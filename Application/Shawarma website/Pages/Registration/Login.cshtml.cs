using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma_website.Models;

namespace Shawarma_website.Pages.Registration
{
    public class LoginModel : PageModel
    {
        public static Person CurrentUser { get; set; }
        public string Error { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnGet()
        {

            if (IndexModel.connection.Connect.State != System.Data.ConnectionState.Open)
            {
                ErrorModel.Title = "Connection Error";
                ErrorModel.Description = "Please make sure that you are conneted";

                return Redirect("../Error");
            }

            return Page();

        }
        public IActionResult OnPost()
        {
            try
            {
                CurrentUser = IndexModel.PersonBase.GetPersonByUsername(Username);
                if (CurrentUser.Username == Username && CurrentUser.Password == Password)
                {
                    Error = " ";
                    return Redirect("../Index");
                }
                return Page();
            }
            catch (NullReferenceException)
            {
                Error = "The username or password you’ve entered is incorrect";
                return Page();
            }

        }
    }
}
