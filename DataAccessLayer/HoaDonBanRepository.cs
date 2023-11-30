using DataModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Helper;
using System;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class HoaDonBanRepository:IHoaDonBanRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonBanRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public HoaDonBanModel GetDatabyID(string MaHDBan)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadonban_get_by_id",
                     "@MaHDBan", MaHDBan);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonBanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(HoaDonBanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonban_create",
                "@MaNhanVien", model.MaNhanVien,
                "@MaKhach", model.MaKhach,
                "@NgayBan", model.NgayBan,
                "@TongTien", model.TongTien,
                "@list_json_chitiethoadonban", model.list_json_chitiethoadonban != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonban) : null);
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
        public bool Update(HoaDonBanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonban_update",
                "@MaHDBan", model.MaHDBan,
                "@MaNhanVien", model.MaNhanVien,
                "@MaKhach", model.MaKhach,
                "@NgayBan", model.NgayBan,
                "@TongTien", model.TongTien,
                "@list_json_chitiethoadonban", model.list_json_chitiethoadonban != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonban) : null); 
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
        public bool Delete(HoaDonBanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_hoadonban",
                "@MaHDBan", model.MaHDBan);
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
