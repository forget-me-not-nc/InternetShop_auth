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
    public class AccountRepository : GenericRepositoryImpl<Account>, IAccountRepository
    {
        public AccountRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Task<PagedList<Account>> GetAsync(AccountParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
