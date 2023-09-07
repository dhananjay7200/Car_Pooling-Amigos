using Car_pooling.Models;

namespace Car_pooling.Interfaces
{
    public interface IUserDetails
    {
        Task<UserDetail> UserRegister(UserDetail user);

        Task<string> UserLogin(LoginDetails user);
        UserDetail GetUserById(int id);

        IEnumerable<UserDetail> GetAllUsersDetails();

    }
}
