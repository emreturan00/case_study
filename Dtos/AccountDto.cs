using case_study.Models;

namespace case_study.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }

        public static AccountDto FromModel(Account model)
        {
            if (model == null)
                return null;

            return new AccountDto
            {
                Id = model.AccountId,
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                CustomerId = model.CustomerId
            };
        }

        public Account ToModel()
        {
            return new Account
            {
                AccountId = Id,
                AccountNumber = AccountNumber,
                Balance = Balance,
                CustomerId = CustomerId
            };
        }
    }
}
