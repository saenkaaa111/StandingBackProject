using StandingBackProject.Data.Entities;

namespace StandingBackProject.API.Models.InputModels
{
    public class PersonInputModel
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int TeamId { get; set; }
    }
}
