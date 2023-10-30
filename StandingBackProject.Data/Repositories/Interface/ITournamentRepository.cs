using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public interface ITournamentRepository
    {
        int Add(Tournament tournament);
        Tournament? GetById(int id);
        List<Tournament> GetTournaments();
        void Update(Tournament oldTournament, Tournament newTournament);
    }
}