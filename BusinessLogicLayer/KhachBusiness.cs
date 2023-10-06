using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;

namespace BusinessLogicLayer
{
    public class KhachBusiness : IKhachBusiness
    {
        private IKhachRepository _res;
        public KhachBusiness(IKhachRepository res)
        {
            _res = res;
        }
        public KhachHangModel GetDatabyID(string MaKhach)
        {
            return _res.GetDatabyID(MaKhach);
        }
        public bool Create(KhachHangModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhachHangModel model)
        {
            return _res.Update(model);
        }
        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_khach, dia_chi);
        }
    }
}