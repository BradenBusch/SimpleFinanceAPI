using Microsoft.EntityFrameworkCore;
using SimpleFinanceAPI.Data;
using SimpleFinanceAPI.Interfaces;
using SimpleFinanceAPI.Models;


namespace SimpleFinanceAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByUserId(Guid userId)
        {
            return await _context.User.Where(u => u.UserId == userId).FirstAsync();
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.User
                .Where(u => u.UserName.Equals(username) && u.UserPassword.Equals(password))
                .FirstAsync();
        }
    }
}
