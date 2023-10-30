using StandingBackProject.Data.Entities;

namespace StandingBackProject.API.Models.OutputModels
{
    public class ResultTournamentPlayerOutputModel
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public int PersonId { get; set; }
        public int GameId { get; set; }
    }
}
