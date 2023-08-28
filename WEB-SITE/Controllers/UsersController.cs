using Microsoft.AspNetCore.Mvc;

namespace WEB_SITE.Controllers
{
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
