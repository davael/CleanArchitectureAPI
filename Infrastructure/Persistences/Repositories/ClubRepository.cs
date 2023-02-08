using Domain.Entities;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistences.Repositories
{
    public class ClubRepository: GenericRepository<Club>, IClubRepository
    {
        private readonly ClubesContext _context;
        public ClubRepository( ClubesContext context)
        {
            _context = context;

        }
    }
}
