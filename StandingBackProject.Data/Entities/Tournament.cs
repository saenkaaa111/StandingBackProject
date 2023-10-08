using StandingBackProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingBackProject.Data.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public virtual Club Club { get; set; }
        public virtual Person Judge { get; set; } //судья
        public virtual Game Game { get; set; }
        public virtual ICollection<ResultTournamentPlayer> ResultTournamentPlayers { get; set; }
        public virtual ICollection<ResultTournamentTeam> ResultTournamentTeams { get; set; }
        public virtual ICollection<PlayerTournamentsHistory> PlayerTournamentsHistories { get; set; }
        public virtual ICollection<TeamTournamentsHistory> TeamTournamentsHistories { get; set; }

    }
}
