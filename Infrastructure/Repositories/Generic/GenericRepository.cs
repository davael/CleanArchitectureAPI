using Application.Interfaces.Repositories.Generic;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
