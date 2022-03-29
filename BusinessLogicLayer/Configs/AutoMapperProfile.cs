using AutoMapper;
using BusinessLogicLayer.DTO.UserDTOs;
using BusinessLogicLayer.DTO.AccountDTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO.Configs
{
    public class AutoMapperProfile : Profile
    {
        private void UserMapper()
        {
            CreateMap<UserModify, User>();
            CreateMap<User, UserInfo>();
        }
        private void AccountMapper()
        {
            CreateMap<Account, AccountInfoResponse>();

            CreateMap<AccountModify, Account>()
                .ForMember(dest => dest.User, rule => rule.MapFrom(
                        src => new User()
                        {
                            FirstName = src.FirstName,
                            LastName = src.LastName,
                            Address = src.Address,
                            Id = Guid.NewGuid().ToString(),
                            IsDeleted = false
                        }
                    ));
        }

        public AutoMapperProfile()
        {
            UserMapper();
            AccountMapper();
        }
    }
}
