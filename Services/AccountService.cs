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
            return await _repository.AddAccountAsync(customerId, accountDto);
        }

        public async Task<AccountDto> GetAccountAsync(int accountId)
        {
            return await _repository.GetAccountAsync(accountId);
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsForCustomerAsync(int customerId)
        {
            return await _repository.GetAccountsForCustomerAsync(customerId);
        }

        public async Task TransferAsync(TransferDto transferDto)
        {
            await _repository.TransferAsync(transferDto);
        }
        public async Task<bool> UpdateAccountByCustomerAsync(int customerId, AccountDto accountDto)
        {
            return await _repository.UpdateAccountByCustomerAsync(customerId, accountDto);
        }

    }
}
