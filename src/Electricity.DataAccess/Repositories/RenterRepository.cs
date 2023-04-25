using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class RenterRepository : IGenericRepository<Renter>
    {
        public readonly DbSet<Renter> renters;

        public RenterRepository(ApplicationContext context) 
        {
            renters = context.Set<Renter>();
        }
        public void Add(Renter item)
        {
            renters.Add(item);
        }

        public void Delete(Renter item)
        {
            renters.Remove(item);
        }

        public Task<List<Renter>> GetAllAsync()
        {
            return renters
                .Include(renter => renter.Rooms)
                .ToListAsync();
        }

        public Task<Renter?> GetByIdAsync(int id)
        { 
            return renters.Include(renter => renter.Rooms)
                .Where(renter => renter.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Renter item)
        {
            renters.Update(item);
        }
    }
}
