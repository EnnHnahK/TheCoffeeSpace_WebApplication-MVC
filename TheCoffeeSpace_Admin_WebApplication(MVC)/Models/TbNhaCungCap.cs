using System;
using System.Collections.Generic;

namespace TheCoffeeSpace_Admin_WebApplication_MVC_.Models;

public partial class TbNhaCungCap
{
    public string MaNhaCungCap { get; set; } = null!;

    public string TenNhaCungCap { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<TbHoaDonNhap> TbHoaDonNhaps { get; set; } = new List<TbHoaDonNhap>();
}
