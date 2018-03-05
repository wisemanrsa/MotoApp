using System.Threading.Tasks;

namespace ASPNETCOREDEMO.Persistence
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}