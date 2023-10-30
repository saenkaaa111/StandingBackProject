using StandingBackProject.Business.Model;

namespace StandingBackProject.Business.Services
{
    public interface ITournamentService
    {
        int Add(TournamentModel entity);
        TournamentModel GetById(int id);
        List<TournamentModel> GetList();
        void Update(int id, TournamentModel entity);
    }
}