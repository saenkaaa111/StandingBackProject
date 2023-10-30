using StandingBackProject.Business.Model;

namespace StandingBackProject.Business.Services
{
    public interface IGameService
    {
        int Add(GameModel entity);
        GameModel GetById(int id);
        List<GameModel> GetList(bool includeAll = false);
        List<GameModel> GetListDeleted(bool includeAll = true);
        void Update(int id, bool isDeleted);
        void Update(int id, GameModel entity);
    }
}