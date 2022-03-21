using DataAccessLayer.Repository.AccountRepository;
using DataAccessLayer.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
