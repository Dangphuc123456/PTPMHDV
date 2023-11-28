using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;

namespace BusinessLogicLayer
{
    public class NhaccBusiness : INhaCCBusiness
    {
        private INhaccRepository _res;
        public NhaccBusiness(INhaccRepository res)
        {
            _res = res;
        }
        public NhaCCModel GetDatabyID(string NhaCCID)
        {
            return _res.GetDatabyID(NhaCCID);
        }
        public bool Create(NhaCCModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhaCCModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(NhaCCModel model)
        {
            return _res.Delete( model);
        }
        
    }
}