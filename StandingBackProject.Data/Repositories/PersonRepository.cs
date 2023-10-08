using StandingBackProject.Data.Entities;


namespace StandingBackProject.Data.Repositories
{
    public class PersonRepository
    {
        private readonly StandingContext _context;

        public List<Person> GetPersons(bool includeAll = false) => _context.Person.Where(t => !t.isDeleted || includeAll).ToList();

        public Person? GetById(int id) => _context.Person.FirstOrDefault(x => x.Id == id);

        public Person? GetByNickname(string nickname) => _context.Person.FirstOrDefault(x => x.Nickname == nickname);

        public int Add(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
            return person.Id;
        }
        public void Update(Person oldPerson, Person newPerson)
        {
            oldPerson.Name = newPerson.Name;
            oldPerson.Nickname = newPerson.Nickname;
            oldPerson.Tournaments = newPerson.Tournaments;
            oldPerson.Team = newPerson.Team;            

            _context.SaveChanges();
        }

        public void Update(Person person, bool isDeleted)
        {
            person.isDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}
