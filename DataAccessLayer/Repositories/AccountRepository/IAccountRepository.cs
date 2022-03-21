using DataAccessLayer.Entities;
using DataAccessLayer.Pagination;
using DataAccessLayer.Parameters;
using DataAccessLayer.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.AccountRepository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<PagedList<Account>> GetAsync(AccountParameters parameters);
    }
}
