using System.Threading.Tasks;
using case_study.Dtos;

public interface IMessageQueuePublisher
{
    Task PublishTransferMessageAsync(TransferDto transferDto);
}
