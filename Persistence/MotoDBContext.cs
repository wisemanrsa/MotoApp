using ASPNETCOREDEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREDEMO.Persistence
{
    public class MotoDbContext : DbContext
    {
        public DbSet<Make> Makes {get; set;}
        public DbSet<Model> Models {get; set;}
        public DbSet<Feature> Features {get; set;}
        public MotoDbContext(DbContextOptions<MotoDbContext> options)
            :base(options)
        {
           
        }
    }
}