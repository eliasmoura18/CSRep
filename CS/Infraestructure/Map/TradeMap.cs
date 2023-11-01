using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Map
{
    public class TradeMap : IEntityTypeConfiguration<TradeEntity>
    {
        public void Configure(EntityTypeBuilder<TradeEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClientSector).IsRequired().HasMaxLength(8);
        }
    }
}
