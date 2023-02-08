using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistences.Contexts
{
    public class ClubesContext: DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Court> Courts { get; set; }
    }
}
