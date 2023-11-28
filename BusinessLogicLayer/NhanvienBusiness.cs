using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;

namespace BusinessLogicLayer
{
    public class NhanvienBusiness:INhanVienBusiness
    {

        private INhanVienRepository _res;
        public NhanvienBusiness(INhanVienRepository res)
        {
            _res = res;
        }
        public NhanVienModel GetDatabyID(string MaNhanVien)
        {
            return _res.GetDatabyID(MaNhanVien);
        }
        public bool Create(NhanVienModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhanVienModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(NhanVienModel model)
        {
            return _res.Delete(model);
        }
        
    }
}
