using DataModel;


namespace BusinessLogicLayer.Interfaces
{
    public partial interface INhanVienBusiness
    {
        NhanVienModel GetDatabyID(string MaNhanVien);
        bool Create(NhanVienModel model);
        bool Update(NhanVienModel model);
        bool Delete(NhanVienModel model);
        public List<NhanVienModel> Search(int pageIndex, int pageSize, out long total, string TenNhanVien, string DiaChi);
    }
}
