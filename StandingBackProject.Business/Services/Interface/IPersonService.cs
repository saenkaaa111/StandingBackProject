using StandingBackProject.Business.Model;

namespace StandingBackProject.Business.Services
{
    public interface IPersonService
    {
        int Add(PersonModel entity);
        PersonModel GetById(int id);
        List<PersonModel> GetList(bool includeAll = false);
        List<PersonModel> GetListDeleted(bool includeAll = true);
        void Update(int id, bool isDeleted);
        void Update(int id, PersonModel entity);
    }
}