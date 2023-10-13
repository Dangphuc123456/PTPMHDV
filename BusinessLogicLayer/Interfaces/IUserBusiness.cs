using DataModel;


namespace BusinessLogicLayer
{
    public partial interface IUserBusiness
    {
        UserModel Login(string taikhoan, string matkhau);
    }
}
