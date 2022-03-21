using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AccountRepository;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        IAccountRepository _repository;

        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")]
        public ActionResult<Account> GetAllAccounts()
        {
            try
            {
                var a = _repository.GetAllAsync();

                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
