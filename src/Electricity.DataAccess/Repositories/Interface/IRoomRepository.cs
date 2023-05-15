using Electricity.DataAccess.Entities;

namespace Electricity.DataAccess.Repositories.Interface
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetByRenterAsync(int id);
    }
}
