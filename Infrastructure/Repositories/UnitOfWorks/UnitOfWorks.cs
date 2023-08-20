using Application.Interfaces.Repositories.Generic;
using Application.Interfaces.Repositories.UnitOfWorks;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly SocialMediaContext _context;
        public IGenericRepository<Usuario> Usuario { get; private set; }

        public UnitOfWorks(SocialMediaContext context)
        {
            _context = context;
            Usuario= new GenericRepository<Usuario>(_context);
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
