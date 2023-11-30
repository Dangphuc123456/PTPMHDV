using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface IHoaDonBanRepository
    {
        HoaDonBanModel GetDatabyID(string MaHDBan);
        bool Create(HoaDonBanModel model);
        bool Update(HoaDonBanModel model);
        bool Delete(HoaDonBanModel model);
       
    }
}
