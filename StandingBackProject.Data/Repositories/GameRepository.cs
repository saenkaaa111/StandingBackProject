using StandingBackProject.Data.Entities;


namespace StandingBackProject.Data.Repositories
{
    public class GameRepository
    {
        private readonly StandingContext _context;

        public List<Game> GetGames(bool includeAll = false) => _context.Game.Where(t => !t.isDeleted || includeAll).ToList();

        public Game? GetById(int id) => _context.Game.FirstOrDefault(x => x.Id == id);
                
        public int Add(Game game)
        {
            _context.Game.Add(game);
            _context.SaveChanges();
            return game.Id;
        }
        public void Update(Game oldGame, Game newGame)
        {
            oldGame.Name = newGame.Name;            

            _context.SaveChanges();
        }

        public void Update(Game game, bool isDeleted)
        {
            game.isDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}
