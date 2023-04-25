
using Electricity.DataAccess.Entities;

namespace Electricity.DataAccess.Repositories.Interface
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetRoomsAsync(string renterName);
    }
}
