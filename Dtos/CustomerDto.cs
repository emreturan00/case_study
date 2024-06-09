using System.Collections.Generic;
using System.Linq;
using case_study.Models;

namespace case_study.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AccountDto> Accounts { get; set; } = new List<AccountDto>();

        public static CustomerDto FromModel(Customer model)
        {
            if (model == null)
                return null;

            return new CustomerDto
            {
                Id = model.CustomerId,
                Name = model.Name,
                Accounts = model.Accounts.Select(AccountDto.FromModel).ToList()
            };
        }

        public Customer ToModel()
        {
            return new Customer
            {
                CustomerId = Id,
                Name = Name,
                Accounts = Accounts.Select(a => a.ToModel()).ToList()
            };
        }
    }
}
