using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROManager.Models
{
    public class AFAktivity
    {
        public int Id { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        [Display(Name = "Aktivitet")]
        public AFAktivityType FAktivityType { get; set; }
        [Display(Name = "Aktivitet")]
        public int? AFAktivityTypeId { get; set; }

        [Display(Name = "Person")]
        public Person Person { get; set; }
        [Display(Name = "Person")]
        public int PersonId { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }


    }
}
