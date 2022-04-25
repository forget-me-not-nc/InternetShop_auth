using DataAccessLayer.Repository.AccountRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork 
    {
        IAccountRepository Accounts { get; }
        Task SaveChangesAsync();
    }
}
