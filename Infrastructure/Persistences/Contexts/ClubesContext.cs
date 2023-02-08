using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistences.Contexts
{
    public class ClubesContext : DbContext
    {
        public ClubesContext() { }

        public ClubesContext(DbContextOptions<ClubesContext> options) : base(options){}
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Court> Courts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
