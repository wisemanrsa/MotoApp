using ASPNETCOREDEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREDEMO.Persistence
{
    public class MotoDBContext : DbContext
    {
        DbSet<Make> Makes {get; set;}
        DbSet<Model> Models {get; set;}
        public MotoDBContext(DbContextOptions<MotoDBContext> options)
            :base(options)
        {
           
        }
    }
}