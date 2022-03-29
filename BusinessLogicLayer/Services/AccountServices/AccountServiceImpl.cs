using AutoMapper;
using BusinessLogicLayer.DTO.AccountDTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;

namespace BusinessLogicLayer.Services.AccountServices
{
    public class AccountServiceImpl : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper mapper;

        public AccountServiceImpl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AccountInfoResponse> CreateAsync(AccountModify entity)
        {
            var Acc = mapper.Map<Account>(entity);

            Acc.UserId = Acc.User.Id;

            var newAcc = await _unitOfWork.Accounts.CreateAsync(Acc);
            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(mapper.Map<AccountInfoResponse>(newAcc));
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AccountInfoResponse>> GetAllAsync()
        {
            var list = await _unitOfWork.Accounts.GetAllAsync();

            return list.Select(e => mapper.Map<AccountInfoResponse>(e));
        }

        public Task<AccountInfoResponse> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountInfoResponse> UpdateAsync(AccountModify entity)
        {
            throw new NotImplementedException();
        }
    }
}