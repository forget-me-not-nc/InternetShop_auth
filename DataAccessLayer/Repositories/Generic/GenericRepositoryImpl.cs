using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Generic
{
    public abstract class GenericRepositoryImpl<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext databaseContext;

        protected readonly DbSet<TEntity> table;

        public GenericRepositoryImpl(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            table = this.databaseContext.Set<TEntity>();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await table.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Task.Run(async () => table.Remove(await GetByIdAsync(id)));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await table.FindAsync(id) ?? throw new Exception(GetEntityNotFoundErrorMessage(id));
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
           await Task.Run(() => table.Update(entity));
        }

        protected static string GetEntityNotFoundErrorMessage(int id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";
    }
}
