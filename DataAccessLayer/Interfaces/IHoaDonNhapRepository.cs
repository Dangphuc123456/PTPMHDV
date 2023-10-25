using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer.Interfaces
{
    public partial interface  IHoaDonNhapRepository
    {
        HoaDonNhapModel GetDatabyID(string MaHDNhap);
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        public List<ThongkeNhaCungCapModel> Search(int pageIndex, int pageSize, out long total, string NhaCCID, DateTime? fr_NgayNhap, DateTime? to_NgayNhap);
    }
}
