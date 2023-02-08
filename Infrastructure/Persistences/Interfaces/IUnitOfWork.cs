using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClubRepository Club { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
