using DataModel;


namespace BusinessLogicLayer.Interfaces
{
    public partial interface IUserBusiness
    {
        UserModel Login(string taikhoan, string matkhau);
    }
}
