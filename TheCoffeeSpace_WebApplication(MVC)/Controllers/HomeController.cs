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
            var list = db.TbSanPhams.AsNoTracking().OrderBy(x => x.MaSanPham).Take(6).ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Menu(int? page, string target)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            if (target == "all")    



            {
                var listItem = db.TbSanPhams.AsNoTracking().OrderBy(x => x.MaSanPham).ToList();
                PagedList<TbSanPham> pagedListItem = new PagedList<TbSanPham>(listItem, pageNumber, pageSize);
                ViewBag.target = target;
                return View(pagedListItem);
            }
            else { 
                var listItem = db.TbSanPhams.AsNoTracking().Where(x => x.MaNhomSp == target).OrderBy(x => x.MaSanPham).ToList();
                PagedList<TbSanPham> pagedListItem = new PagedList<TbSanPham>(listItem, pageNumber, pageSize);
                ViewBag.target = target;
                return View(pagedListItem);
            }
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
        // [HttpPost]
        //[Route("Vote/{MaSanPham}/{Star}")]
        public IActionResult Vote(string MaSanPham, int? star)
        {

            var sp = db.TbSanPhams.Where(x => x.MaSanPham == MaSanPham).ToList().First();
            var starCu = sp.Star;
            var soNguoiCu = sp.Vote;
            float? starMoi = ((starCu * soNguoiCu) + (float) (star == null || star < 0 ? 1 : star.Value)) / (soNguoiCu + (float) 1);
            sp.Star = starMoi;
            sp.Vote = soNguoiCu + 1;
            db.TbSanPhams.Update(sp);
            db.SaveChanges();
            return RedirectToAction("Menu");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}