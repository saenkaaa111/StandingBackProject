using Microsoft.EntityFrameworkCore;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly StandingContext _context;
        public GameRepository(StandingContext context)
        {
            _context = context;
        }

        public List<Game> GetGames(bool includeAll = false) => _context.Game.Where(t => !t.isDeleted || includeAll).ToList();

        public Game? GetById(int id) => _context.Game.Include(x => x.Tournaments).FirstOrDefault(x => x.Id == id);
        public Game? GetByTournament(Tournament tournament) => _context.Game.Include(x => x.Tournaments).FirstOrDefault(x => x.Tournaments == tournament);

        public int Add(Game game)
        {
            _context.Game.Add(game);
            _context.SaveChanges();
            return game.Id;
        }
        public void Update(Game oldGame, Game newGame)
        {
            oldGame.Name = newGame.Name;
            oldGame.DateStart = newGame.DateStart;
            oldGame.DateFinish = newGame.DateFinish;

            _context.SaveChanges();
        }

        public void Update(Game game, bool isDeleted)
        {
            game.isDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}
