using Marketer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketer.Configurations
{
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            //builder.HasMany(e => e.Interchanges)
            //    .WithOne()
            //    .HasForeignKey(e => e.ChatId);

            builder.HasOne(x => x.User)
            .WithMany(x => x.Chats)
            .HasForeignKey(x => x.UserId);
        }
    }
}
