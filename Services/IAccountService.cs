using case_study.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace case_study.Services
{
    public interface IAccountService
    {
        Task<AccountDto> AddAccountAsync(int customerId, AccountDto accountDto);
        Task<AccountDto> GetAccountAsync(int accountId);
        Task<IEnumerable<AccountDto>> GetAccountsForCustomerAsync(int customerId);
        Task TransferAsync(TransferDto transferDto);
    }
}
