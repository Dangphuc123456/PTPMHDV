using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface INhanVienRepository
    {
        NhanVienModel GetDatabyID(string MaNhanVien);
        bool Create(NhanVienModel model);
        bool Update(NhanVienModel model);
        public List<NhanVienModel> Search(int pageIndex, int pageSize, out long total, string TenNhanVien, string DiaChi);
    }
}
