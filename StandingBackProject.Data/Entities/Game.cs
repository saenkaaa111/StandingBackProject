namespace StandingBackProject.Data.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public bool isDeleted { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set;}
        public virtual ICollection<ResultTournamentPlayer> ResultTournamentPlayers { get; set; }

    }
}
