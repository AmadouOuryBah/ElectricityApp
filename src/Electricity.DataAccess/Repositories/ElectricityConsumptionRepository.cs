using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;



namespace Electricity.DataAccess.Repositories
{
    public class ElectricityConsumptionRepository : IGenericRepository<ElectricityConsumption>
    {
        public readonly DbSet<ElectricityConsumption> electricityConsumptions;

        public ElectricityConsumptionRepository(ApplicationContext context)
        {
            electricityConsumptions = context.Set<ElectricityConsumption>();
        }

        public void Add(ElectricityConsumption item)
        {
            electricityConsumptions.Add(item);
        }

        public void Delete(ElectricityConsumption item)
        {
            electricityConsumptions.Remove(item);
        }

        public Task<List<ElectricityConsumption>> GetAllAsync()
        {
            return electricityConsumptions
                .Include(e => e.Building)
                .ToListAsync();
        }

        public Task<ElectricityConsumption?> GetByIdAsync(int id)
        {
            return electricityConsumptions
                .Include(e => e.Building)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(ElectricityConsumption item)
        {
            electricityConsumptions.Update(item);
        }


    }
}
