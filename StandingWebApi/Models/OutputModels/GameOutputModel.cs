using StandingBackProject.Business.Model;

namespace StandingBackProject.API.Models.OutputModels
{
    public class GameOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        
    }
}
