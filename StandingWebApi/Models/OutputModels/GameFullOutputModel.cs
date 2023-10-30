using StandingBackProject.Business.Model;

namespace StandingBackProject.API.Models.OutputModels
{
    public class GameFullOutputModel: GameOutputModel
    {
        public List<TournamentOutputModel> Tournaments { get; set; }
    }
}
