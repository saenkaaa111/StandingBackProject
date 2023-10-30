using Microsoft.EntityFrameworkCore;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Data.Repositories
{
    public class ResultTournamentPlayerRepository : IResultTournamentPlayerRepository
    {
        private readonly StandingContext _context;
        public ResultTournamentPlayerRepository(StandingContext context)
        {
            _context = context;
        }

        public List<ResultTournamentPlayer> GetResultTournamentPlayers(bool includeAll = false) => 
                        _context.ResultTournamentPlayer.Where(t => !t.isDeleted || includeAll)
                                                .Include(x => x.Person)
                                                .Include(x => x.Tournament)
                                                .Include(x => x.Game)
                                                .ToList();
            
        public List<ResultTournamentPlayer> GetResultTournamentPlayers() => _context.ResultTournamentPlayer.ToList();

        public ResultTournamentPlayer? GetById(int id) => _context.ResultTournamentPlayer.Include(x => x.Person).Include(x => x.Game).Include(x => x.Tournament).FirstOrDefault(x => x.Id == id);
        public List<ResultTournamentPlayer> GetByGame(Game game) => _context.ResultTournamentPlayer.Where(x => x.Game == game).Include(x => x.Game).Include(x => x.Person).Include(x => x.Tournament).ToList();
        public List<ResultTournamentPlayer> GetByPerson(Person person) => _context.ResultTournamentPlayer.Where(x => x.Person == person).Include(x => x.Person).Include(x => x.Game).Include(x => x.Tournament).ToList();

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
