using BusinessLogicLayer.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserInfoResponse>> GetAllAsync();
        Task<UserInfoResponse> GetAsync(string id);
        Task<UserInfoResponse> UpdateAsync(UserUpdateRequest entity);
        Task<UserInfoResponse> CreateAsync(UserCreateRequest entity);
        Task DeleteAsync(string id);
        Task<UserInfoResponse> UpdatePasswordAsync(UserChangePasswordRequest entity);
        Task<UserInfoResponse> DeleteRoleAsync(UserChangeRoleRequest entity);
        Task<UserInfoResponse> AddRoleAsync(UserChangeRoleRequest entity);
    }
}
