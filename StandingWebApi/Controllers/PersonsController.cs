using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandingBackProject.API.Models.InputModels;
using StandingBackProject.API.Models.OutputModels;
using StandingBackProject.Business.Model;
using StandingBackProject.Business.Services;
using StandingBackProject.Data.Enums;

namespace StandingBackProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;
        public PersonsController(IMapper mapper, IPersonService personService)
        {
            _mapper = mapper;
            _personService = personService;
        }


        //api/Persons
        [HttpGet]
        public ActionResult<List<PersonShortOutputModel>> GetPersons()
        {
            var entities = _personService.GetList();
            var result = _mapper.Map<List<PersonShortOutputModel>>(entities);
            return result;
        }


        //api/Persons/deleted
        [HttpGet("deleted")]        
        public ActionResult<List<PersonShortOutputModel>> GetDeletedPersons()
        {
            var entities = _personService.GetListDeleted();
            var result = _mapper.Map<List<PersonShortOutputModel>>(entities);
            return Ok(result);
        }

       

        //api/Persons/42
        [HttpGet("{id}")]
        public ActionResult<PersonFullOutputModel> GetPersonById(int id)
        {
            var entities = _personService.GetById(id);
            var result = _mapper.Map<PersonFullOutputModel>(entities);
            return Ok(result);
        }


        //api/Persons
        [HttpPost]
        public ActionResult AddPerson([FromBody] PersonInputModel person)
        {
            var entity = _mapper.Map<PersonModel>(person);
            entity.Role = Role.Regular;
            var idCreate = _personService.Add(entity);
            return StatusCode(StatusCodes.Status201Created, idCreate);
        }

        //api/Persons/42
        [HttpPut("{id}")]
        public ActionResult EditPerson(int id, [FromBody] PersonInputModel person)
        {
            var entity = _mapper.Map<PersonModel>(person);
            _personService.Update(id, entity);
            return NoContent();
        }

        //api/Persons/42
        [HttpDelete("{id}")]
        public ActionResult DeletePersons(int id)
        {
            _personService.Update(id, true);
            return NoContent();
        }

        //api/Persons/42
        [HttpPatch("{id}")]
        public ActionResult RestorePerson(int id)
        {
            _personService.Update(id, false);
            return NoContent();
        }
    }
}
