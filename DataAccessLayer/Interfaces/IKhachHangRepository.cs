using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface IKhachRepository
    {
        KhachHangModel GetDatabyID(string MaKhach);
        bool Create(KhachHangModel model);
        bool Update(KhachHangModel model);
        bool Delete(KhachHangModel model);
    }
}
