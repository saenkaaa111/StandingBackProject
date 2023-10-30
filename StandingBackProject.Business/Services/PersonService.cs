using AutoMapper;
using StandingBackProject.Business.Model;
using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Repositories;

namespace StandingBackProject.Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public PersonModel GetById(int id)
        {
            var entity = _repository.GetById(id);
            ThrowIfEntityNotFound(entity, id);
            return _mapper.Map<PersonModel>(entity);
        }

        public List<PersonModel> GetList(bool includeAll = false)
        {
            var entities = _repository.GetPersons(includeAll);
            return _mapper.Map<List<PersonModel>>(entities);
        }

        public List<PersonModel> GetListDeleted(bool includeAll = true)
        {
            var entities = _repository.GetPersons(includeAll).Where(t => t.isDeleted);
            return _mapper.Map<List<PersonModel>>(entities);

        }

        public int Add(PersonModel entity)
        {
            var addEntity = _mapper.Map<Person>(entity);
            var id = _repository.Add(addEntity);
            return id;
        }

        public void Update(int id, PersonModel entity)
        {
            var personOld = _repository.GetById(id);
            ThrowIfEntityNotFound(personOld, id);
            var personNew = _mapper.Map<Person>(entity);
            _repository.Update(personOld, personNew);

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
