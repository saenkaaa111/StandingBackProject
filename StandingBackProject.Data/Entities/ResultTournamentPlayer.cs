namespace StandingBackProject.Data.Entities
{
    public class ResultTournamentPlayer
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public virtual Person Person { get; set; }            
        public virtual Tournament Tournament { get; set; }
        public virtual Game Game { get; set; }
        public bool isDeleted { get; set; }

    }
}
