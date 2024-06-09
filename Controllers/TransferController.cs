using case_study.Dtos;
using case_study.Services;
using Microsoft.AspNetCore.Mvc;

namespace case_study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferDto transfer)
        {
            Console.WriteLine("Transfering money");
            await _transferService.TransferAsync(transfer);
            return Ok();
        }
    }

}
