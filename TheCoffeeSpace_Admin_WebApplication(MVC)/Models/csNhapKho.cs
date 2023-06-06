namespace TheCoffeeSpace_Admin_WebApplication_MVC_.Models
{
    public class csNhapKho
    {
        public int SoLuongNhap { get; set; }

        public int GiaNhap { get; set; }

        public string MaHoaDonNhap { get; set; } = null!;

        public string MaVatTu { get; set; } = null!;

        public DateTime NgayLap { get; set; }
    }
}
