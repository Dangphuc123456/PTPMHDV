namespace DataModel
{
    public class HoaDonBanModel
    {
        public int MaHDBan { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaKhach { get; set; }
        public float TongTien{ get; set; }
        public List<ChiTietHoaDonbanModel> list_json_chitiethoadonban { get; set; }
    }
    public class ChiTietHoaDonbanModel 
    { 
        public int MaCTBan{ get; set; }
        public int MaHDBan { get; set; }
        public string Mamonan { get; set; }
         public int  SoLuong { get; set; }
        public float GiamGia{ get; set; }
        public float ThanhTien{ get; set; }
    }
}
