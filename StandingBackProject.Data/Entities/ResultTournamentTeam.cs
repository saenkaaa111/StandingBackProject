﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingBackProject.Data.Entities
{
    public class ResultTournamentTeam
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public int NumberRounde { get; set; }
        public int NumberGame { get; set; }
        public virtual Team Team { get; set; }

        public virtual Tournament Tournament { get; set; }
        public virtual Game Game { get; set; }


    }
}