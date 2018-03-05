using System.Threading.Tasks;
using ASPNETCOREDEMO.Models;

namespace ASPNETCOREDEMO.Persistence
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
         void Add(Vehicle vehicle);
         void Remove(Vehicle vehicle);
    }
}