using DataModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IHoaDonNhapBusiness
    {
        HoaDonNhapModel GetDatabyID(string MaHDNhap);
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        public List<ThongkeNguyenlieuModel> Search(int pageIndex, int pageSize, out long total, string NhaCCID, DateTime? fr_NgayNhap, DateTime? to_NgayNhap);
    }
}
