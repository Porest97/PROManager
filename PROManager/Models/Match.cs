using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROManager.Models
{
    public class Match
    {
        public int Id { get; set; }

        public DateTime MatchDateTime { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public int? ScoreHomeTeam { get; set; }

        public int? AwayHomeTeam { get; set; }

        public Referee Ref1 { get; set; }

        public Referee Ref2 { get; set; }

        public Referee Ref3 { get; set; }

        public Referee Ref4 { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

    }
    public class Referee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Namn")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }


    }


}
