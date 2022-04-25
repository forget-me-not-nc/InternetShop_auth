using BusinessLogicLayer.DTO.AccountDTOs;
using BusinessLogicLayer.Services.AccountServices;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<AccountInfoResponse>>> GetAllAccounts()
        {
            try
            {
                return Ok(await _accountService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountCreateRequest>> GetById(string id)
        {
            try
            {
                return Ok(await _accountService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create")]
        public async Task<ActionResult<AccountInfoResponse>> Create([FromBody] AccountCreateRequest account)
        {
            try
            {
                if (account == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                 return Ok(await _accountService.CreateAsync(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<AccountInfoResponse>> Update([FromBody] AccountUpdateRequest account)
        {
            try
            {
                if (account == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _accountService.UpdateAsync(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _accountService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
