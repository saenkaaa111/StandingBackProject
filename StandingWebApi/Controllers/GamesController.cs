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
    public class GamesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGameService _gameService;
        public GamesController(IMapper mapper, IGameService gameService)
        {
            _mapper = mapper;
            _gameService = gameService;
        }


        //api/Games
        [HttpGet]
        public ActionResult<List<GameOutputModel>> GetGames()
        {
            var entities = _gameService.GetList();
            var result = _mapper.Map<List<GameOutputModel>>(entities);
            return result;
        }


        //api/Games/deleted
        [HttpGet("deleted")]
        public ActionResult<List<GameOutputModel>> GetDeletedGames()
        {
            var entities = _gameService.GetListDeleted();
            var result = _mapper.Map<List<GameOutputModel>>(entities);
            return Ok(result);
        }

        //api/Games/42
        [HttpGet("{id}")]
        public ActionResult<GameFullOutputModel> GetGameById(int id)
        {
            var entities = _gameService.GetById(id);
            var result = _mapper.Map<GameFullOutputModel>(entities);
            return Ok(result);
        }


        //api/Games
        [HttpPost]
        public ActionResult AddGame([FromBody] GameInputModel game)
        {
            var entity = _mapper.Map<GameModel>(game);
            var idCreate = _gameService.Add(entity);
            return StatusCode(StatusCodes.Status201Created, idCreate);
        }

        //api/Games/42
        [HttpPut("{id}")]
        public ActionResult EditGame(int id, [FromBody] GameInputModel game)
        {
            var entity = _mapper.Map<GameModel>(game);
            _gameService.Update(id, entity);
            return NoContent();
        }

        //api/Games/42
        [HttpDelete("{id}")]
        public ActionResult DeleteGames(int id)
        {
            _gameService.Update(id, true);
            return NoContent();
        }

        //api/Games/42
        [HttpPatch("{id}")]
        public ActionResult RestoreGame(int id)
        {
            _gameService.Update(id, false);
            return NoContent();
        }
    }
}
