using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class RoomElectricalEquipementRepository 
        : IGenericRepository<RoomElectricalEquipement>
    {
        public readonly DbSet<RoomElectricalEquipement> _roomElectricalEquipementRepositories;

        public RoomElectricalEquipementRepository(ApplicationContext context)
        {
            _roomElectricalEquipementRepositories = context.Set<RoomElectricalEquipement>();
        }
        public void Add(RoomElectricalEquipement item)
        {
            _roomElectricalEquipementRepositories.Add(item);
        }

        public void Delete(RoomElectricalEquipement item)
        {
            _roomElectricalEquipementRepositories.Remove(item);
        }

        public Task<List<RoomElectricalEquipement>> GetAllAsync()
        {
           return _roomElectricalEquipementRepositories
                 .Include(e => e.Room)
                 .Include(e => e.ElectricalEquipement)
                .ToListAsync();
        }

        public Task<RoomElectricalEquipement?> GetByIdAsync(int id)
        {
          return  _roomElectricalEquipementRepositories
                  .Include(e => e.Room)
                  .Include(e => e.ElectricalEquipement)
                  .Where(e => e.Id == id)
                  .FirstOrDefaultAsync();
        }


        public void Update(RoomElectricalEquipement item)
        {
            _roomElectricalEquipementRepositories.Update(item);
        }
    }
}
