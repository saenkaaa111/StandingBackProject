using StandingBackProject.Data.Entities;
using StandingBackProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingBackProject.Business.Model
{
    public class TournamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public ClubModel Club { get; set; }
        public PersonModel? Judge { get; set; } //судья
        public GameModel Game { get; set; }
        public List<ResultTournamentPlayerModel> ResultTournamentPlayers { get; set; }        
    }
}
