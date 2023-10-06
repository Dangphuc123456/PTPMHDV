using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IKhachBusiness
    {
        KhachHangModel GetDatabyID(string MaKhach);
        bool Create(KhachHangModel model);
        bool Update(KhachHangModel model);
        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi);
    }
}
