using case_study.Dtos;
using System.Threading.Tasks;

namespace case_study.Repositories
{
    public interface IAccountRepository
    {
        Task<AccountDto> AddAccountAsync(int customerId, AccountDto accountDto);
        Task<AccountDto> GetAccountAsync(int accountId);
        Task<bool> UpdateAccountAsync(int accountId, AccountDto accountDto);
        Task<bool> DeleteAccountAsync(int accountId);
        Task TransferAsync(TransferDto transfer);
        Task<IEnumerable<AccountDto>> GetAccountsForCustomerAsync(int customerId);
        Task<bool> UpdateAccountByCustomerAsync(int customerId, AccountDto accountDto);



    }
}
