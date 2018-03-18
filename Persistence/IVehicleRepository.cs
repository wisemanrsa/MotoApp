using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCOREDEMO.Controllers.Resources;
using ASPNETCOREDEMO.Models;

namespace ASPNETCOREDEMO.Persistence
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
         void Add(Vehicle vehicle);
         void Remove(Vehicle vehicle);
         Task<IEnumerable<Vehicle>> GetVehicles(VehicleQuery filter);
    }
}