using Application.Interfaces.Repositories.Generic;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.UnitOfWorks
{
    public interface IUnitOfWorks : IDisposable
    {
        IGenericRepository<Usuario> Usuario { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
