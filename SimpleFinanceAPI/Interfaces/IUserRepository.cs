using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByUsernameAndPassword(string username, string password);
        Task<User> GetUserByUserId(Guid userId);
    }
}
