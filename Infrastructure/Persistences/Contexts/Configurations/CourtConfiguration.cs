using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistences.Contexts.Configurations
{
    public class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(EntityTypeBuilder<Court> builder)
        {
            builder.ToTable("Court");
            builder.HasKey(c => new {c.CourtId,c.ClubID});
            builder.Property(c => c.CourtId).UseIdentityColumn();
            builder.Property(c => c.CourtDes).IsRequired();
            builder.Property(c => c.Active).IsRequired().HasDefaultValue(true);
            builder.HasOne<Club>(c => c.Club)
                .WithMany(g => g.Courts)
                .HasForeignKey(c => c.ClubID);
        }
    }
}
