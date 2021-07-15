using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Common;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class STIConfiguration : IEntityTypeConfiguration<STI>
    {
        public void Configure(EntityTypeBuilder<STI> builder)
        {
            builder.Property(s => s.ID).IsRequired();
            builder.HasKey(s => s.ID);

            builder.Property(s => s.EvrakNo).IsRequired().HasMaxLength(16);
            builder.Property(s => s.MalID).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Miktar).IsRequired().HasColumnType("decimal(25, 6)");
            builder.Property(s => s.Fiyat).IsRequired().HasColumnType("decimal(25, 6)");
            builder.Property(s => s.Tutar).IsRequired().HasColumnType("decimal(25, 6)");
            builder.Property(s => s.Birim).IsRequired().HasMaxLength(4);
            //Given DB schema isn't designed carefully so altered as below
            builder.HasOne<STK>(b => b.Mal)
                       .WithMany(b => b.Islemller)
                       .HasForeignKey(f => f.MalID);

            builder.ToTable("STI");
        }
    }
}