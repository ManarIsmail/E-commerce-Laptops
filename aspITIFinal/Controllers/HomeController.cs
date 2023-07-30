using aspITIFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspITIFinal.Controllers
{
    public class HomeController : Controller
    {
        LaptopContext db=new LaptopContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cats = db.Categories.ToList();
            ViewBag.products = db.Products.ToList().GetRange(1, 9);
            return View(cats);

        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult catproduct(int id)
        {
            var products = db.Products.Where(x => x.IdCat == id).ToList();
            return View(products);
        }
        public IActionResult ProductDetails(int id)
        {
            ViewBag.product = db.Products.Find(id);
            var pro = db.ProductImages.Where(x => x.IdProduct == id).ToList();
            return View(pro);
           
        }
        public IActionResult Products()
        {
            ViewBag.cats = db.Categories.ToList();
            var products = db.Products.ToList();
            return View(products);
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult saveMessage(Contact model)
        {
            db.Contacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult searchproduct(string nameproduct)
        {
            var products = db.Products.Where(x => x.Brand.Contains(nameproduct)).ToList();
            return View("catproduct", products);
        }
        public IActionResult savesubscribe(Subscribe model)
        {
            db.Subscribes.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult cart(int id)
        {
            ViewBag.product = db.Products.Find(id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}