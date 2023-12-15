using Marketer.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Chat> Chats => Set<Chat>();

        public DbSet<Interchange> Interchanges => Set<Interchange>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
        }
    }
}
