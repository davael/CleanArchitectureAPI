using Application.Interfaces.Repositories.Generic;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly SocialMediaContext _context;
        protected DbSet<T> _entities;

        public GenericRepository(SocialMediaContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await this._entities!.FindAsync(id);
        }
        public async Task<bool> Add(T entity)
        {
            await _entities.AddAsync(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public  IQueryable<T> GetByFilter(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entities;

            if (filter != null) query = query.Where(filter);

            return query;
        }
    }
}
