using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandingBackProject.API.Models.InputModels;
using StandingBackProject.API.Models.OutputModels;
using StandingBackProject.Business.Model;
using StandingBackProject.Business.Services;

namespace StandingBackProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClubService _clubService;
        public ClubsController(IMapper mapper, IClubService clubService)
        {
            _mapper = mapper;
            _clubService = clubService;
        }


        //api/Clubs
        [HttpGet]
        public ActionResult<List<ClubOutputModel>> GetClubs()
        {
            var entities = _clubService.GetList();
            var result = _mapper.Map<List<ClubOutputModel>>(entities);
            return result;
        }


        //api/Clubs/deleted
        [HttpGet("deleted")]
        public ActionResult<List<ClubOutputModel>> GetDeletedClubs()
        {
            var entities = _clubService.GetListDeleted();
            var result = _mapper.Map<List<ClubOutputModel>>(entities);
            return Ok(result);
        }

        //api/Clubs/42
        [HttpGet("{id}")]
        public ActionResult<ClubOutputModel> GetClubById(int id)
        {
            var entities = _clubService.GetById(id);
            var result = _mapper.Map<ClubOutputModel>(entities);
            return Ok(result);
        }


        //api/Clubs
        [HttpPost]
        public ActionResult AddClub([FromBody] ClubInputModel club)
        {
            var entity = _mapper.Map<ClubModel>(club);
            var idCreate = _clubService.Add(entity);
            return StatusCode(StatusCodes.Status201Created, idCreate);
        }

        //api/Clubs/42
        [HttpPut("{id}")]
        public ActionResult EditClub(int id, [FromBody] ClubShortInputModel club)
        {
            var entity = _mapper.Map<ClubModel>(club);
            _clubService.Update(id, entity);
            return NoContent();
        }

        //api/Clubs/42
        [HttpDelete("{id}")]
        public ActionResult DeleteClubs(int id)
        {
            _clubService.Update(id, true);
            return NoContent();
        }

        //api/Clubs/42
        [HttpPatch("{id}")]
        public ActionResult RestoreClub(int id)
        {
            _clubService.Update(id, false);
            return NoContent();
        }
    }
}
