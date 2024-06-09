using case_study.Dtos;
using case_study.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace case_study.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AccountDto> AddAccountAsync(int customerId, AccountDto accountDto)
        {
            var customer = await _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return null;
            }

            var account = accountDto.ToModel();

            customer.Accounts.Add(account);

            await _context.SaveChangesAsync();

            return AccountDto.FromModel(account);
        }


        public async Task<AccountDto> GetAccountAsync(int accountId)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (account == null)
            {
                return null;
            }

            return AccountDto.FromModel(account);
        }


        public async Task<bool> UpdateAccountAsync(int accountId, AccountDto accountDto)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (account == null)
            {
                return false;
            }

            account.AccountNumber = accountDto.AccountNumber;
            account.Balance = accountDto.Balance;
            account.CustomerId = accountDto.CustomerId;

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAccountAsync(int accountId)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (account == null)
            {
                return false;
            }

            _context.Accounts.Remove(account);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
