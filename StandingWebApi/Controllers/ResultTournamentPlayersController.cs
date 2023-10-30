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
    public class ResultTournamentPlayersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IResultTournamentPlayerService _resultTournamentPlayerService;
        public ResultTournamentPlayersController(IMapper mapper, IResultTournamentPlayerService resultTournamentPlayerService)
        {
            _mapper = mapper;
            _resultTournamentPlayerService = resultTournamentPlayerService;
        }


        //api/ResultTournamentPlayers
        [HttpGet]
        public ActionResult<List<ResultTournamentPlayerFullOutputModel>> GetResultTournamentPlayers()
        {
            var entities = _resultTournamentPlayerService.GetList();
            var result = _mapper.Map<List<ResultTournamentPlayerFullOutputModel>>(entities);
            return result;
        }


        //api/ResultTournamentPlayers/deleted
        [HttpGet("deleted")]
        public ActionResult<List<ResultTournamentPlayerFullOutputModel>> GetDeletedResultTournamentPlayers()
        {
            var entities = _resultTournamentPlayerService.GetListDeleted();
            var result = _mapper.Map<List<ResultTournamentPlayerFullOutputModel>>(entities);
            return Ok(result);
        }

        //api/ResultTournamentPlayers/42
        [HttpGet("{id}")]
        public ActionResult<ResultTournamentPlayerFullOutputModel> GetResultTournamentPlayerById(int id)
        {
            var entities = _resultTournamentPlayerService.GetById(id);
            var result = _mapper.Map<ResultTournamentPlayerFullOutputModel>(entities);
            return Ok(result);
        }

        //api/ResultTournamentPlayers/by-game/42
        [HttpGet("by-game/{gameid}")]
        public ActionResult<ResultTournamentPlayerFullOutputModel> GetResultTournamentPlayerByGameId(int gameid)
        {
            var entities = _resultTournamentPlayerService.GetById(gameid);
            var result = _mapper.Map<ResultTournamentPlayerFullOutputModel>(entities);
            return Ok(result);
        }

        //api/ResultTournamentPlayers/by-person/42
        [HttpGet("by-person/{personid}")]
        public ActionResult<ResultTournamentPlayerFullOutputModel> GetResultTournamentPlayerByPersonId(int personid)
        {
            var entities = _resultTournamentPlayerService.GetById(personid);
            var result = _mapper.Map<ResultTournamentPlayerFullOutputModel>(entities);
            return Ok(result);
        }


        //api/ResultTournamentPlayers
        [HttpPost]
        public ActionResult AddResultTournamentPlayer([FromBody] ResultTournamentPlayerInputModel resultTournamentPlayer)
        {
            var entity = _mapper.Map<ResultTournamentPlayerModel>(resultTournamentPlayer);
            var idCreate = _resultTournamentPlayerService.Add(entity);
            return StatusCode(StatusCodes.Status201Created, idCreate);
        }

        //api/ResultTournamentPlayers/42
        [HttpPut("{id}")]
        public ActionResult EditResultTournamentPlayer(int id, [FromBody] ResultTournamentPlayerInputModel station)
        {
            var entity = _mapper.Map<ResultTournamentPlayerModel>(station);
            _resultTournamentPlayerService.Update(id, entity);
            return NoContent();
        }

        //api/ResultTournamentPlayers/42
        [HttpDelete("{id}")]
        public ActionResult DeleteResultTournamentPlayer(int id)
        {
            _resultTournamentPlayerService.Update(id, true);
            return NoContent();
        }

        //api/ResultTournamentPlayers/42
        [HttpPatch("{id}")]
        public ActionResult RestoreResultTournamentPlayer(int id)
        {
            _resultTournamentPlayerService.Update(id, false);
            return NoContent();
        }
    }
}

