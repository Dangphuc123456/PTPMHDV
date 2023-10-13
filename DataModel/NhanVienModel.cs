using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class NhanVienModel
	{

		public string MaNhanVien {get;set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh {get;set; }
        public string DiaChi {get;set; }
        public string DienThoai {get; set; }
        public DateTime NgaySinh { get; set; }
    }
}
