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
                throw; //Ném lại mà không thay đổi thông tin ngăn xếp
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

       
        public bool Delete(NhaCCModel model)
        {
            string msgError = "";
            try
            {
               // 
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhacc_delete",
                    "@NhaCCID", model.NhaCCID);
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