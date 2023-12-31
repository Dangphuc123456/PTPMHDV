﻿using DataModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Helper;

namespace DataAccessLayer
{
    public class KhachHangRepository : IKhachRepository
    {
        private IDatabaseHelper _dbHelper;
        public KhachHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public KhachHangModel GetDatabyID(string MaKhach)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_get_by_id",
                     "@MaKhach", MaKhach);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

        public bool Create(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_create",
                "@MaKhach",model.MaKhach,
                "@TenKhach", model.TenKhach,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai);
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

        public bool Update(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_update",
                "@MaKhach", model.MaKhach,
                "@TenKhach", model.TenKhach,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai);
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

        
        public bool Delete(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                // 
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_delete",
                    "@MaKhach", model.MaKhach);
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