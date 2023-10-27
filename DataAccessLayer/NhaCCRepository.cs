using DataModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Helper;

namespace DataAccessLayer
{
    public class NhaCCRepository : INhaccRepository
    {
        private IDatabaseHelper _dbHelper;
        public NhaCCRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public NhaCCModel GetDatabyID(string NhaCCID)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhacc_get_by_id",
                     "@NhaCCID", NhaCCID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaCCModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Create(NhaCCModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhacc_create",
                 "@TenNCC", model.TenNCC,
                "@DiachiNCC", model.DiachiNCC,
                "@SdtNCC", model.SdtNCC);
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

        public bool Update(NhaCCModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhacc_update",
                "@NhaCCID", model.NhaCCID,
                "@TenNCC", model.TenNCC,
                "@DiachiNCC", model.DiachiNCC,
                "@SdtNCC", model.SdtNCC);
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

        public List<NhaCCModel> Search(int pageIndex, int pageSize, out long total, string TenNCC, string DiachiNCC)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhacc_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenNCC", TenNCC,
                    "@DiachiNCC", DiachiNCC);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhaCCModel>().ToList();
            }
            catch (Exception ex)
            {
                throw; // Re-throw without changing stack information
            }
        }

    }
}