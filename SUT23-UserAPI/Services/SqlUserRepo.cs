using SUT23_UserAPI.Models;

namespace SUT23_UserAPI.Services
{
    public class SqlUserRepo : IUserRepsoitory
    {
        private UserDbContext _dbContext;
        public SqlUserRepo(UserDbContext dbContext)
        {
              _dbContext = dbContext;
        }


        public User AddUser(User newUser)
        {
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        public void DeleteUSer(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.ID == id);    
        }

        public User Uppdate(User user)
        {
            var result = _dbContext.Users.Find(user.ID);
            if(result != null)
            {
                result.Name = user.Name;
                _dbContext.Users.Update(result);
                _dbContext.SaveChanges();
            }
            return result;
        }
    }
}
