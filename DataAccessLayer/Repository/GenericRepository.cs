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
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        protected static string GetEntityNotFoundErrorMessage(string id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return (await _context.Set<TEntity>().AddAsync(entity)).Entity;
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().AddRangeAsync(entities));
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id) => await _context.Set<TEntity>().FindAsync(id) ?? throw new Exception(GetEntityNotFoundErrorMessage(id));

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {

           return await Task.Run(() =>
               {
                   return _context.Set<TEntity>().Update(entity).Entity;
               });
        }
    }
}
