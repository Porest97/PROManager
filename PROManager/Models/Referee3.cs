﻿using System.ComponentModel.DataAnnotations;

namespace PROManager.Models
{
    public class Referee3
    {
        public int Id { get; set; }
        [Display(Name = "Namn")]
        public Person Person { get; set; }
        public int? PersonId { get; set; }


        


    }


}
