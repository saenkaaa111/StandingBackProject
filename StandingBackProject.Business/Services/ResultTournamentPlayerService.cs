using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Business.Services
{
    public class ResultTournamentPlayerService : IResultTournamentPlayerService
    {
        private readonly IResultTournamentPlayerRepository _repository;
        private readonly IPersonRepository _personRepository;
        private readonly IGameRepository _gameRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public ResultTournamentPlayerService(IResultTournamentPlayerRepository repository, IPersonRepository personRepository, IGameRepository gameRepository, ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _repository = repository;
            _gameRepository = gameRepository;
            _personRepository = personRepository;
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public ResultTournamentPlayerModel GetById(int id)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<ResultTournamentPlayerModel>(entity);
        }
        public ResultTournamentPlayerModel GetByGameId(int id)
        {
            var game = _gameRepository.GetById(id);
            var entity = _repository.GetByGame(game);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<ResultTournamentPlayerModel>(entity);
        }
        public ResultTournamentPlayerModel GetByPersonId(int id)
        {
            var person = _personRepository.GetById(id);
            var entity = _repository.GetByPerson(person);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<ResultTournamentPlayerModel>(entity);
        }

        public List<ResultTournamentPlayerModel> GetList(bool includeAll = false)
        {
            var entities = _repository.GetResultTournamentPlayers(includeAll);
            return _mapper.Map<List<ResultTournamentPlayerModel>>(entities);
        }

        public List<ResultTournamentPlayerModel> GetListDeleted(bool includeAll = true)
        {
            var entities = _repository.GetResultTournamentPlayers(includeAll).Where(t => t.isDeleted);
            return _mapper.Map<List<ResultTournamentPlayerModel>>(entities);

        }

        public int Add(ResultTournamentPlayerModel entity)
        {
            var addEntity = _mapper.Map<ResultTournamentPlayer>(entity);
            var person = _personRepository.GetById(entity.Person.Id);
            addEntity.Person = person;

            var tournament = _tournamentRepository.GetById(entity.Tournament.Id);
            addEntity.Tournament = tournament;
            
            var game = _gameRepository.GetById(entity.Game.Id);
            addEntity.Game = game;
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
