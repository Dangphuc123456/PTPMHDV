using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ThongkeNguyenlieuModel
    {
        public string MaNguyenlieu { get; set; }
        public string TenNguyenlieu { get; set; }
        public int SoLuong { get; set; }
        public float TongTien { get; set; }
        public string NhaCCID { get; set; }
        public DateTime NgayNhap { get; set; }
    }
}
