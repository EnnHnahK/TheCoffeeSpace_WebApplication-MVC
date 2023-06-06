using System;
using System.Collections.Generic;

namespace TheCoffeeSpace_Admin_WebApplication_MVC_.Models;

public partial class TbSanPham
{
    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public decimal? GiaBan { get; set; }

    public string? HinhAnh { get; set; }

    public string? GhiChu { get; set; }

    public string MaNhomSp { get; set; } = null!;

    public string? Mota { get; set; }

    public int? Calories { get; set; }

    public int? TotalFat { get; set; }

    public int? SaturatedFat { get; set; }

    public int? Cholesterol { get; set; }

    public int? Sodium { get; set; }

    public int? TotalCarbohydrates { get; set; }

    public int? Sugars { get; set; }

    public int? Protein { get; set; }

    public string? Ingredients { get; set; }

    public int? Vote { get; set; }

    public float? Star { get; set; }

    public virtual TbNhomSanPham MaNhomSpNavigation { get; set; } = null!;

    public virtual ICollection<TbChiTietHdb> TbChiTietHdbs { get; set; } = new List<TbChiTietHdb>();

    public virtual ICollection<TbCuaHang> MaCuaHangs { get; set; } = new List<TbCuaHang>();
}
