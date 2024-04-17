using SUT23_UserAPI.Models;

namespace SUT23_UserAPI.Services
{
    public interface IUserRepsoitory
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        User AddUser(User newUser);
        void DeleteUSer(User user);
        User Uppdate(User user);
    }
}
