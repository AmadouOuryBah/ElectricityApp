using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Electricity.DataAccess.Repositories
{
    public class BuildingRepository : IGenericRepository<Building>
    {
        DbSet<Building> buildings;

        public BuildingRepository(ApplicationContext context)
        {
            buildings = context.Set<Building>();
        }

        public void Add(Building item)
        {
            buildings.Add(item);
        }

        public void Delete(Building item)
        {
            buildings.Remove(item);
        }

        public Task<List<Building>> GetAllAsync()
        {
            return buildings
                .Include(building => building.Rooms)
                .Include(building => building.ElectricityMeter)
                .Include(building => building.HeatMeter)
                .Include(building => building.WaterMeter)
                .ToListAsync();
        }

        public Task<Building?> GetByIdAsync(int id)
        {
            return buildings.Include(building => building.Rooms)
                .Where(building => building.Id == id)
                .Include(building => building.ElectricityMeter)
                .Include(building => building.HeatMeter)
                .Include(building => building.WaterMeter)
                .FirstOrDefaultAsync();
        }

        public void Update(Building item)
        {
            buildings.Update(item);
        }
    }
}
