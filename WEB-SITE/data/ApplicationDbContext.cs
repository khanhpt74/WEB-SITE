using Microsoft.EntityFrameworkCore;
using WEB_SITE.Models.Domain;

namespace WEB_SITE.data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
		{
		}
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Users> Users { get; set; }

		public DbSet<Book> Book { get; set; }
	}
}
