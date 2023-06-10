using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;



namespace Electricity.DataAccess.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        public readonly DbSet<Resource> resources;

        public ResourceRepository(ApplicationContext context)
        {
            resources = context.Set<Resource>();
        }

        public void Add(Resource item)
        {
            resources.Add(item);
        }

        public void Delete(Resource item)
        {
            resources.Remove(item);
        }

        public Task<List<Resource>> GetAllAsync()
        {
            return resources
                .Include(e => e.Building)
                .ToListAsync();
        }

        public Task<Resource?> GetByIdAsync(int id)
        {
            return resources
                .Include(e => e.Building)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<double> GetResourceQtity(int year, int month, string resourceType)
        {
            return  resources
                .Where(u => u.ResourceType == resourceType && u.Month == month && u.Year == year)
                .Select(u => u.Quantity)
                .SingleOrDefaultAsync(); 
        }

        public void Update(Resource item)
        {
            resources.Update(item);
        }


    }
}
