using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(string id);
    }
}
