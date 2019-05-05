using System.ComponentModel.DataAnnotations;

namespace PROManager.Models
{
    public class AFAktivityType
    {
        public int Id { get; set; }

        [Display(Name ="Aktivitet")]
        public string AFAktivityTypeName { get; set; }
    }
}