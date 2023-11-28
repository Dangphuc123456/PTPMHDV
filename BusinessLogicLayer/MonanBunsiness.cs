using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MonanBunsiness:IMonanBusiness
    {
        private IMonanRepository _res;
        public MonanBunsiness(IMonanRepository res)
        {
            _res = res;
        }
        public MonanModel GetDatabyID(string Mamonan)
        {
            return _res.GetDatabyID(Mamonan);
        }
        public bool Create(MonanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(MonanModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(MonanModel model)
        {
            return _res.Delete(model);
        }
    }
}

