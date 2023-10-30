namespace StandingBackProject.API.Models.InputModels
{
    public class TournamentShortInputModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int ClubId { get; set; }
        public int JudgeId { get; set; }
    }
}
