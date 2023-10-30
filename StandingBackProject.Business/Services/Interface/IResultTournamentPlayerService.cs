using StandingBackProject.Business.Model;

namespace StandingBackProject.Business.Services
{
    public interface IResultTournamentPlayerService
    {
        int Add(ResultTournamentPlayerModel entity);
        ResultTournamentPlayerModel GetById(int id);
        List<ResultTournamentPlayerModel> GetList(bool includeAll = false);
        List<ResultTournamentPlayerModel> GetListDeleted(bool includeAll = true);
        void Update(int id, bool isDeleted);
        void Update(int id, ResultTournamentPlayerModel entity);
    }
}