using StandingBackProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingBackProject.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public Role Role { get; set; }
        public bool isDeleted { get; set; }
        public virtual Team Team   { get; set; }
        public virtual ICollection<ResultTournamentPlayer> ResultTournamentPlayers { get; set; }
        public virtual ICollection<PlayerTournamentsHistory> PlayerTournamentsHistories { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }

    }
}
