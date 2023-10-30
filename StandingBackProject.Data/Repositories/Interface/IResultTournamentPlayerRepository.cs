using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public interface IResultTournamentPlayerRepository
    {
        int Add(ResultTournamentPlayer resultTournamentPlayer);
        List<ResultTournamentPlayer> GetByGame(Game game);
        ResultTournamentPlayer? GetById(int id);
        List<ResultTournamentPlayer> GetByPerson(Person person);
        List<ResultTournamentPlayer> GetResultTournamentPlayers(bool includeAll);
        void Update(ResultTournamentPlayer resultTournamentPlayer, bool isDeleted);
        void Update(ResultTournamentPlayer oldResultTournamentPlayer, ResultTournamentPlayer newResultTournamentPlayer);
    }
}