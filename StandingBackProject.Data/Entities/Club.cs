namespace StandingBackProject.Data.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool isDeleted { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
