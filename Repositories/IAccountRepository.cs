using case_study.Dtos;

namespace case_study.Repositories
{
    public interface IAccountRepository
    {
        Task<AccountDto> AddAccountAsync(int customerId, AccountDto accountDto);
        Task<AccountDto> GetAccountAsync(int accountId);
        Task<IEnumerable<AccountDto>> GetAccountsForCustomerAsync(int customerId);
        Task TransferAsync(TransferDto transferDto);

    }
}
