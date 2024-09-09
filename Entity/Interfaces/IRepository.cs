using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            params Expression<Func<T, object>>[] includes
        );

        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task DeleteAsync(T entity);
    }
}
