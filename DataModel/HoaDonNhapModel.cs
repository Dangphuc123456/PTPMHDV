namespace DataModel
{
    public class HoaDonNhapModel
    {
        public string MaHDNhap { get; set; }
        public string MaNhanVien { get; set; }
        public string NhaCCID { get; set; }
        public DateTime NgayNhap { get; set; }
        public float TongTien { get; set; }
        public List<ChiTietHoaDonNhapModel> list_json_chitiethoadonnhap { get; set; }
    }

    public class ChiTietHoaDonNhapModel
    {
        public string MaCTNhap { get; set; }
        public string MaHDNhap { get; set; }
        public string MaNguyenlieu { get; set; }
        public int SoLuong { get; set; }
        public float GiamGia { get; set; }
        public float ThanhTien { get; set; }
    }
}

