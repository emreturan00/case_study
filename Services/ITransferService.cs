using case_study.Dtos;

namespace case_study.Services
{
    public interface ITransferService
    {
        Task TransferAsync(TransferDto transfer);
    }

}
