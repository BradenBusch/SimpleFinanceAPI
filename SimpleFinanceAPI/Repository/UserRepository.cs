using SimpleFinanceAPI.Data;
using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Repository
{
    public class UserRepository : Interfaces.IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<User> GetAllUsers()
        {
            return _context.User.ToList();
        }

        public User GetUserByUserId(Guid userId)
        {
            return _context.User.Where(u => u.UserId == userId).First();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.User
                .Where(u => u.UserName.Equals(username) && u.UserPassword.Equals(password))
                .First();
        }
    }
}
