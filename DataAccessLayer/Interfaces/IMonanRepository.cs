using DataModel;

namespace DataAccessLayer.Interfaces
{
     public  partial interface  IMonanRepository
     {
        MonanModel GetDatabyID(string Mamonan);
        bool Create (MonanModel monan);
        bool Update(MonanModel model);
        bool Delete(MonanModel model);
        public List<MonanModel> Search(int pageIndex, int pageSize, out long total, string Tenmonan, string Loaimonan);
     }
}

