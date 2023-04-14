

namespace Electricity.DataAccess.Repositories.Interface
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
