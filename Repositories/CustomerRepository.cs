using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using case_study.Dtos;
using case_study.Models;

namespace case_study.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public Task TransferAsync(TransferDto transfer)
        {
            var sourceAccount = _customers
                .SelectMany(c => c.Accounts)
                .FirstOrDefault(a => a.CustomerId == transfer.SourceAccountId);

            var destinationAccount = _customers
                .SelectMany(c => c.Accounts)
                .FirstOrDefault(a => a.CustomerId == transfer.DestinationAccountId);

            if (sourceAccount == null || destinationAccount == null)
            {
                throw new InvalidOperationException("One or both accounts not found.");
            }

            if (sourceAccount.Balance < transfer.Amount)
            {
                throw new InvalidOperationException("Insufficient funds in the source account.");
            }

            sourceAccount.Balance -= transfer.Amount;
            destinationAccount.Balance += transfer.Amount;

            return Task.CompletedTask;
        }

        public CustomerDto AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = customerDto.ToModel(); // Convert DTO to Model
            customer.CustomerId = _customers.Count + 1;
            _customers.Add(customer);
            return customerDto.FromModel(customer); // Convert Model to DTO and return
        }

        public CustomerDto UpdateCustomerAsync(int id, CustomerDto customerDto)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.CustomerId == id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customerDto.Name;
                existingCustomer.Accounts = customerDto.Accounts.Select(a => a.ToModel()).ToList(); // Convert DTOs to Models
            }
            return customerDto; // Return DTO
        }

        public CustomerDto GetCustomerAsync(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            return customer?.ToDto(); // Convert Model to DTO and return
        }

        public IEnumerable<CustomerDto> GetAllCustomersAsync()
        {
            return _customers.Select(CustomerDto.FromModel); // Convert Models to DTOs and return
        }

        public void DeleteCustomerAsync(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }
}
