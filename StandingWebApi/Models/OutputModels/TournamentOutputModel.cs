using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Enums;

namespace StandingBackProject.API.Models.OutputModels
{
    public class TournamentOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int ClubId { get; set; }
        public int JudgeId { get; set; }
        public int GameId { get; set; }
        public List<ResultTournamentPlayerOutputModel> ResultTournamentPlayers { get; set; }
        //public List<ResultTournamentTeamOutputModel> ResultTournamentTeams { get; set; }

    }
}
