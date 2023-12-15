using Marketer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketer.BaseEntityConfig
{
    public class EntityConfig<T> : IEntityTypeConfiguration<Entity<T>> where T : struct
    {
        public void Configure(EntityTypeBuilder<Entity<T>> builder)
        {
            builder.Property(e =>e.Id)
                .ValueGeneratedOnAdd() ;
        }
    }
}
