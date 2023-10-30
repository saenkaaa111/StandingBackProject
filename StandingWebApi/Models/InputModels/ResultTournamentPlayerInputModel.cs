namespace StandingBackProject.API.Models.InputModels
{
    public class ResultTournamentPlayerInputModel
    {
        public string Result { get; set; }
        public int PersonId { get; set; }
        public int TournamentId { get; set; }
        public int GameId { get; set; }
    }
}
