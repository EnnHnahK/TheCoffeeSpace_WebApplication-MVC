using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TheCoffeeSpace_Admin_WebApplication_MVC_.Models;
using TheSpaceCofffeeAdmin.Models.Authetication;
using X.PagedList;

namespace TheSpaceCofffeeAdmin.Controllers
{
    public class HomeController : Controller
    {
        DataTheSpaceCoffeeContext db = new DataTheSpaceCoffeeContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authentication]

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Dashbroad(int? page)
        {
           
            return View();
        }

        //- Store -//
        public IActionResult StoreHouse(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;
            var lstStoreHouse = db.TbKhoVatTuChes.OrderBy(x => x.MaCuaHang);
            PagedList<TbKhoVatTuCh> lst = new PagedList<TbKhoVatTuCh>(lstStoreHouse, pageNumber, pageSize);
            return View(lst);
        }

        public ActionResult FindStoreHouse(string searchNameStoreHouse, int? page )
        {
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;
            var store = db.TbKhoVatTuChes.Where(t => t.MaCuaHang.Contains(searchNameStoreHouse)).ToList();
            PagedList<TbKhoVatTuCh> lst = new PagedList<TbKhoVatTuCh>(store, pageNumber, pageSize);
            ViewBag.SearchName = searchNameStoreHouse;
            return View(lst);
        }
        
        public IActionResult Store(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;
            var lstStore = db.TbCuaHangs.OrderBy(x => x.MaCuaHang);
            PagedList<TbCuaHang> lst = new PagedList<TbCuaHang>(lstStore, pageNumber, pageSize);
            return View(lst);
        }


        public ActionResult FindStore(string searchNameStore)
        {
            var store = db.TbCuaHangs.Where(t => t.TenCuaHang.Contains(searchNameStore)).ToList();
            return View(store);
        }

