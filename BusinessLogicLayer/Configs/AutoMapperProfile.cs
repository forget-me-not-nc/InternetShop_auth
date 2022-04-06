using AutoMapper;
using BusinessLogicLayer.DTO.UserDTOs;
using BusinessLogicLayer.DTO.AccountDTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.DTO.Configs
{
    public class AutoMapperProfile : Profile
    {
        private void UserMapper()
        {
            CreateMap<UserCreateRequest, User>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<User, UserInfoResponse>();
        }
        private void AccountMapper()
        {
            CreateMap<Account, AccountInfoResponse>();

            CreateMap<AccountCreateRequest, Account>();

            CreateMap<AccountUpdateRequest, Account>();
        }

        public AutoMapperProfile()
        {
            UserMapper();
            AccountMapper();
        }
    }
}
