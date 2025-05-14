using Microsoft.EntityFrameworkCore;
using FruitApi.Models;

namespace FruitApi.Data {
    public class FruitContext : DbContext {
        public FruitContext(DbContextOptions<FruitContext> options) : base(options) {}
        public DbSet<Fruit> Fruits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasSequence<int>("FRUIT_SEQ", schema: "SYSTEM").StartsAt(1).IncrementsBy(1);
            modelBuilder.Entity<Fruit>().Property(f => f.Id).HasDefaultValueSql("FRUIT_SEQ.NEXTVAL");
        }
    }
}