using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class WaterMeterRepository : IGenericRepository<WaterMeter>
    {
        private readonly DbSet<WaterMeter> _waterMeters;

        public WaterMeterRepository(ApplicationContext context)
        {
            _waterMeters = context.Set<WaterMeter>();
        }
        public void Add(WaterMeter item)
        {
            _waterMeters.Add(item);
        }

        public void Delete(WaterMeter item)
        {
            _waterMeters.Remove(item);
        }

        public Task<List<WaterMeter>> GetAllAsync()
        {
           return  _waterMeters.Include(e => e.Building).ToListAsync();
        }

        public Task<WaterMeter?> GetByIdAsync(int id)
        {
            return _waterMeters.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public void Update(WaterMeter item)
        {
            _waterMeters.Update(item);
        }
    }
}
