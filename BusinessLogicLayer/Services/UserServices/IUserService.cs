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
        Task<IEnumerable<UserInfo>> GetAllAsync();
        Task<UserInfo> GetAsync(string id);
        Task<UserInfo> UpdateAsync(UserModify entity);
        Task<UserInfo> CreateAsync(UserModify entity);
        Task DeleteAsync(string id);
    }
}
