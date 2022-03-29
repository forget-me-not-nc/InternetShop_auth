using BusinessLogicLayer.DTO.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AccountServices
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountInfoResponse>> GetAllAsync();
        Task<AccountInfoResponse> GetAsync(string id);
        Task<AccountInfoResponse> UpdateAsync(AccountModify entity);
        Task<AccountInfoResponse> CreateAsync(AccountModify entity);
        Task DeleteAsync(string id);
    }
}
