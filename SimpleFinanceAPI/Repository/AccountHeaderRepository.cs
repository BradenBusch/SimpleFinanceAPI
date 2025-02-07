using Microsoft.EntityFrameworkCore;
using SimpleFinanceAPI.Data;
using SimpleFinanceAPI.Interfaces;
using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Repository
{
    public class AccountHeaderRepository : IAccountHeaderRepository
    {
        private readonly DataContext _context;

        public AccountHeaderRepository(DataContext context)
        {
            _context = context;
        }

        // Get All Accounts Regardless of User
        public async Task<List<AccountHeader>> GetAccountHeaders()
        {
            return await _context.AccountHeader.ToListAsync();
        }

        // Get All Accounts By User
        public async Task<List<AccountHeader>> GetAccountHeadersByUserId(Guid userId)
        {
            return await _context.AccountHeader.Where(ah => ah.UserId == userId).ToListAsync();
        }

        // Get An Account Header By Id
        public async Task<AccountHeader> GetAccountHeaderByAccountId(Guid accountId)
        {
            return await _context.AccountHeader.Where(x => x.AccountId == accountId).FirstAsync();
        }

        // Create an Account Header
        public async Task<AccountHeader> CreateAccountHeader(AccountHeader accountHeader)
        {
            await _context.AccountHeader.AddAsync(accountHeader);
            await _context.SaveChangesAsync();
            return accountHeader;
        }

        // Delete an Account Header
        public async Task<AccountHeader> DeleteAccountHeader(Guid accountHeaderId)
        {
            var accountHeader = await _context.AccountHeader.FirstOrDefaultAsync(x => x.AccountId == accountHeaderId);

            if (accountHeader == null)
            {
                return null;
            }

            _context.AccountHeader.Remove(accountHeader);
            await _context.SaveChangesAsync();
            return accountHeader;
        }

        public async Task<AccountHeader> UpdateAccountHeader(AccountHeader accountHeader)
        {
            var existingAccountHeader = await _context.AccountHeader.FirstOrDefaultAsync(x => x.AccountId == accountHeader.AccountId);

            if (existingAccountHeader == null)
            {
                return null;
            }

            existingAccountHeader.AccountDescription = accountHeader.AccountDescription;
            existingAccountHeader.AccountPhone = accountHeader.AccountPhone;
            existingAccountHeader.AccountName = accountHeader.AccountName;
            existingAccountHeader.AccountValue = accountHeader.AccountValue;
            existingAccountHeader.AccountType = accountHeader.AccountType;

            await _context.SaveChangesAsync();
            return accountHeader;
        }
    }
}
