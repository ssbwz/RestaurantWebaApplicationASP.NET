using System.ComponentModel.DataAnnotations;
using Shawarma_website.Enum;

namespace Shawarma_website.Models
{
    public class Person
    {
        public Person() { }
        public Person(int id, UserType userType, string firstName, string lastName, string phoneNumber, string email, string userName, string password)
        {
            this.Id = id;
            UserType = userType;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = userName;
            Password = password;
        }
        public Person(UserType userType, string firstName, string lastName, string phoneNumber, string email, string userName, string password)
        {
            UserType = userType;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = userName;
            Password = password;
        }


        public int Id { get; set; }
        [Required(ErrorMessage = "Please Fill the first name")]
        [MaxLength(40, ErrorMessage = "You can not have first name longer than 40 digits")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Fill the second name")]
        [MaxLength(40, ErrorMessage = "You can not have last name longer than 40 digits")]
        public string LastName { get; set; }
        [MaxLength(15, ErrorMessage = "You can not have phone number longer than 15 digits")]
        [MinLength(5, ErrorMessage = "You can not have phone number less than 5 digits")]
        public string PhoneNumber { get; set; }

        [MinLength(10, ErrorMessage = "Your email should be longer than 10 digits")]
        //[RegularExpression("@",ErrorMessage = "Please fill vaild email")]
        [MaxLength(50, ErrorMessage = "you can not have email longer than 50 digits")]

        public string Email { get; set; }
        [MinLength(3, ErrorMessage = " your username should be longer than 3 digits")]
        [MaxLength(40, ErrorMessage = " your username can not be longer than 40 digits")]
        public string Username { get; set; }

        [MinLength(5, ErrorMessage = "You can not have password shorter than 5 digits")]
        [MaxLength(40, ErrorMessage = "Your password can not be longer than 40 digits")]
        [Required(ErrorMessage = "Please fill the password")]
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
