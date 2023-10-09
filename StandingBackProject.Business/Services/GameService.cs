using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Business.Services
{
    public class GameService
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public GameModel GetById(int id)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<GameModel>(entity);
        }

        public List<GameModel> GetList(bool includeAll = false)
        {
            var entities = _repository.GetGames(includeAll);
            return _mapper.Map<List<GameModel>>(entities);
        }

        public List<GameModel> GetListDeleted(bool includeAll = true)
        {
            var entities = _repository.GetGames(includeAll).Where(t => t.isDeleted);
            return _mapper.Map<List<GameModel>>(entities);

        }


        public int Add(GameModel entity)
        {
            var addEntity = _mapper.Map<Game>(entity);
            var id = _repository.Add(addEntity);
            return id;
        }

        public void Update(int id, GameModel entity)
        {
            var gameOld = _repository.GetById(id);
            ThrowIfEntityNotFound(gameOld, id);
            var gameNew = _mapper.Map<Game>(entity);
            _repository.Update(gameOld, gameNew);

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
