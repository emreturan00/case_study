using case_study.Dtos;
using case_study.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace case_study.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountDto> AddAccountAsync(int customerId, AccountDto accountDto)
        {
            // Additional validation logic can be added here
            return await _repository.AddAccountAsync(customerId, accountDto);
        }

        public async Task<AccountDto> GetAccountAsync(int accountId)
        {
            // Additional logic such as access control can be applied here
            return await _repository.GetAccountAsync(accountId);
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsForCustomerAsync(int customerId)
        {
            // Additional logic such as access control can be applied here
            return await _repository.GetAccountsForCustomerAsync(customerId);
        }

        public async Task TransferAsync(TransferDto transferDto)
        {
            // Additional validation or business logic for transfer can be added here
            await _repository.TransferAsync(transferDto);
        }
    }
}
