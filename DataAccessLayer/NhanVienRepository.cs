﻿using DataAccessLayer.Helper;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;


namespace DataAccessLayer
{
    public class NhanVienRepository : INhanVienRepository
    {
        private IDatabaseHelper _dbHelper;
        public NhanVienRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public NhanVienModel GetDatabyID(string MaNhanVien)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nha_vien_get_by_id",
                     "@MaNhanVien", MaNhanVien);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanVienModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Create(NhanVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhanvien_create",
                   "@MaNhanVien", model.MaNhanVien,
                 "@TenNhanVien", model.TenNhanVien,
                 "@GioiTinh", model.GioiTinh,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai,
                "@NgaySinh", model.NgaySinh);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw; // Re-throw without changing stack information
            }
        }

        public bool Update(NhanVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhanvien_update",
                "@MaNhanVien", model.MaNhanVien,
                "@TenNhanVien", model.TenNhanVien,
                "@GioiTinh", model.GioiTinh,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai,
                "@NgaySinh", model.NgaySinh);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw; // Re-throw without changing stack information
            }
        }
        public bool Delete(NhanVienModel model)
        {
            string msgError = "";
            try
            {
                // 
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhanvien_delete",
                    "@MaNhanVien", model.MaNhanVien);
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
