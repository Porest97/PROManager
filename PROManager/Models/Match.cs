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

        [Display(Name = "Datum & Tid")]
        public DateTime MatchDateTime { get; set; }

        [Display(Name = "Arena")]
        public Arena Arena { get; set; }
        public int? ArenaId { get; set; }

        [Display(Name = "Hemma")]
        public HomeTeam HomeTeam { get; set; }
        public int? HomeTeamId { get; set; }
        [Display(Name = "Borta")]
        public AwayTeam AwayTeam { get; set; }
        public int? AwayTeamId { get; set; }
        public int? ScoreHomeTeam { get; set; }

        [Display(Name = "Resultat")]
        public string Result { get { return string.Format("{0} {1} {2}", ScoreHomeTeam, "-", ScoreAwayTeam); } }

        public int? ScoreAwayTeam { get; set; }

        [Display(Name = "HD")]
        public Referee Referee { get; set; }
        public int? RefereeId { get; set; }

        [Display(Name = "HD")]
        public Referee1 Referee1 { get; set; }
        public int? Referee1Id { get; set; }

        [Display(Name = "LD")]
        public Referee1 Referee2 { get; set; }
        public int? Referee2Id { get; set; }

        [Display(Name = "LD")]
        public Referee1 Referee3 { get; set; }
        public int? Referee3Id { get; set; }

        [Display(Name = "Serie")]
        public Series Series { get; set; }
        public int? SeriesId { get; set; }


    }
}
