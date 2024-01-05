using DigiSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DigiSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        DigiSolutionsContext db;
        public HomeController(DigiSolutionsContext context)
        {
            db = context;

        }

      

        public IActionResult Index()
        {
            ViewBag.data = HttpContext.Session.GetString("User");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
		public IActionResult Dashboard()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult ViewProducts()
        {
            var products=db.Products.ToList();
            return View(products);
        }
        public ActionResult ProductDetail(int? id)
        {
            var product = db.Products.Find(id);
            
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int? cartcount, int? id,double? price)
        {
            var userid = int.Parse(HttpContext.Session.GetString("UserId"));
          

            db.Add(new Cart
            {
                ProductId = id,
                Quantity = cartcount,
                TotalPrice = (price * cartcount),
                UserId = userid,


            });
            await db.SaveChangesAsync();

            return RedirectToAction("ProductDetail", new { id = id });
        }
        
    }
}