﻿using AutoMapper;
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

        public async Task<AccountInfoResponse> CreateAsync(AccountCreateRequest entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            var Acc = mapper.Map<Account>(entity);

            var newAcc = await _unitOfWork.Accounts.CreateAsync(Acc);

            await _unitOfWork.SaveChangesAsync();

            return mapper.Map<AccountInfoResponse>(newAcc);
        }

        public async Task DeleteAsync(string id)
        {
            var acc = await _unitOfWork.Accounts.GetByIdAsync(id);
          
            //soft delete

            acc.IsActive = false;
            
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