using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public interface IResultTournamentTeamRepository
    {
        int Add(ResultTournamentTeam resultTournamentTeam);
        List<ResultTournamentTeam> GetByGame(Game game);
        ResultTournamentTeam? GetById(int id);
        List<ResultTournamentTeam> GetByTeam(Team team);
        List<ResultTournamentTeam> GetResultTournamentTeams();
        void Update(ResultTournamentTeam resultTournamentTeam, bool isDeleted);
        void Update(ResultTournamentTeam oldResultTournamentTeam, ResultTournamentTeam newResultTournamentTeam);
    }
}