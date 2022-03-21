using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext _context;
        protected static string GetEntityNotFoundErrorMessage(string id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Add(entity));
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().AddRange(entities));
        }

        public async Task DeleteAsync(string id)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(GetByIdAsync(id).Result));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id) => await _context.Set<TEntity>().FindAsync(id)?? throw new Exception(GetEntityNotFoundErrorMessage(id));

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
        }
    }
}
