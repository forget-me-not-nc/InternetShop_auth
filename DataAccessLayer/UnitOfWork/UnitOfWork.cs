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
        public IAccountRepository Accounts { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(DatabaseContext context, 
            IAccountRepository accountRepository,
            IUserRepository userRepository)
        {
            _context = context;
            Accounts = accountRepository;
            Users = userRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
