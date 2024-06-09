using case_study.Dtos;
using case_study.Models;

namespace case_study.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> AddCustomerAsync(CustomerDto customer);
        Task<CustomerDto> UpdateCustomerAsync(int id, CustomerDto customer);
        Task<CustomerDto> GetCustomerAsync(int id);
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task DeleteCustomerAsync(int id);
        Task TransferAsync(TransferDto transfer);
    }

}
    