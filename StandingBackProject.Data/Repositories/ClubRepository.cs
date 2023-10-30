using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Data.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly StandingContext _context;
        public ClubRepository(StandingContext context)
        {
            _context = context;
        }

        public List<Club> GetClubs(bool includeAll = false) => _context.Club.Where(t => !t.isDeleted || includeAll).ToList();

        public Club? GetById(int id) => _context.Club.FirstOrDefault(x => x.Id == id);

        public Club? GetByCity(string city) => _context.Club.FirstOrDefault(x => x.City == city);

        public int Add(Club club)
        {
            _context.Club.Add(club);
            _context.SaveChanges();
            return club.Id;
        }
        public void Update(Club oldClub, Club newClub)
        {
            oldClub.Address = newClub.Address;
            oldClub.Tournaments = newClub.Tournaments;
            _context.SaveChanges();
        }

        public void Update(Club club, bool isDeleted)
        {
            club.isDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}
