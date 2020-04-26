using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class ZooDbContext : DbContext {
        public DbSet<ZooEntity> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            
        }
    }
}