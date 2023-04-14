using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class ElectricalEquipmentRepository : IGenericRepository<ElectricalEquipment>
    {
        public readonly DbSet<ElectricalEquipment> electricalEquipements;
        
        public ElectricalEquipmentRepository(ApplicationContext context)
        {
            electricalEquipements = context.Set<ElectricalEquipment>();
        }

        public void Add(ElectricalEquipment item)
        {
            electricalEquipements.Add(item);
        }


        public void Delete(ElectricalEquipment item)
        {
            electricalEquipements.Remove(item);
        }

        public Task<List<ElectricalEquipment>> GetAllAsync()
        {
            return electricalEquipements.ToListAsync();
        }

        public Task<ElectricalEquipment?> GetByIdAsync(int id)
        {
            return electricalEquipements
                .Where(eEquipment => eEquipment.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(ElectricalEquipment item)
        {
            electricalEquipements.Update(item);
        }
    }
}
