using case_study.Dtos;
using case_study.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace case_study.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDto> AddCustomerAsync(CustomerDto customer)
        {
            return await _repository.AddCustomerAsync(customer);
        }

        public async Task<CustomerDto> UpdateCustomerAsync(int id, CustomerDto customer)
        {
            return await _repository.UpdateCustomerAsync(id, customer);
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            return await _repository.GetCustomerAsync(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            return await _repository.GetAllCustomersAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteCustomerAsync(id);
        }

        public async Task TransferAsync(TransferDto transferDto)
        {
            await _repository.TransferAsync(transferDto);
        }
    }
}
