using Shawarma.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shawarma.Models
{
    public class Person
    {
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

        public Person() { }

        public Person(PersonOTD personOTD)
        {
            this.Id = (int)personOTD.Id;
            this.FirstName = personOTD.FirstName;
            this.LastName = personOTD.LastName;
            this.PhoneNumber = personOTD.PhoneNumber;
            this.Email = personOTD.Email;
            this.PhoneNumber = personOTD.PhoneNumber;
            this.Username = personOTD.Username;
            this.Password = personOTD.Password;
            this.UserType = personOTD.UserType;
            this.Salt = personOTD.Salt;
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
        [MaxLength(50, ErrorMessage = "you can not have email longer than 50 digits")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MinLength(3, ErrorMessage = " your username should be longer than 3 digits")]
        [MaxLength(40, ErrorMessage = " your username can not be longer than 40 digits")]
        public string Username { get; set; }

        public string Password { get; set; }


        public string Salt { get; set; }

        public UserType? UserType { get; set; }

        public string ToString(string filterType) 
        {
            if (filterType == "All")
            {
                return $"{Id} - Type: {UserType} - First name: {FirstName} - Last name: {LastName} - Phone Number: {PhoneNumber} - Email: {Email} - Username: {Username} - Password: {Password}";
            }
            else if (filterType == "Name") 
            {
                return $"{Id} - First name: {FirstName} - Last name: {LastName}";
            }
            else if (filterType == "BeforeDelete")
            {
                return $"{Id} - First name: {FirstName} - Last name: {LastName}";
            }
            return filterType;
        }

    }
}
