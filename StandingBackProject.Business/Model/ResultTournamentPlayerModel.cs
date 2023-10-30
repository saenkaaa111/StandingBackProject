namespace StandingBackProject.Business.Model
{
    public class ResultTournamentPlayerModel
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public PersonModel Person { get; set; }
        public TournamentModel Tournament { get; set; }
        public GameModel Game { get; set; }
        public bool isDeleted { get; set; }
    }
}
