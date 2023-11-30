using DataModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IHoaDonNhapBusiness
    {
        HoaDonNhapModel GetDatabyID(string MaHDNhap);
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        bool Delete(HoaDonNhapModel model);
    }
}
