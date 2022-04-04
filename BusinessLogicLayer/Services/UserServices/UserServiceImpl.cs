using AutoMapper;
using BusinessLogicLayer.DTO.UserDTOs;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UserServices
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper mapper;

        public UserServiceImpl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<UserInfo> CreateAsync(UserModify entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            await _unitOfWork.Users.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfo> GetAsync(string id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            return mapper.Map<UserInfo>(user);
        }

        public Task<UserInfo> UpdateAsync(UserModify entity)
        {
            throw new NotImplementedException();
        }
    }
}
