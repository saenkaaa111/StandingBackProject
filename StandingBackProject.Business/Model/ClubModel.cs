namespace StandingBackProject.Business.Model
{
    public class ClubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool isDeleted { get; set; }
        public List<TournamentModel> Tournaments { get; set; }
    }
}
