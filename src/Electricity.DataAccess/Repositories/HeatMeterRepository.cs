using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class HeatMeterRepository : IGenericRepository<HeatMeter>
    {
        public readonly DbSet<HeatMeter> heatMeters;

        public HeatMeterRepository(ApplicationContext context)
        {
            heatMeters = context.Set<HeatMeter>();
        }

        public void Add(HeatMeter item)
        {
            heatMeters.Add(item);
        }

        public void Delete(HeatMeter item)
        {
            heatMeters.Remove(item);
        }

        public Task<List<HeatMeter>> GetAllAsync()
        {
            return heatMeters
                .Include(e => e.Building)
                .ToListAsync();
        }

        public Task<HeatMeter?> GetByIdAsync(int id)
        {
            return heatMeters
                .Include(e => e.Building)
                .Where(heatMeters => heatMeters.Id == id).FirstOrDefaultAsync();
        }

        public void Update(HeatMeter item)
        {
            heatMeters.Update(item);
        }
    }
}
