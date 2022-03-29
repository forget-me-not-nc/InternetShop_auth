using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return Ok(_unitOfWork.Users.GetAllAsync().Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public ActionResult<User> GetById(string id)
        {
            try
            {
                return Ok(_unitOfWork.Users.GetByIdAsync(id).Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create")]
        public ActionResult<User> Create([FromBody] User user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                //account.Id = Guid.NewGuid().ToString();

                return Ok(_unitOfWork.Users.CreateAsync(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] User user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(_unitOfWork.Users.UpdateAsync(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                return Ok(_unitOfWork.Users.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
