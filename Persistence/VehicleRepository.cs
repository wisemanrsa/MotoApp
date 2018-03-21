using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Vehicle>> GetVehicles(VehicleQuery queryObj) {
            var query = context.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(vm => vm.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Contact)
                .AsQueryable();

            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name
            };

        
            if (queryObj.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == queryObj.MakeId.Value);

            query = ApplyOrdering(query, queryObj, columnsMap);
                           
            return await query.ToListAsync();
        }

        private IQueryable<Vehicle> ApplyOrdering(IQueryable<Vehicle> query, VehicleQuery queryObj, Dictionary<string, Expression<Func<Vehicle, object>>> columnsMap)
        {
            if (queryObj.SortBy != null) {
                if (queryObj.IsSortAscending) 
                    return query.OrderBy(columnsMap[queryObj.SortBy]);
                else
                    return query.OrderByDescending(columnsMap[queryObj.SortBy]); 
            }
            return query;
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