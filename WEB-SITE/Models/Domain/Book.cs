using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WEB_SITE.Models.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ten Sach ")]
        public string Name { get; set; }

        public string Nxb { get; set; }

        public string Specialized { get; set; }

        public string Image { get; set; }

        public DateTime DayCreate { get; set; }

        public DateTime DayUpdate { get; set; }

    }
}
