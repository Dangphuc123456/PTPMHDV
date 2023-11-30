using DataModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Helper;

namespace DataAccessLayer
{
    public class HoaDonNhapRepository : IHoaDonNhapRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonNhapRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public HoaDonNhapModel GetDatabyID(string MaHDNhap)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadonnhap_get_by_id",
                     "@MaHDNhap", MaHDNhap);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonnhap_create",
                "@MaNhanVien", model.MaNhanVien,
                "@NhaCCID", model.NhaCCID,
                "@NgayNhap", model.NgayNhap,
                "@TongTien", model.TongTien,
                "@list_json_chitiethoadonnhap", model.list_json_chitiethoadonnhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonnhap) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonnhap_update",
                "@MaNhanVien", model.MaNhanVien,
                "@NhaCCID", model.NhaCCID,
                "@NgayNhap", model.NgayNhap,
                "@TongTien", model.TongTien,
                "@list_json_chitiethoadonnhap", model.list_json_chitiethoadonnhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonnhap) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_hoadonnhap",
                "@MaHDNhap", model.MaHDNhap);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


