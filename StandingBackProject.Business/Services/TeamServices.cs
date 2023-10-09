using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Business.Services
{
    public class TeamService
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TeamModel GetById(int id)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<TeamModel>(entity);
        }

        public List<TeamModel> GetList(bool includeAll = false)
        {
            var entities = _repository.GetTeams(includeAll);
            return _mapper.Map<List<TeamModel>>(entities);
        }

        public List<TeamModel> GetListDeleted(bool includeAll = true)
        {
            var entities = _repository.GetTeams(includeAll).Where(t => t.isDeleted);
            return _mapper.Map<List<TeamModel>>(entities);

        }


        public int Add(TeamModel entity)
        {
            var addEntity = _mapper.Map<Team>(entity);
            var id = _repository.Add(addEntity);
            return id;
        }

        public void Update(int id, TeamModel entity)
        {
            var teamOld = _repository.GetById(id);
            ThrowIfEntityNotFound(teamOld, id);
            var teamNew = _mapper.Map<Team>(entity);
            _repository.Update(teamOld, teamNew);

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
                throw new Exception();
        }

    }
}
