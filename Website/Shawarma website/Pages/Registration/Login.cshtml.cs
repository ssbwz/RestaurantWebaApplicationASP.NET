using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shawarma.Models;
using Shawarma.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Shawarma.Logic;
using MySql.Data.MySqlClient;
using DataAccessLayer.Interfaces;

namespace Shawarma_website.Pages.Registration
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private IPersonRepository reposiory = new PersonStorage();
        private PersonManager personManager { get;  set; }

        private SecurityManager securityManager = new SecurityManager();

        public Person CurrentUser { get; set; }

        public string Message { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnGet(string message)
        {
            Message = message;
            try
            {
                personManager = new PersonManager(reposiory);
            }
            catch (Exception ex)
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
                    personManager = new PersonManager(reposiory);
                }
                catch (Exception)
                {
                    Connection.CloseConnection();
                    return Redirect("/Error");
                }

                CurrentUser = personManager.GetPersonByUsername(Username);

                Password = securityManager.GetHashWithSalt(Password, CurrentUser.Salt);

                if (CurrentUser.Username == Username && CurrentUser.Password == Password)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, Username));
                    claims.Add(new Claim(ClaimTypes.Role, $"{CurrentUser.UserType}"));
                    claims.Add(new Claim("id", $"{CurrentUser.Id}"));
                    claims.Add(new Claim("first name", $"{CurrentUser.FirstName}"));
                    claims.Add(new Claim("last name", $"{CurrentUser.LastName}"));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    Message = " ";
                    return Redirect("../Index");
                }
                Message = "Please check the username and the password";
                return Page();
            }
            catch (NullReferenceException)
            {
                Message = "The username or password you’ve entered is incorrect";
                Connection.CloseConnection();
                return Page();
            }
            catch (AggregateException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return Page();
            }
            catch (InvalidOperationException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return Page();
            }
            catch (MySqlException)
            {
                Message = "Connection issue please make sure that you are connected";
                Connection.CloseConnection();
                return Page();
            }
            catch (Exception) 
            {
                Message = "Something went wrong";
                return Page();
            }
        }
    }
}