        [HttpGet]
        public IActionResult AddStore() { 
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStore(TbCuaHang cuaHang)
        {
            if(ModelState.IsValid)
            {
                db.TbCuaHangs.Add(cuaHang);
                db.SaveChanges();
                return RedirectToAction("Store");
            }
            return View(cuaHang);
        }

        [HttpGet]
        public IActionResult EditStore(string IDCuaHang)
        {
            
            var stores = db.TbCuaHangs.Find(IDCuaHang);
            return View(stores);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStore(TbCuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                db.Update(cuaHang);
                db.SaveChanges();
                return RedirectToAction("Store");
            }
            return View(cuaHang);
        }

        //- Product -//
        public IActionResult ListProducts(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;
            var lstProducts = db.TbSanPhams.OrderBy(x => x.GiaBan);
            PagedList<TbSanPham> lst = new PagedList<TbSanPham>(lstProducts, pageNumber, pageSize);
            return View(lst);
        }

        public ActionResult FindProductByName(string searchNameProduct)
        {
            var product = db.TbSanPhams.Where(t => t.TenSanPham.Contains(searchNameProduct)).ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.MaNhomSP = new SelectList(db.TbNhomSanPhams.ToList(),"MaNhomSp","TenNhomSp");
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(TbSanPham sp)
        {

           if (ModelState.IsValid)
           {
                if(sp.HinhAnh != null && Path.GetExtension(sp.HinhAnh) == ".jpg")
                {
                    db.TbSanPhams.Add(sp);
                    db.SaveChanges();
                    return RedirectToAction("ListProducts");

                }
                else if(sp.HinhAnh != null) {
                    ModelState.AddModelError(nameof(TbSanPham.HinhAnh), "Hình ảnh cần có định dạng .jpg.");
                    ;


                }
                else
                {
                    db.TbSanPhams.Add(sp);
                    db.SaveChanges();

                    return RedirectToAction("ListProducts");
                }               
           }

            return View(sp);
        }

        
        [HttpGet]
        public IActionResult EditProduct(string IDSp)
        {
            ViewBag.MaNhomSanPham = new SelectList(db.TbNhomSanPhams.ToList(),"MaNhomSp","TenNhomSp");
            var product = db.TbSanPhams.Find( IDSp);
            return View(product);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(TbSanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.TbSanPhams.Update(sp); 
                db.SaveChanges();
                return RedirectToAction("ListProduct");
            }
            return View(sp);
        }


        //- Topping -//
        public IActionResult Topping(int? page)
        {
            int pageSize = 3;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;
            var lstTopping = db.TbToppings.OrderBy(x => x.MaTopping);
            PagedList<TbTopping> lst = new PagedList<TbTopping>(lstTopping, pageNumber, pageSize);
            return View(lst);
        }

        public ActionResult FindToppingByName(string searchNameTopping)
        {
            var topp= db.TbToppings.Where(t => t.TenTopping.Contains(searchNameTopping)).ToList();
            return View(topp);
        }

        [HttpGet]
        public IActionResult AddTopping()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTopping(TbTopping topping)
        {
            if (ModelState.IsValid)
            {
                db.TbToppings.Add(topping);
                db.SaveChanges();
                return RedirectToAction("Topping");
            }
            return View(topping);
        }

        [HttpGet]
        public IActionResult EditTopping(string IDTopping)
        {
            var topping = db.TbToppings.Find(IDTopping);
            return View(topping);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTopping(TbTopping topping)
        {
            if (ModelState.IsValid)
            {
                db.Update(topping);
                db.SaveChanges();
                return RedirectToAction("Topping");
            }
            return View(topping);
        }

        [Route("DeleteToping")]
        [HttpGet]
        public IActionResult DeleteTopping(string IDTopping)
        {
            TempData["Message"] = "";
            var chiTietToppings = db.TbChiTietToppingHdbs.Where(x => x.MaTopping == IDTopping).ToList();
            if (chiTietToppings.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này !!!";
                return RedirectToAction("Topping");
            }
            db.Remove(db.TbToppings.Find(IDTopping));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("Topping");
        }

        //- PayAmount -//
        public IActionResult PayAmount(int? page)
        {
            List<csHoadonnhap> HoaDonNhap = new List<csHoadonnhap>();

            using (var db = new DataTheSpaceCoffeeContext())
            {
                var query = from cthn in db.TbChiTietHdns
                            join hdn in db.TbHoaDonNhaps on cthn.MaHoaDonNhap equals hdn.MaHoaDonNhap
                            select new csHoadonnhap{
                                MaHoaDonNhap = cthn.MaHoaDonNhap,
                                MaVatTu = cthn.MaVatTu,
                                NgayLap = hdn.NgayLap,
                                SoLuongNhap = cthn.SoLuongNhap,
                                GiaNhap = cthn.GiaNhap,
                                MaNhaCungCap = hdn.MaNhaCungCap,
                                TongTien = cthn.GiaNhap * cthn.SoLuongNhap,
                            };

                HoaDonNhap = query.OrderBy(x => x.MaHoaDonNhap).ToList();
            }
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;

            var pageHoaDonNhap = HoaDonNhap.ToPagedList(pageNumber, pageSize);
            return View(pageHoaDonNhap);
        }

        public ActionResult FindPayAmount(DateTime searchDate, int ?page)
        {
            List<csHoadonnhap> HoaDonNhap = new List<csHoadonnhap>();

            using (var db = new DataTheSpaceCoffeeContext())
            {
                var query = from cthn in db.TbChiTietHdns
                            join hdn in db.TbHoaDonNhaps on cthn.MaHoaDonNhap equals hdn.MaHoaDonNhap
                            select new csHoadonnhap{
                                MaHoaDonNhap = cthn.MaHoaDonNhap,
                                MaVatTu = cthn.MaVatTu,
                                NgayLap = hdn.NgayLap,
                                SoLuongNhap = cthn.SoLuongNhap,
                                GiaNhap = cthn.GiaNhap,
                                MaNhaCungCap = hdn.MaNhaCungCap,
                                TongTien = cthn.GiaNhap * cthn.SoLuongNhap,
                            };

                HoaDonNhap = query.Where(x => x.NgayLap ==  searchDate).OrderBy(x => x.MaHoaDonNhap).ToList();
            }
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;

            var pageHoaDonNhap = HoaDonNhap.ToPagedList(pageNumber, pageSize);
            ViewBag.SearchName = searchDate;
            return View(pageHoaDonNhap);

        }

        //- Payment -//
        public IActionResult Payment(int? page)
        {
            List<csHoaDonBan> HoaDonBan = new List<csHoaDonBan>();
            List<Dictionary<string, decimal>> TongTien = new List<Dictionary<string, decimal>>();

            using (var db = new DataTheSpaceCoffeeContext())
            {

                var query2 = from cthb in db.TbChiTietHdbs
                             join hdb in db.TbHoaDonBans on cthb.MaHoaDonBan equals hdb.MaHoaDonBan
                             join sp in db.TbSanPhams on cthb.MaSanPham equals sp.MaSanPham
                             select new csHoaDonBan
                             {
                                 MaHoaDonBan = hdb.MaHoaDonBan,
                                 MaKhachHang = hdb.MaKhachHang,
                                 NgayBan = hdb.NgayBan,
                             };

                HoaDonBan = query2.OrderBy(x => x.MaHoaDonBan).ToList();
            }
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;

            PagedList<csHoaDonBan> v = new PagedList<csHoaDonBan>(HoaDonBan, pageNumber, pageSize);
            return View(v);
        }

        //themroute
        [HttpGet]
        [Route("Home/ViewPayment/{Id}")]
        public IActionResult ViewPayment(string? Id)
        {
            List<csHoaDonBan> HoaDonBan = new List<csHoaDonBan>();

            using (var db = new DataTheSpaceCoffeeContext())
            {
                var query = from cthdb in db.TbChiTietHdbs
                            join hdb in db.TbHoaDonBans on cthdb.MaHoaDonBan equals hdb.MaHoaDonBan
                            join sp in db.TbSanPhams on cthdb.MaSanPham equals sp.MaSanPham
                            where cthdb.MaHoaDonBan == Id
                            select new csHoaDonBan{
                                MaHoaDonBan = cthdb.MaHoaDonBan,
                                MaKhachHang = hdb.MaKhachHang,
                                NgayBan = hdb.NgayBan,
                                TenSanPham = sp.TenSanPham,
                                SoLuong = cthdb.SoLuong,
                                GiaBan = (int)sp.GiaBan,
                                GiamGia = cthdb.GiamGia,
                                TongTien = (int)(sp.GiaBan * cthdb.SoLuong - (int)((decimal)(cthdb.GiamGia * sp.GiaBan) / 100))
                            };
                HoaDonBan = query.ToList();
            }
            return View(HoaDonBan);
        }

        public ActionResult FindPayment(DateTime searchDate, int? page)
        {
            List<csHoaDonBan> HoaDonBan = new List<csHoaDonBan>();

            using (var db = new DataTheSpaceCoffeeContext())
            {
                var query = from cthb in db.TbChiTietHdbs
                            join hdb in db.TbHoaDonBans on cthb.MaHoaDonBan equals hdb.MaHoaDonBan
                            join sp in db.TbSanPhams on cthb.MaSanPham equals sp.MaSanPham
                            select new csHoaDonBan{
                                MaHoaDonBan = hdb.MaHoaDonBan,
                                MaKhachHang = hdb.MaKhachHang,
                                TenSanPham = sp.TenSanPham,
                                NgayBan = hdb.NgayBan,
                                MaKichThuoc = cthb.MaKichThuoc,
                                SoLuong = cthb.SoLuong,
                                GiaBan = (int)sp.GiaBan,
                            };
                HoaDonBan = query.Where(x=>x.NgayBan==searchDate).OrderBy(x => x.MaHoaDonBan).ToList();
                Console.WriteLine(HoaDonBan[0].MaHoaDonBan);
            }
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;

            PagedList<csHoaDonBan> v = new PagedList<csHoaDonBan>(HoaDonBan, pageNumber, pageSize);
            return View(v);
        }

        public IActionResult ListItem(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;
            var lstFindStore = db.TbVatTus.OrderBy(x => x.MaVatTu);
            PagedList<TbVatTu> lstfind = new PagedList<TbVatTu>(lstFindStore, pageNumber, pageSize);
            return View(lstfind);
        }

        [HttpGet]
        public IActionResult AddListItem()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddListItem(TbVatTu vt) { 
            if (ModelState.IsValid)
            {
                db.TbVatTus.Add(vt);
                db.SaveChanges();
                return RedirectToAction("ListItem");
            }
            return View(vt);
        }

        public ActionResult FindListItem(string searchNameListItem, int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;
            var lst = db.TbVatTus.Where(t => t.TenVatTu.Contains(searchNameListItem)).ToList();
            PagedList<TbVatTu> lstItem = new PagedList<TbVatTu>(lst, pageNumber, pageSize);
            ViewBag.SearchName = searchNameListItem;
            return View(lstItem);
        }
 
        public IActionResult ListAddItem(int? page)
        {
            List<csNhapKho> nhapKho = new List<csNhapKho>();

            using (var db = new DataTheSpaceCoffeeContext())
            {
                var query = from cthn in db.TbChiTietHdns
                            join hdn in db.TbHoaDonNhaps on cthn.MaHoaDonNhap equals hdn.MaHoaDonNhap
                            select new csNhapKho{
                                MaHoaDonNhap = cthn.MaHoaDonNhap,
                                SoLuongNhap = cthn.SoLuongNhap,
                                MaVatTu = cthn.MaVatTu,
                                NgayLap = hdn.NgayLap,
                            };

                nhapKho = query.OrderBy(x => x.MaHoaDonNhap).ToList();
            }
            int pageSize = 6;
            int pageNumber = page == null | page < 0 ? 1 : page.Value;
            
            var pageNhapKho = nhapKho.ToPagedList(pageNumber, pageSize);
            return View(pageNhapKho);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}