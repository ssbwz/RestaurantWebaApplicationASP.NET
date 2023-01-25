using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma_website.Logic;
using Shawarma_website.Models;

namespace Shawarma_website.Pages.Registration
{
    public class RegisterUserModel : PageModel
    {
        [BindProperty]
        public Person PersonalInfo { get; set; }

        public string error { get; set; }


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
            if (ModelState.IsValid)
            {
                string result = IndexModel.PersonBase.AddPerson(PersonalInfo);
                if (result == "success") 
                {
                    error = "";
                    return Redirect("../Index");
                }
                if (result == "emailDuplicate") 
                {
                    error = "The email already exist.";
                    return Page();
                }
                if (result == "usernameDuplicate")
                {
                    error = "The username already exist.";
                    return Page();
                }
                if (result == "phoneNumberDuplicate")
                {
                    error = "The phone number already exist.";
                    return Page();
                }
                if (result == "connectionIssue")
                {
                    error = "Connection Error try again.";
                    return Page();
                }
                if (result == "NotAdded")
                {
                    error = "Something went wrong new user doesnt get added.";
                    return Page();
                }
                if (result == "exception")
                {
                    error = "Something went wrong.";
                    return Page();
                }
            }
            return Page();
        }
    }
}
