using Marketer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketer.Configurations
{
    public class InterchangeConfig : IEntityTypeConfiguration<Interchange>
    {
        public void Configure(EntityTypeBuilder<Interchange> builder)
        {
            builder.HasOne(x => x.Chat)
           .WithMany(x => x.Interchanges)
           .HasForeignKey(x => x.ChatId);
        }
    }
}
