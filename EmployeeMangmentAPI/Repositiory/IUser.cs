using EmployeeMangmentAPI.Model;

namespace EmployeeMangmentAPI.Repositiory
{
    public interface IUser
    {
        void CheckLogin(UserModel user);
    }
}
