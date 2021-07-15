using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Common;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class STKConfiguration : IEntityTypeConfiguration<STK>
    {
        public void Configure(EntityTypeBuilder<STK> builder)
        {
            builder.Property(s => s.ID).IsRequired();
            builder.HasKey(s => s.ID);

            builder.Property(s => s.MalAdi).HasMaxLength(50);
            builder.Property(s => s.MalKodu).IsRequired().HasMaxLength(30);
            builder.HasIndex(s=>s.MalKodu).IsUnique();
           
            builder.ToTable("STk");
        }
    }
}