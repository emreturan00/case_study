using case_study.Dtos;
using case_study.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace case_study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(TransferDto transferDto)
        {
            try
            {
                await _accountService.TransferAsync(transferDto);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> AddAccount(int customerId, AccountDto accountDto)
        {
            var createdAccount = await _accountService.AddAccountAsync(customerId, accountDto);
            return CreatedAtAction(nameof(GetAccount), new { id = createdAccount.Id }, createdAccount);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _accountService.GetAccountAsync(id);
            return Ok(account);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetAccountsForCustomer(int customerId)
        {
            var accounts = await _accountService.GetAccountsForCustomerAsync(customerId);
            return Ok(accounts);
        }

        [HttpPut("customer/{customerId}")]
        public async Task<IActionResult> UpdateAccountByCustomer(int customerId, AccountDto accountDto)
        {
            var result = await _accountService.UpdateAccountByCustomerAsync(customerId, accountDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
