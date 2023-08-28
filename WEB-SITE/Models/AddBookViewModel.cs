namespace WEB_SITE.Models
{
	public class AddBookViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string Nxb { get; set; }

		public string Specialized { get; set; }

		public string Image { get; set; }

		public DateTime DayCreate { get; set; }

		public DateTime DayUpdate { get; set; }
	}
}
