using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma.Logic;
using Shawarma.DataAccess;
using Shawarma.Enum;
using Shawarma.Models;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using DataAccessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Shawarma_website.Pages.Registration
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        PersonManager personManager;
        private IPersonRepository repository = new PersonStorage();
        private SecurityManager securityManager = new SecurityManager();

        [BindProperty]
        public Person PersonalInfo { get; set; }

        [BindProperty]
        [MinLength(5, ErrorMessage = "You can not have password shorter than 5 digits")]
        [MaxLength(40, ErrorMessage = "Your password can not be longer than 40 digits")]
        public string Password { get; set; }

        public string Message { get; set; }

        private int personId { get { return Convert.ToInt32(User.FindFirst("id").Value); } }

        public IActionResult OnGet()
        {
            try
            {
                personManager = new PersonManager(repository);
                PersonalInfo = personManager.GetPersonId(personId);
                Message = String.Empty;
            }
            catch (Exception)
            {
                Connection.CloseConnection();
                return Redirect("/Error");
            }
            return Page();
        }

        public IActionResult OnPostUpdate()
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
            try
            {
                if (!IsValidPhoneNumber(PersonalInfo.PhoneNumber))
                {
                    Message = "Please enter valid phone number";
                    return Page();
                }
                if (!String.IsNullOrWhiteSpace(Password)) 
                {
                    PersonalInfo.Password = securityManager.GetHashWithSalt(Password, PersonalInfo.Salt);
                }
                ModelState.Remove("PersonalInfo.Salt");
                ModelState.Remove("Password");
                if (ModelState.IsValid)
                {
                    
                    PersonalInfo.UserType = getUserType();
                    PersonalInfo.Id = personId;
                    personManager.UpdatePerson(PersonalInfo);

                    Message = "Successfully updated";
                    return Page();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Email"))
                {
                    Message = "The email already exist.";
                }
                if (ex.Message.Contains("PhoneNumber"))
                {
                    Message = "The phone number already exist.";
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

        private UserType getUserType()
        {
            if (User.IsInRole("ADMIN"))
            {
                return UserType.ADMIN;
            }
            else if (User.IsInRole("CLIENT"))
            {
                return UserType.CLIENT;
            }
            else
            {
                return UserType.EMPLOYEE;
            }

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
