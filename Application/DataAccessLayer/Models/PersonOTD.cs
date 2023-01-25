using Shawarma.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shawarma.Models
{
    public class PersonOTD
    {
        public PersonOTD(int id ,UserType userType, string firstName, string lastName, string phoneNumber,string email, string userName, string password)
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

        public PersonOTD(UserType userType, string firstName, string lastName, string phoneNumber, string email, string userName, string password)
        {
            UserType = userType;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = userName;
            Password = password;
        }

        public PersonOTD() { }

        public int? Id { get; set; }

        public UserType? UserType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


    }
}
