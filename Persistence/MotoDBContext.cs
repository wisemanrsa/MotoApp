using ASPNETCOREDEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREDEMO.Persistence
{
    public class MotoDbContext : DbContext
    {
        public DbSet<Make> Makes {get; set;}
        public DbSet<Model> Models {get; set;}
        public DbSet<Feature> Features {get; set;}
        public DbSet<Vehicle> Vehicles {get; set;}
        public DbSet<Photo> Photos {get; set;}
        public MotoDbContext(DbContextOptions<MotoDbContext> options)
            :base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(vf => new {vf.VehicleId, vf.FeatureId});
        }
    }
}