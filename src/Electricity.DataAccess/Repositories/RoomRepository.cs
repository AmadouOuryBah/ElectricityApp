using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace Electricity.DataAccess.Repositories
{
    public class RoomRepository : IGenericRepository<Room>
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

        public void Update(Room item)
        {
            rooms.Update(item);
        }
    }
}
