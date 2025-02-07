using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        User GetUserByUsernameAndPassword(string username, string password);
        User GetUserByUserId(Guid userId);
    }
}
