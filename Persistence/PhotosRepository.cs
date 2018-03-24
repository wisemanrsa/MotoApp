using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCOREDEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREDEMO.Persistence
{
    public class PhotosRepository : IPhotosRepository
    {
        private readonly MotoDbContext context;
        public PhotosRepository(MotoDbContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<Photo>> GetPhotos(int id)
        {
            return await context.Photos.Where(p => p.VehicleId == id).ToListAsync();
        }
    }
}