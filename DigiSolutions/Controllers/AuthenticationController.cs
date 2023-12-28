using DigiSolutions.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiSolutions.Controllers
{
    public class AuthenticationController : Controller
    {
		DigiSolutionsContext db;
        public AuthenticationController(DigiSolutionsContext context)
        {
			db = context;

		}

		public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string user , string pass)
        {
			User data = db.Users.Where((u) => u.Email == user && u.Password == pass).FirstOrDefault();
            if (data == null)
            {
                ViewBag.response = "User Credentials not Matched!";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
		public IActionResult Signup()
		{
			return View();
		}

	}
}
