using System.ComponentModel.DataAnnotations;

namespace PROManager.Models
{
    public class RefereeType
    {
        public int Id { get; set; }

        [Display(Name = "Domar Typ")]
        public string RefereeTypeName { get; set; }
    }
}