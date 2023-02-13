using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Helpers;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ClubesContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(ClubesContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll =  await _entity.Where(x => x.Active).AsNoTracking().ToListAsync();
            return getAll;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return getById!;
        }
        public async Task<bool> RegisterAsync(T entity)
        {
            await _context.AddAsync(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public Task<bool> EditAsync(T entity)
        {
            throw new NotImplementedException();
        }



        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;
            if(filter != null) query = query.Where(filter);
            return query;
        }


        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request,IQueryable<TDTO> queryable,bool pagination = false) where TDTO: class
        {
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");
            if (pagination) queryDto = queryDto.Paginate(request);
            return queryDto;
        }
    }
}
