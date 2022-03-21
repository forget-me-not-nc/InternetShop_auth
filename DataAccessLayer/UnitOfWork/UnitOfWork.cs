using DataAccessLayer.Repository.AccountRepository;
using DataAccessLayer.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
            Users = new UserRepository(_context);
        }

        public IAccountRepository Accounts { get; private set; }

        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges().Result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
