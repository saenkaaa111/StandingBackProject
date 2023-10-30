using StandingBackProject.Data.Enums;

namespace StandingBackProject.Data.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public virtual Club Club { get; set; }
        public virtual Person? Judge { get; set; } //судья
        public virtual Game Game { get; set; }
        public virtual ICollection<ResultTournamentPlayer> ResultTournamentPlayers { get; set; }

    }
}
