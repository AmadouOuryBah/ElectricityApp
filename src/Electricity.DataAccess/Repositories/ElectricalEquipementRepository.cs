using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class ElectricalEquipementRepository : IGenericRepository<ElectricalEquipement>
    {
        public readonly DbSet<ElectricalEquipement> electricalEquipements;
        
        public ElectricalEquipementRepository(ApplicationContext context)
        {
            electricalEquipements = context.Set<ElectricalEquipement>();
        }

        public void Add(ElectricalEquipement item)
        {
            electricalEquipements.Add(item);
        }


        public void Delete(ElectricalEquipement item)
        {
            electricalEquipements.Remove(item);
        }

        public Task<List<ElectricalEquipement>> GetAllAsync()
        {
            return electricalEquipements
                
                .ToListAsync();
        }

        public Task<ElectricalEquipement?> GetByIdAsync(int id)
        {
            return electricalEquipements
                .Where(eEquipment => eEquipment.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(ElectricalEquipement item)
        {
            electricalEquipements.Update(item);
        }
    }
}
