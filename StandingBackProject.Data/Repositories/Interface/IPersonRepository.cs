using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public interface IPersonRepository
    {
        int Add(Person person);
        Person? GetById(int id);
        Person? GetByNickname(string nickname);
        List<Person> GetPersons(bool includeAll = false);
        void Update(Person person, bool isDeleted);
        void Update(Person oldPerson, Person newPerson);
    }
}