using BusinessLogicLayer.DTO.AccountDTOs;
using BusinessLogicLayer.Services.AccountServices;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop_auth.Controllers
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

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<AccountModify>> GetAllAccounts()
        {
            try
            {
                return Ok(_accountService.GetAllAsync().Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("get/{id}")]
        //public ActionResult<AccountModify> GetById(string id)
        //{
        //    try
        //    {
        //        //return Ok(_unitOfWork.Accounts.GetByIdAsync(id).Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [HttpPost("create")]
        public ActionResult Create([FromBody] AccountModify account)
        {
            try
            {
                if (account == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                account.Id = Guid.NewGuid().ToString();

                 return Ok(_accountService.CreateAsync(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] AccountModify account)
        {
            try
            {
                if (account == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(_accountService.UpdateAsync(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete("delete/{id}")]
        //public ActionResult Delete(string id)
        //{
        //    try
        //    {
        //        return Ok(_unitOfWork.Accounts.DeleteAsync(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
