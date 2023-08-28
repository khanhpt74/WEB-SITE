using Microsoft.AspNetCore.Mvc;
using WEB_SITE.data;
using WEB_SITE.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WEB_SITE.Controllers
{
	public class UsersController : Controller
	{
        private ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
		{
			return View();
		}

        public IActionResult Login()
        {
            //if (HttpContext.Session.GetString("UserSession") != null)
            //{
                //return RedirectToAction("Dashboard");
            //}
            return View();
        }

        [HttpPost]
        
        public IActionResult Login(Users user)
        {
            var myUser = context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (myUser == null) 
            {
                HttpContext.Session.SetString("UserSession","myUser");
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed ..";
            }
            return View();
        }
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = (HttpContext.Session.GetString("UserSession") == null);
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            if(ModelState.IsValid) 
            { 
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Success"] = "Tạo Tài Khoản Thanh Công";
                return RedirectToAction("login");
            }
            return View();
        }
    }
}
