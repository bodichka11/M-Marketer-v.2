using Marketer.BaseEntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Marketer.Data
{
    public static class ModelBuilderExtentions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig<long>).Assembly);
        }
    }
}
