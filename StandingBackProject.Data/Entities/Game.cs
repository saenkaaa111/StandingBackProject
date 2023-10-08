﻿namespace StandingBackProject.Data.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set;}
        public virtual ICollection<ResultTournamentPlayer> ResultTournamentPlayers { get; set; }
        public virtual ICollection<ResultTournamentTeam> ResultTournamentTeams { get; set; }

    }
}
