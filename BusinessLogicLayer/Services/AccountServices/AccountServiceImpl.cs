using AutoMapper;
using BusinessLogicLayer.DTO.AccountDTOs;
using BusinessLogicLayer.DTO.UserDTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services.AccountServices
{
    public class AccountServiceImpl : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly UserManager<User> _userManager;

        private readonly IMapper mapper;

        public AccountServiceImpl(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AccountInfoResponse> CreateAsync(AccountCreateRequest entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            var Acc = mapper.Map<Account>(entity);

            var userCreate = new UserCreateRequest() 
            {
                Email = entity.Email,
                Id = Guid.NewGuid().ToString(),
                IsDeleted = false,
                UserName = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };

            await _userManager.CreateAsync(mapper.Map<User>(userCreate), entity.Password);
            
            var newUser = await _userManager.FindByIdAsync(userCreate.Id);

            await _userManager.AddToRoleAsync(newUser, entity.Role);

            Acc.User = newUser;
            Acc.UserId = newUser.Id;

            var newAcc = await _unitOfWork.Accounts.CreateAsync(Acc);

            await _unitOfWork.SaveChangesAsync();

            return mapper.Map<AccountInfoResponse>(newAcc);
        }

        public async Task DeleteAsync(string id)
        {
            var acc = await _unitOfWork.Accounts.GetByIdAsync(id);
            var user = await _userManager.FindByIdAsync(acc.UserId);

            //soft delete

            acc.IsActive = false;
            user.IsDeleted = true;
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<AccountInfoResponse>> GetAllAsync()
        {
            var list = await _unitOfWork.Accounts.GetAllAsync();

            return list.Select(e => mapper.Map<AccountInfoResponse>(e));
        }

        public async Task<AccountInfoResponse> GetAsync(string id)
        {
            var Acc = await _unitOfWork.Accounts.GetByIdAsync(id); 

            return mapper.Map<AccountInfoResponse>(Acc);
        }

        public async Task<AccountInfoResponse> UpdateAsync(AccountUpdateRequest entity)
        {
            var acc = await _unitOfWork.Accounts.GetByIdAsync(entity.Id);
            acc.Balance = entity.Balance;
            acc.IsActive = entity.isActive;

            await _unitOfWork.Accounts.UpdateAsync(acc);
            await _unitOfWork.SaveChangesAsync();

            return mapper.Map<AccountInfoResponse>(acc);
        }
    }
}