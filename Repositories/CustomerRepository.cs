using case_study.Dtos;
using case_study.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace case_study.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = customerDto.ToModel();

            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();

            return CustomerDto.FromModel(customer);
        }

        public async Task<CustomerDto> UpdateCustomerAsync(int id, CustomerDto customerDto)
        {
            var customer = await _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return null;
            }

            customer.Name = customerDto.Name;
            customer.Accounts = customerDto.Accounts.Select(a => a.ToModel()).ToList();

            await _context.SaveChangesAsync();

            return CustomerDto.FromModel(customer);
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return null;
            }

            return CustomerDto.FromModel(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers
                .Include(c => c.Accounts)
                .ToListAsync();

            return customers.Select(CustomerDto.FromModel);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task TransferAsync(TransferDto transfer)
        {
            var sourceAccount = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId == transfer.SourceAccountId);

            var targetAccount = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId == transfer.DestinationAccountId);

            if (sourceAccount == null || targetAccount == null)
            {
                throw new Exception("Source or target account not found.");
            }

            if (sourceAccount.Balance < transfer.Amount)
            {
                throw new Exception("Insufficient funds in source account.");
            }

            sourceAccount.Balance -= transfer.Amount;
            targetAccount.Balance += transfer.Amount;

            await _context.SaveChangesAsync();
        }

    }
}
