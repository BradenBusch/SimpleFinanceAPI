using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Interfaces
{
    public interface IAccountHeaderRepository
    {
        Task<List<AccountHeader>> GetAccountHeaders();
        Task<List<AccountHeader>> GetAccountHeadersByUserId(Guid userId);
        Task<AccountHeader> GetAccountHeaderByAccountId(Guid accountId);
        Task<AccountHeader> CreateAccountHeader(AccountHeader accountHeader);
        Task<AccountHeader> UpdateAccountHeader(AccountHeader accountHeader);
        Task<AccountHeader> DeleteAccountHeader(Guid accountHeader);
        
    }
}
