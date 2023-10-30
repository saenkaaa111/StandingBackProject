using StandingBackProject.Business.Model;

namespace StandingBackProject.Business.Services
{
    public interface IClubService
    {
        int Add(ClubModel entity);
        ClubModel GetById(int id);
        List<ClubModel> GetList(bool includeAll = false);
        List<ClubModel> GetListDeleted(bool includeAll = true);
        void Update(int id, bool isDeleted);
        void Update(int id, ClubModel entity);
    }
}