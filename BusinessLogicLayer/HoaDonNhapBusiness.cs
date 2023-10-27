using DataModel;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer.Interfaces;
using System.Reflection;

namespace BusinessLogicLayer
{
    public class HoaDonNhapBusiness :IHoaDonNhapBusiness
    {
        private IHoaDonNhapRepository _res;
        public HoaDonNhapBusiness(IHoaDonNhapRepository res)
        {
            _res = res;
        }
        public HoaDonNhapModel GetDatabyID(string MaHDNhap)
        {
            return _res.GetDatabyID(MaHDNhap);
        }
        public bool Create(HoaDonNhapModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoaDonNhapModel model)
        {
            return _res.Update(model);
        }
        public List<ThongkeNguyenlieuModel> Search(int pageIndex, int pageSize, out long total, string NhaCCID, DateTime? fr_NgayNhap, DateTime? to_NgayNhap)
        {
            return _res.Search(pageIndex, pageSize, out total, NhaCCID, fr_NgayNhap, to_NgayNhap);
        }
    }
}
