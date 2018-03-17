using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCOREDEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREDEMO.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly MotoDbContext context;
        public VehicleRepository(MotoDbContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<Vehicle>> GetVehicles() {
            return await context.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(vm => vm.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Contact)
                .ToListAsync();
        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {

            if (!includeRelated) return await context.Vehicles.FindAsync(id);
            return await context.Vehicles
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Contact)
                .Include(v => v.Model)
                    .ThenInclude(vm => vm.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }
        public void Remove(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
        }
    }
}