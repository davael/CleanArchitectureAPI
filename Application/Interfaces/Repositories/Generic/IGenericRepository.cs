using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        IQueryable<T> GetByFilter(Expression<Func<T, bool>>? filter = null);
        Task<bool> Add(T entity);
        void Update(T entity);
    }
}
