using System;
using System.Collections.Generic;

namespace TheCoffeeSpace_Admin_WebApplication_MVC_.Models;

public partial class TbCuaHang
{
    public string MaCuaHang { get; set; } = null!;

    public string TenCuaHang { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string? Email { get; set; }

    public string? Fanpage { get; set; }

    public virtual ICollection<TbKhoVatTuCh> TbKhoVatTuChes { get; set; } = new List<TbKhoVatTuCh>();

    public virtual ICollection<TbSanPham> MaSanPhams { get; set; } = new List<TbSanPham>();

    public virtual ICollection<TbTinTuc> MaTinTucs { get; set; } = new List<TbTinTuc>();
}
