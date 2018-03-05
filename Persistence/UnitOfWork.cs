using System.Threading.Tasks;

namespace ASPNETCOREDEMO.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MotoDbContext context;
        public UnitOfWork(MotoDbContext context)
        {
            this.context = context;
        }
        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }
    }
}