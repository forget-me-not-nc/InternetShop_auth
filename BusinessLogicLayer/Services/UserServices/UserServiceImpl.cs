using BusinessLogicLayer.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UserServices
{
    public class UserServiceImpl : IUserService
    {
        public Task<UserInfo> CreateAsync(UserModify entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo> UpdateAsync(UserModify entity)
        {
            throw new NotImplementedException();
        }
    }
}
