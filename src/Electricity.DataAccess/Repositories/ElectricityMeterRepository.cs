using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;



namespace Electricity.DataAccess.Repositories
{
    public class ElectricityMeterRepository : IGenericRepository<ElectricityMeter>
    {
        public readonly DbSet<ElectricityMeter> electricalMeters;

        public ElectricityMeterRepository(ApplicationContext context)
        {
            electricalMeters = context.Set<ElectricityMeter>();
        }

        public void Add(ElectricityMeter item)
        {
            electricalMeters.Add(item);
        }

        public void Delete(ElectricityMeter item)
        {
            electricalMeters.Remove(item);
        }

        public Task<List<ElectricityMeter>> GetAllAsync()
        {
            return electricalMeters
                .Include(e => e.Building)
                .ToListAsync();
        }

        public Task<ElectricityMeter?> GetByIdAsync(int id)
        {
            return electricalMeters
                .Include(e => e.Building)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(ElectricityMeter item)
        {
            electricalMeters.Update(item);
        }


    }
}
