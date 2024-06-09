using case_study.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace case_study.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> AddCustomerAsync(CustomerDto customer);
        Task<CustomerDto> UpdateCustomerAsync(int id, CustomerDto customer);
        Task<CustomerDto> GetCustomerAsync(int id);
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task DeleteCustomerAsync(int id);
        Task TransferAsync(TransferDto transferDto);
    }
}
