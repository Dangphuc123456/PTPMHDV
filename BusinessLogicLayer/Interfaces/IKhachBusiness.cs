using DataModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IKhachBusiness
    {
        KhachHangModel GetDatabyID(string MaKhach);
        bool Create(KhachHangModel model);
        bool Update(KhachHangModel model);
        bool Delete(KhachHangModel model);
      
    }
}
