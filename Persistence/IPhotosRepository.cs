using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCOREDEMO.Models;

namespace ASPNETCOREDEMO.Persistence
{
    public interface IPhotosRepository
    {
         Task<IEnumerable<Photo>> GetPhotos(int id);
    }
}