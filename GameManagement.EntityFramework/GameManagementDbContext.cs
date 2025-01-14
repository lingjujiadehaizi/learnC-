using System.Reflection;
using GameManagement.Entites;
using Microsoft.EntityFrameworkCore;

namespace GameManagement.EntityFramework
{
    public class GameManagementDbContext : DbContext
    {
        public GameManagementDbContext(DbContextOptions<GameManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Chatacters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
