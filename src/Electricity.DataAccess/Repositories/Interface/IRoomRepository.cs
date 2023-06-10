using Electricity.DataAccess.Entities;

namespace Electricity.DataAccess.Repositories.Interface
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<List<Room>> GetRoomsByBuilding(int buildingId);
    }
}
