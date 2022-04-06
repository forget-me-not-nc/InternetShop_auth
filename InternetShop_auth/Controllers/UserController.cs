using BusinessLogicLayer.DTO.UserDTOs;
using BusinessLogicLayer.Services.UserServices;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<UserInfoResponse>>> GetAllUsers()
        {
            try
            {
                return Ok(await _userService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfoResponse>> GetById(string id)
        {
            try
            {
                return Ok(await _userService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create")]
        public async Task<ActionResult<UserInfoResponse>> Create([FromBody] UserCreateRequest user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _userService.CreateAsync(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<UserInfoResponse>> Update([FromBody] UserUpdateRequest user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _userService.UpdateAsync(user));
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
                await _userService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("password")]
        public async Task<ActionResult<UserInfoResponse>> UpdatePassword([FromBody] UserChangePasswordRequest password)
        {
            try
            {
                if (password == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _userService.UpdatePasswordAsync(password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("role")]
        public async Task<ActionResult<UserInfoResponse>> AddRole([FromBody] UserChangeRoleRequest userRole)
        {
            try
            {
                if (userRole == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _userService.AddRoleAsync(userRole));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("role")]
        public async Task<ActionResult<UserInfoResponse>> DeleteRole([FromBody] UserChangeRoleRequest userRole)
        {
            try
            {
                if (userRole == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _userService.DeleteRoleAsync(userRole));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
