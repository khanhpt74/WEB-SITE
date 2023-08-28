using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_SITE.Models.Domain
{
    public class Users
    {
        
        [Key]
        public int Id { get; set; }
        
        public string? FirtsName { set; get; }
        
        [Required]
        public string? LastName { set; get; }

        
        [Required]
        public string? Email { set; get; }

        
        [DataType(DataType.Password)]
        [Required]
        public string? Password { set; get; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime? DateCreate { set; get; }
    }
}
