using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma_website.Models;

namespace Shawarma_website.Pages.Registration
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public Person PersonalInfo { get; set; }

        public string Error { get; set; }
        public void OnGet(int id)
        {
           PersonalInfo = IndexModel.PersonBase.GetPersonId(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                PersonalInfo.Id = LoginModel.CurrentUser.Id;
                string result = IndexModel.PersonBase.UpdatePerson(PersonalInfo);
                if (result == "success")
                {
                    Error = "";
                    return Redirect("../Index");
                }
                if (result == "emailDuplicate")
                {
                    Error = "The email already exist.";
                    return Page();
                }
                if (result == "usernameDuplicate")
                {
                    Error = "The username already exist.";
                    return Page();
                }
                if (result == "phoneNumberDuplicate")
                {
                    Error = "The phone number already exist.";
                    return Page();
                }
                if (result == "connectionIssue")
                {
                    Error = "Connection Error try again.";
                    return Page();
                }
                if (result == "NotAdded")
                {
                    Error = "Something went wrong new user doesnt get added.";
                    return Page();
                }
                if (result == "exception")
                {
                    Error = "Something went wrong.";
                    return Page();
                }
             
            }
            return Page();
        }
    }
}
