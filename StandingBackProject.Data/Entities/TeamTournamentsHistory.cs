using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingBackProject.Data.Entities
{
    public class TeamTournamentsHistory
    {
        public int Id { get; set; }
        public virtual Team Team { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
