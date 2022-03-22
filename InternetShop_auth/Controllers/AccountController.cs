using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Account>> GetAllAccounts()
        {
            try
            {
                return Ok(_unitOfWork.Accounts.GetAllAsync().Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public ActionResult<IEnumerable<Account>> GetById(string id)
        {
            try
            {
                return Ok(_unitOfWork.Accounts.GetByIdAsync(id).Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create")]
        public ActionResult<IEnumerable<Account>> Create([FromBody] Account account)
        {
            try
            {
                if (account == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                account.Id = Guid.NewGuid().ToString();

                return Ok(_unitOfWork.Accounts.CreateAsync(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult<IEnumerable<Account>> Update([FromBody] Account account)
        {
            try
            {
                if (account == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(_unitOfWork.Accounts.UpdateAsync(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<IEnumerable<Account>> Delete(string id)
        {
            try
            {
                return Ok(_unitOfWork.Accounts.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
