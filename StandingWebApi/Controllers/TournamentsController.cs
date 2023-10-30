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
    public class TournamentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITournamentService _tournamentService;
        public TournamentsController(IMapper mapper, ITournamentService tournamentService)
        {
            _mapper = mapper;
            _tournamentService = tournamentService;
        }


        //api/Tournaments
        [HttpGet]
        public ActionResult<List<TournamentOutputModel>> GetTournaments()
        {
            var entities = _tournamentService.GetList();
            var result = _mapper.Map<List<TournamentOutputModel>>(entities);
            return result;
        }


        //api/Tournaments/42
        [HttpGet("{id}")]
        public ActionResult<TournamentOutputModel> GetTournamentById(int id)
        {
            var entities = _tournamentService.GetById(id);
            var result = _mapper.Map<TournamentOutputModel>(entities);
            return Ok(result);
        }


        //api/Tournaments
        [HttpPost]
        public ActionResult AddTournament([FromBody] TournamentInputModel tournament)
        {
            var entity = _mapper.Map<TournamentModel>(tournament);
            var idCreate = _tournamentService.Add(entity);
            return StatusCode(StatusCodes.Status201Created, idCreate);
        }

        //api/Tournaments/42
        [HttpPut("{id}")]
        public ActionResult EditTournament(int id, [FromBody] TournamentInputModel tournament)
        {
            var entity = _mapper.Map<TournamentModel>(tournament);
            _tournamentService.Update(id, entity);
            return NoContent();
        }

    }
}
