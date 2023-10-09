using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Data.Repositories
{
    public class ResultTournamentTeamRepository : IResultTournamentTeamRepository
    {
        private readonly StandingContext _context;

        public List<ResultTournamentTeam> GetResultTournamentTeams() => _context.ResultTournamentTeam.ToList();

        public ResultTournamentTeam? GetById(int id) => _context.ResultTournamentTeam.FirstOrDefault(x => x.Id == id);
        public List<ResultTournamentTeam> GetByGame(Game game) => _context.ResultTournamentTeam.Where(x => x.Game == game).ToList();
        public List<ResultTournamentTeam> GetByTeam(Team team) => _context.ResultTournamentTeam.Where(x => x.Team == team).ToList();

        public int Add(ResultTournamentTeam resultTournamentTeam)
        {
            _context.ResultTournamentTeam.Add(resultTournamentTeam);
            _context.SaveChanges();
            return resultTournamentTeam.Id;
        }
        public void Update(ResultTournamentTeam oldResultTournamentTeam, ResultTournamentTeam newResultTournamentTeam)
        {
            oldResultTournamentTeam.Result = newResultTournamentTeam.Result;
            oldResultTournamentTeam.Game = newResultTournamentTeam.Game;
            oldResultTournamentTeam.Team = newResultTournamentTeam.Team;
            oldResultTournamentTeam.Tournament = newResultTournamentTeam.Tournament;

            _context.SaveChanges();
        }

        public void Update(ResultTournamentTeam resultTournamentTeam, bool isDeleted)
        {
            resultTournamentTeam.isDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}
