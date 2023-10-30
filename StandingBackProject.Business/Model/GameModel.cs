namespace StandingBackProject.Business.Model
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public bool isDeleted { get; set; }
        public List<TournamentModel> Tournaments { get; set; }
        public List<ResultTournamentPlayerModel> ResultTournamentPlayers { get; set; }
    }
}
