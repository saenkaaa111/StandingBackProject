using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data.Repositories
{
    public interface IGameRepository
    {
        int Add(Game game);
        Game? GetById(int id);
        List<Game> GetGames(bool includeAll = false);
        void Update(Game game, bool isDeleted);
        void Update(Game oldGame, Game newGame);
    }
}