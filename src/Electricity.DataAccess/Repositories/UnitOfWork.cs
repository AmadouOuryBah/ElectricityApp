using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
