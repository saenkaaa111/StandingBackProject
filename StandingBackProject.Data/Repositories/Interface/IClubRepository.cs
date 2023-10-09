using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public interface IClubRepository
    {
        int Add(Club club);
        Club? GetByCity(string city);
        Club? GetById(int id);
        List<Club> GetClubs(bool includeAll = false);
        void Update(Club club, bool isDeleted);
        void Update(Club oldClub, Club newClub);
    }
}