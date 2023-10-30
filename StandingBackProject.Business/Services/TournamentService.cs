using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Business.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _repository;
        private readonly IGameRepository _gameRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public TournamentService(ITournamentRepository repository, 
                                    IGameRepository gameRepository, 
                                    IPersonRepository personRepository, 
                                    IClubRepository clubRepository,
                                    IMapper mapper)
        {
            _repository = repository;
            _gameRepository = gameRepository;
            _personRepository = personRepository;
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public TournamentModel GetById(int id)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<TournamentModel>(entity);
        }

        public List<TournamentModel> GetList()
        {
            var entities = _repository.GetTournaments();
            return _mapper.Map<List<TournamentModel>>(entities);
        }

        public int Add(TournamentModel entity)
        {
            var addEntity = _mapper.Map<Tournament>(entity);
            var club = _clubRepository.GetById(addEntity.Club.Id);
            var judgle = _personRepository.GetById(addEntity.Judge.Id);
            var game = _gameRepository.GetById(addEntity.Game.Id);
            addEntity.Club = club;
            addEntity.Judge = judgle;
            addEntity.Game = game;
            addEntity.Status = 0;
            var id = _repository.Add(addEntity);
            return id;
        }

        public void Update(int id, TournamentModel entity)
        {
            var tournamentOld = _repository.GetById(id);
            ThrowIfEntityNotFound(tournamentOld, id);
            var tournamentNew = _mapper.Map<Tournament>(entity);
            _repository.Update(tournamentOld, tournamentNew);

        }
                
        private static void ThrowIfEntityNotFound<T>(T? entity, int id)
        {
            if (entity is null)
                throw new Exception();
        }

    }
}