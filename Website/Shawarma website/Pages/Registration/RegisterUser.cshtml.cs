using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Shawarma.Logic;
using Shawarma.DataAccess;
using Shawarma.Models;
using Shawarma.Enum;
using System.Text.RegularExpressions;
using DataAccessLayer.Interfaces;

namespace Shawarma_website.Pages.Registration
{
    [AllowAnonymous]
    public class RegisterUserModel : PageModel
    {
        private PersonManager personManager;
        private IPersonRepository repository = new PersonStorage();
        private SecurityManager securityManager = new SecurityManager();

        [BindProperty]
        public Person PersonalInfo { get; set; }

        public string Message { get; set; }

        public IActionResult OnGet()
        {
            try
            {
                personManager = new PersonManager(repository);
            }
            catch (Exception)
            {
                Connection.CloseConnection();
                return Redirect("/Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                try
                {
                    personManager = new PersonManager(repository);
                }
                catch (Exception)
                {
                    Connection.CloseConnection();
                    return Redirect("/Error");
                }

                if (!IsValidPhoneNumber(PersonalInfo.PhoneNumber))
                {
                    Message = "Please enter valid phone number";
                    return Page();
                }
                ModelState.Remove("PersonalInfo.salt");
                if (ModelState.IsValid)
                {
                    PersonalInfo.Salt = securityManager.GetNewSalt();
                    PersonalInfo.Password = securityManager.GetHashWithSalt(PersonalInfo.Password, PersonalInfo.Salt);

                    PersonalInfo.UserType = UserType.CLIENT;
                    personManager.AddPerson(PersonalInfo);

                    Message = "";
                    return Redirect("Login?message=Please Login with your new account");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("PhoneNumber"))
                {
                    Message = "The phone number already exist.";
                }
                if (ex.Message.Contains("Email"))
                {
                    Message = "The email already exist.";
                }
                if (ex.Message.Contains("Username"))
                {
                    Message = "The username already exist.";
                }
                if (ex.Message.Contains("Username"))
                {
                    Message = "The username already exist.";
                }
                if (ex.Message.Contains("Fatal"))
                {
                    Message = "Connection issue please make sure that you are connected";
                    Connection.CloseConnection();
                }
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
            catch (Exception)
            {
                Message = "Something went wrong.";
            }
            return Page();
        }

        private bool IsValidPhoneNumber(string source)
        {
            MatchCollection matchs = Regex.Matches(source, "^[0-9]*$");
            if (matchs.Count == 1)
            {
                return true;
            }
            return false;
        }

    }
}
