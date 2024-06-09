using case_study.Dtos;
using case_study.Models;

namespace case_study.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Customer> _customers;

        public AccountRepository(List<Customer> customers)
        {
            _customers = customers;
        }

        public async Task<AccountDto> AddAccountAsync(int customerId, AccountDto accountDto)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            var newAccount = new Account
            {
                AccountId = customer.Accounts.Count + 1,
                AccountNumber = accountDto.AccountNumber,
                Balance = accountDto.Balance,
                CustomerId = customerId
            };

            customer.Accounts.Add(newAccount);
            accountDto.Id = newAccount.CustomerId;
            return await Task.FromResult(accountDto);
        }

        public async Task<AccountDto> GetAccountAsync(int accountId)
        {
            var account = _customers
                .SelectMany(c => c.Accounts)
                .FirstOrDefault(a => a.CustomerId == accountId);

            if (account == null)
            {
                throw new InvalidOperationException("Account not found.");
            }

            var accountDto = new AccountDto
            {
                Id = account.CustomerId,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                CustomerId = account.CustomerId
            };

            return await Task.FromResult(accountDto);
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsForCustomerAsync(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            var accountDtos = customer.Accounts.Select(a => new AccountDto
            {
                Id = a.CustomerId,
                AccountNumber = a.AccountNumber,
                Balance = a.Balance,
                CustomerId = a.CustomerId
            });

            return await Task.FromResult(accountDtos);
        }

        public async Task TransferAsync(TransferDto transferDto)
        {
            var sourceAccount = _customers
                .SelectMany(c => c.Accounts)
                .FirstOrDefault(a => a.AccountId == transferDto.SourceAccountId);

            var destinationAccount = _customers
                .SelectMany(c => c.Accounts)
                .FirstOrDefault(a => a.AccountId == transferDto.DestinationAccountId);

            if (sourceAccount == null || destinationAccount == null)
            {
                throw new InvalidOperationException("One or both accounts not found.");
            }

            if (sourceAccount.Balance < transferDto.Amount)
            {
                throw new InvalidOperationException("Insufficient funds in the source account.");
            }

            sourceAccount.Balance -= transferDto.Amount;
            destinationAccount.Balance += transferDto.Amount;
        }
    }
}
