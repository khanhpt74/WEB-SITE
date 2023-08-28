using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_SITE.Models.Domain
{
    public class Users
    {
        [MaxLength(100)]
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirtsName { set; get; }
        [MaxLength(100)]
        public string LastName { set; get; }

        [MaxLength(255)]
        public string Email { set; get; }

        [MaxLength(255)]
        public string Password { set; get; }

        [DataType(DataType.Date)]
        public DateTime? DateCreate { set; get; }
    }
}
