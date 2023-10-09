using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Data.Repositories
{
    public class ResultTournamentPlayerRepository : IResultTournamentPlayerRepository
    {
        private readonly StandingContext _context;

        public List<ResultTournamentPlayer> GetResultTournamentPlayers() => _context.ResultTournamentPlayer.ToList();

        public ResultTournamentPlayer? GetById(int id) => _context.ResultTournamentPlayer.FirstOrDefault(x => x.Id == id);
        public List<ResultTournamentPlayer> GetByGame(Game game) => _context.ResultTournamentPlayer.Where(x => x.Game == game).ToList();
        public List<ResultTournamentPlayer> GetByPerson(Person person) => _context.ResultTournamentPlayer.Where(x => x.Person == person).ToList();

        public int Add(ResultTournamentPlayer resultTournamentPlayer)
        {
            _context.ResultTournamentPlayer.Add(resultTournamentPlayer);
            _context.SaveChanges();
            return resultTournamentPlayer.Id;
        }
        public void Update(ResultTournamentPlayer oldResultTournamentPlayer, ResultTournamentPlayer newResultTournamentPlayer)
        {
            oldResultTournamentPlayer.Result = newResultTournamentPlayer.Result;
            oldResultTournamentPlayer.Game = newResultTournamentPlayer.Game;
            oldResultTournamentPlayer.Person = newResultTournamentPlayer.Person;
            oldResultTournamentPlayer.Tournament = newResultTournamentPlayer.Tournament;

            _context.SaveChanges();
        }

        public void Update(ResultTournamentPlayer resultTournamentPlayer, bool isDeleted)
        {
            resultTournamentPlayer.isDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}
