using Shawarma.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IPersonRepository
    {
        public bool AddPerson(PersonOTD p);

        public List<PersonOTD> GetPersons();
        public PersonOTD GetPersonById(int id);

        public int GetIDByUsername(string username);

        public int GetIDByEmail(string email);
        public int GetIDByPhoneNumber(string phoneNumber);

        public bool UpdatePerson(PersonOTD p);

        public bool DeletePerson(PersonOTD person);
    }
}
