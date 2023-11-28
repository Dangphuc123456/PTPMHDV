using DataModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IHoaDonBanBusiness
    {
        HoaDonBanModel GetDatabyID(string MaHDBan);
        bool Create(HoaDonBanModel model);
        bool Update(HoaDonBanModel model);
    }
}
