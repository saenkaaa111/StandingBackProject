using AutoMapper;
using StandingBackProject.Business.Exceptions;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Business.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _repository;
        private readonly IMapper _mapper;

        public ClubService(IClubRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ClubModel GetById(int id)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<ClubModel>(entity);
        }

        public List<ClubModel> GetList(bool includeAll = false)
        {
            var entities = _repository.GetClubs(includeAll);
            return _mapper.Map<List<ClubModel>>(entities);
        }

        public List<ClubModel> GetListDeleted(bool includeAll = true)
        {
            var entities = _repository.GetClubs(includeAll).Where(t => t.isDeleted);
            return _mapper.Map<List<ClubModel>>(entities);

        }


        public int Add(ClubModel entity)
        {
            var addEntity = _mapper.Map<Club>(entity);
            var id = _repository.Add(addEntity);
            return id;
        }

        public void Update(int id, ClubModel entity)
        {
            var clubOld = _repository.GetById(id);
            ThrowIfEntityNotFound(clubOld, id);
            var clubNew = _mapper.Map<Club>(entity);
            _repository.Update(clubOld, clubNew);

        }

        public void Update(int id, bool isDeleted)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            _repository.Update(entity, isDeleted);

        }
        private static void ThrowIfEntityNotFound<T>(T? entity, int id)
        {
            if (entity is null)
                throw new NotFoundException(typeof(T).Name, id);
        }

    }
}