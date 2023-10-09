using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Business.Services
{
    public class ResultTournamentTeamService
    {
        private readonly IResultTournamentTeamRepository _repository;
        private readonly IMapper _mapper;

        public ResultTournamentTeamService(IResultTournamentTeamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ResultTournamentTeamModel GetById(int id)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<ResultTournamentTeamModel>(entity);
        }

        public List<ResultTournamentTeamModel> GetList()
        {
            var entities = _repository.GetResultTournamentTeams();
            return _mapper.Map<List<ResultTournamentTeamModel>>(entities);
        }


        public int Add(ResultTournamentTeamModel entity)
        {
            var addEntity = _mapper.Map<ResultTournamentTeam>(entity);
            var id = _repository.Add(addEntity);
            return id;
        }

        public void Update(int id, ResultTournamentTeamModel entity)
        {
            var resultTournamentTeamOld = _repository.GetById(id);
            ThrowIfEntityNotFound(resultTournamentTeamOld, id);
            var resultTournamentTeamNew = _mapper.Map<ResultTournamentTeam>(entity);
            _repository.Update(resultTournamentTeamOld, resultTournamentTeamNew);

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
