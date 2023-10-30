using StandingBackProject.Data.Enums;

namespace StandingBackProject.Business.Model
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public Role Role { get; set; }
        public bool isDeleted { get; set; }
        public List<ResultTournamentPlayerModel> ResultTournamentPlayers { get; set; }
        public List<TournamentModel> Tournaments { get; set; }

        public bool Equals(PersonModel other)
        {
            return other is PersonModel model &&
                   Name == model.Name &&
                   Nickname == model.Nickname &&
                   Role == model.Role &&
                   isDeleted == model.isDeleted;
                   
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((PersonModel)obj);
        }        
    }
}

