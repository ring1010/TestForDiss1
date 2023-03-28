using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace TestForDiss.Data
{
    // [NpgsqlMigrationAssembly("MyAssembly")]
    public class MyDbContext : DbContext
    {
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Plants> Plants { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Production> Production { get; set; }

        //public MyDbContext() : base("name=MyConnectionString")
        //{
        //}
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Countries>(entry => {
                entry.HasOne(r => r.Regions).WithMany(c => c.Countries)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_COUNTRY_REGION");
            }) ;
            modelBuilder.Entity<Plants>(entry => {
                entry.HasOne(r => r.Country).WithMany(c => c.Plants)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PLANT_COUNTRY");
            });
            modelBuilder.Entity<Production>(entry => {
                entry.HasOne(r => r.Plant).WithMany(c => c.Productions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Production_PLANT");
            });
        }

    }

        
}
