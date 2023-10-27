using DataModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IHoaDonBanBusiness
    {
        HoaDonBanModel GetDatabyID(string MaHDBan);
        bool Create(HoaDonBanModel model);
        bool Update(HoaDonBanModel model);
        public List<ThongkeKhachModel> Search(int pageIndex, int pageSize, out long total, string TenKhach, DateTime? fr_NgayBan, DateTime? to_NgayBan);
    }
}
