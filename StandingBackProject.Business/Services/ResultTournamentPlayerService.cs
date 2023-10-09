using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Business.Services
{
    public class ResultTournamentPlayerService
    {
        private readonly IResultTournamentPlayerRepository _repository;
        private readonly IMapper _mapper;

        public ResultTournamentPlayerService(IResultTournamentPlayerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ResultTournamentPlayerModel GetById(int id)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<ResultTournamentPlayerModel>(entity);
        }

        public List<ResultTournamentPlayerModel> GetList()
        {
            var entities = _repository.GetResultTournamentPlayers();
            return _mapper.Map<List<ResultTournamentPlayerModel>>(entities);
        }
              

        public int Add(ResultTournamentPlayerModel entity)
        {
            var addEntity = _mapper.Map<ResultTournamentPlayer>(entity);
            var id = _repository.Add(addEntity);
            return id;
        }

        public void Update(int id, ResultTournamentPlayerModel entity)
        {
            var resultTournamentPlayerOld = _repository.GetById(id);
            ThrowIfEntityNotFound(resultTournamentPlayerOld, id);
            var resultTournamentPlayerNew = _mapper.Map<ResultTournamentPlayer>(entity);
            _repository.Update(resultTournamentPlayerOld, resultTournamentPlayerNew);

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
