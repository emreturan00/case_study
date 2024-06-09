using System.Transactions;
using case_study.Dtos;
using case_study.Repositories;

namespace case_study.Services
{
    public class TransferService : ITransferService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMessageQueuePublisher _messageQueuePublisher;

        public TransferService(IAccountRepository accountRepository, IMessageQueuePublisher messageQueuePublisher)
        {
            _accountRepository = accountRepository;
            _messageQueuePublisher = messageQueuePublisher;
        }

        public async Task TransferAsync(TransferDto transfer)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var fromAccount = await _accountRepository.GetAccountAsync(transfer.SourceAccountId);
                var toAccount = await _accountRepository.GetAccountAsync(transfer.DestinationAccountId);

                if (fromAccount.Balance < transfer.Amount)
                {
                    throw new InvalidOperationException("Insufficient funds");
                }   

                fromAccount.Balance -= transfer.Amount;
                toAccount.Balance += transfer.Amount;

              

                await _accountRepository.TransferAsync(transfer);

                await _messageQueuePublisher.PublishTransferMessageAsync(transfer);

                transaction.Complete();
            }
        }
    }

}
