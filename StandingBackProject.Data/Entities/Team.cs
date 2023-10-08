using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingBackProject.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public virtual ICollection<Person> Persons  { get; set; }
        public virtual ICollection<ResultTournamentTeam> ResultTournamentTeams { get; set; }
        public virtual ICollection<TeamTournamentsHistory> TeamTournamentsHistories { get; set; }

    }
}
