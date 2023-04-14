using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;



namespace Electricity.DataAccess.Repositories
{
    public class ElectricalMeterRepository : IGenericRepository<ElectricalMeter>
    {
        public readonly DbSet<ElectricalMeter> electricalMeters;

        public ElectricalMeterRepository(ApplicationContext context)
        {
            electricalMeters = context.Set<ElectricalMeter>();
        }

        public void Add(ElectricalMeter item)
        {
            electricalMeters.Add(item);
        }

        public void Delete(ElectricalMeter item)
        {
            electricalMeters.Remove(item);
        }

        public Task<List<ElectricalMeter>> GetAllAsync()
        {
            return electricalMeters.Include(e => e.Room)
                .ToListAsync();
        }

        public Task<ElectricalMeter?> GetByIdAsync(int id)
        {
            return electricalMeters
                .Include(elecMeter => elecMeter.Room)
                .Where(elecMeter => elecMeter.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(ElectricalMeter item)
        {
            electricalMeters.Update(item);
        }


    }
}
