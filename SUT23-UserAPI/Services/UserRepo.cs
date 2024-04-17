using SUT23_UserAPI.Models;

namespace SUT23_UserAPI.Services
{
    public class UserRepo : IUserRepsoitory
    {
        private List<User> users = new List<User>()
        {
            new User() {ID = 101,Name = "Tobias"},
            new User() {ID = 102,Name = "Sara"},
            new User() {ID = 103,Name = "Simon"},
            new User() {ID = 104,Name = "Sam"},

        };

        public User AddUser(User newUser)
        {
            users.Add(newUser);
            return newUser;
        }

        public void DeleteUSer(User user)
        {
            users.Remove(user);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUser(int id)
        {
            return users.FirstOrDefault(u => u.ID == id);
        }

        public User Uppdate(User user)
        {
            var exUser = GetUser(user.ID);
            exUser.Name = user.Name;
            return user;
        }
    }
}
