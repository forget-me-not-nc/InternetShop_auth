using DataAccessLayer.Repository.AccountRepository;
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

        public UnitOfWork(DatabaseContext context, 
            IAccountRepository accountRepository
            )
        {
            _context = context;
            Accounts = accountRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
