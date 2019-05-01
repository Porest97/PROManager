using System.ComponentModel.DataAnnotations;

namespace PROManager.Models
{
    public class RefereeDistrikt
    {
        public int Id { get; set; }

        [Display(Name = "Domar Distrikt")]
        public string RefereeDistriktName { get; set; }
    }
}