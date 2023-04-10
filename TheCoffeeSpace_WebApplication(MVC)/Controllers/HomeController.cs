using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TheCoffeeSpace_WebApplication_MVC_.Models;
using X.PagedList;

namespace TheCoffeeSpace_WebApplication_MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        DataTheSpaceCoffeeContext db = new DataTheSpaceCoffeeContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Menu(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listItem = db.TbSanPhams.AsNoTracking().OrderBy(x => x.MaSanPham).ToList();
            PagedList<TbSanPham> pagedListItem = new PagedList<TbSanPham>(listItem, pageNumber, pageSize);
            return View(pagedListItem);
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

<<<<<<<<< Temporary merge branch 1
=========


>>>>>>>>> Temporary merge branch 2
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}