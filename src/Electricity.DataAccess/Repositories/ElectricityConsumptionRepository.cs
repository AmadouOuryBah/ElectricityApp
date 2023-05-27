using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;



namespace Electricity.DataAccess.Repositories
{
    public class ElectricityConsumptionRepository : IGenericRepository<ElectricityConsumptionDto>
    {
        public readonly DbSet<ElectricityConsumptionDto> electricityConsumptions;

        public ElectricityConsumptionRepository(ApplicationContext context)
        {
            electricityConsumptions = context.Set<ElectricityConsumptionDto>();
        }

        public void Add(ElectricityConsumptionDto item)
        {
            electricityConsumptions.Add(item);
        }

        public void Delete(ElectricityConsumptionDto item)
        {
            electricityConsumptions.Remove(item);
        }

        public Task<List<ElectricityConsumptionDto>> GetAllAsync()
        {
            return electricityConsumptions
                .Include(e => e.Building)
                .ToListAsync();
        }

        public Task<ElectricityConsumptionDto?> GetByIdAsync(int id)
        {
            return electricityConsumptions
                .Include(e => e.Building)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(ElectricityConsumptionDto item)
        {
            electricityConsumptions.Update(item);
        }


    }
}
