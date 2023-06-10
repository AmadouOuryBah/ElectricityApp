using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace Electricity.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public readonly DbSet<Room> rooms; 

        public RoomRepository(ApplicationContext context)
        {
            rooms = context.Set<Room>(); 
        }

        public void Add(Room item)
        {
            rooms.Add(item);
        }

        public void Delete(Room item)
        {
            rooms.Remove(item);
        }

        public Task<List<Room>> GetRoomsByBuilding(int buildingId)
        {
            return rooms.Include(room => room.Building)
                 .Include(room => room.Renter)
                 .Include(room => room.Schedule)
                 .Where(room => room.BuildingId == buildingId)
                 .ToListAsync();
        }

        public Task<List<Room>> GetAllAsync()
        {
            return rooms.Include(room => room.Renter)
                .Include(room => room.Building)
                .Include(room => room.Schedule)
                .ToListAsync();
        }

        public Task<Room?> GetByIdAsync(int id)
        {
            return rooms.Include(room => room.Building)
                .Include(room => room.Renter)
                .Include(room => room.Schedule)
                .Where(room => room.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<List<Room>> GetByRenterAsync(int id)
        {
            return rooms
                  .Include(e => e.RoomElectricalEquipements)
                  .Include(e => e.Renter)
                  .Where(e => e.Id == id)
                  .ToListAsync();
        }
       

        public void Update(Room item)
        {
            rooms.Update(item);
        }
    }
}
