using DataModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Helper;

namespace DataAccessLayer
{
    public class MonanRepository : IMonanRepository
    {
        private IDatabaseHelper _dbHelper;
        public MonanRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public MonanModel GetDatabyID(string Mamonan)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_monan_get_by_id",
                     "@Mamonan", Mamonan);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MonanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Create(MonanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_monan_create",
                "@Mamonan",model.Mamonan,
                "@Tenmonan", model.Tenmonan,
                "@Loaimonan", model.Loaimonan,
                "@Gia", model.Gia);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw; //Ném lại mà không thay đổi thông tin ngăn xếp
            }
        }

        public bool Update(MonanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_monan_update",
                "@Mamonan", model.Mamonan,
                "@Tenmonan", model.Tenmonan,
                "@Loaimonan", model.Loaimonan,
                "@Gia", model.Gia);
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

        public List<MonanModel> Search(int pageIndex, int pageSize, out long total, string Tenmonan, string Loaimonan)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_monan_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Tenmonan", Tenmonan,
                    "@Loaimonan", Loaimonan);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<MonanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw; // Re-throw without changing stack information
            }
        }
        public bool Delete(MonanModel model)
        {
            string msgError = "";
            try
            {
                // 
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_monan_delete",
                    "@Mamonan", model.Mamonan);
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

