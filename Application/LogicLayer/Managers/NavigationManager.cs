using Shawarma.Models;
using DataAccessLayer.Interfaces;
using Shawarma.DataAccess;

namespace Shawarma.Logic
{
    public class NavigationManager
    {
        private IPersonRepository repository = new PersonStorage();
        private PersonManager personManager;
        private SecurityManager securityManager = new SecurityManager();

        public NavigationManager() 
        {
           personManager = new PersonManager(repository);
        }

        public Person GivingAccess(string userName, string password)
        {
            Person person = new Person();
            person.Username = userName;

            person = personManager.GetPersonByUsername(person.Username);
            if (person == null)
            {
                return null;
            }

            password = securityManager.GetHashWithSalt(password, person.Salt);

            if (person.Username == userName && person.Password == password)
            {
                return person;
            }

            return null;
        }



    }
}
