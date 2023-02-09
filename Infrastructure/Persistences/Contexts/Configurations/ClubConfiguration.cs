using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistences.Contexts.Configurations
{
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.ToTable("Club");
            builder.HasKey(c => c.ClubID);
            builder.Property(c => c.ClubID).UseIdentityColumn();
            builder.Property(c => c.ClubDes).IsRequired();
            builder.Property(c => c.Active).IsRequired().HasDefaultValue(true);                                   
        }
    }
}
