using System.ComponentModel.DataAnnotations;

namespace PROManager.Models
{
    public class Arena
    {
        public int Id { get; set; }

        [Display(Name = "Arena")]
        public string ArenaName { get; set; }
    }
}