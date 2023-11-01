using Domain.Core.Entities;
using Infraestructure.Map;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TradeMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TradeEntity> Trades { get; set; }
    }
}
