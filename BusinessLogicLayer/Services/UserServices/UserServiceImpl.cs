using AutoMapper;
using BusinessLogicLayer.DTO.UserDTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services.UserServices
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly UserManager<User> _userManager;

        private readonly IMapper _mapper;

        public UserServiceImpl(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserInfoResponse> CreateAsync(UserCreateRequest entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            var user = _mapper.Map<User>(entity);

            await _userManager.CreateAsync(user, entity.Password);
            await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(user.Id), entity.Role);

            await _unitOfWork.SaveChangesAsync();

            return await map(await _userManager.FindByIdAsync(user.Id));
        }

        public async Task DeleteAsync(string id)
        {
            //soft delete

            (await _userManager.FindByIdAsync(id)).IsDeleted = true;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserInfoResponse>> GetAllAsync()
        {
            var list = await _userManager.Users.ToListAsync();

            return list.Select(async u => await map(u))
                .Select(r => r.Result)
                .ToList(); 
        }

        public async Task<UserInfoResponse> GetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return await map(user);
        }

        public async Task<UserInfoResponse> UpdateAsync(UserUpdateRequest entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id);

            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Address = entity.Address;
            user.UserName = entity.UserName;
            user.PhoneNumber = entity.PhoneNumber;
            user.IsDeleted = entity.IsDeleted;

            await _unitOfWork.SaveChangesAsync();

            return await map(user);
        }

        public async Task<UserInfoResponse> UpdatePasswordAsync(UserChangePasswordRequest entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id);

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, entity.Password);

            await _unitOfWork.SaveChangesAsync();

            return await map(user);
        }

        public async Task<UserInfoResponse> AddRoleAsync(UserChangeRoleRequest entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id);

            await _userManager.AddToRoleAsync(user, entity.Role);

            await _unitOfWork.SaveChangesAsync();

            return await map(user);
        }

        public async Task<UserInfoResponse> DeleteRoleAsync(UserChangeRoleRequest entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id);

            await _userManager.RemoveFromRoleAsync(user, entity.Role);

            await _unitOfWork.SaveChangesAsync();

            return await map(user);
        }

        private async Task<UserInfoResponse> map(User user)
        {
            UserInfoResponse response = _mapper.Map<UserInfoResponse>(user);

            response.Roles = (await _userManager.GetRolesAsync(user)).ToList();

            return response; 
        }
    }
}
