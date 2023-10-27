using System;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataModel;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer
{
    public class HoaDonBanBusiness :IHoaDonBanBusiness
    {
        private IHoaDonBanRepository _res;
        public HoaDonBanBusiness(IHoaDonBanRepository res)
        {
            _res = res;
        }
        public HoaDonBanModel GetDatabyID(string MaHDBan)
        {
            return _res.GetDatabyID(MaHDBan);
        }
        public bool Create(HoaDonBanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoaDonBanModel model)
        {
            return _res.Update(model);
        }
        public List<ThongkeKhachModel> Search(int pageIndex, int pageSize, out long total, string TenKhach, DateTime? fr_NgayBan, DateTime? to_NgayBan)
        {
            return _res.Search(pageIndex, pageSize, out total, TenKhach, fr_NgayBan, to_NgayBan);
        }
    }
}

