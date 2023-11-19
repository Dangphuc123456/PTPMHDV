using DataModel;


namespace BusinessLogicLayer.Interfaces
{
    public partial interface INhaCCBusiness
    {
        NhaCCModel GetDatabyID(string NhaCCID);
        bool Create(NhaCCModel model);
        bool Update(NhaCCModel model);
        bool Delete(NhaCCModel model);
        public List<NhaCCModel> Search(int pageIndex, int pageSize, out long total, string TenNCC, string DiachiNCC);
    }
}
