namespace StandingBackProject.Data.Entities
{
    public class ResultTournamentTeam
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual Game Game { get; set; }
        public bool isDeleted { get; set; }
    }
}
