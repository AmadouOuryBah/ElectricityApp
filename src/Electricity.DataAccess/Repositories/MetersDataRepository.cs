
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class MetersDataRepository : IGenericRepository<MetersData>
    {
        DbSet<MetersData> metersDatas;

        public MetersDataRepository(ApplicationContext context)
        {
            metersDatas = context.Set<MetersData>();
        }

        public void Add(MetersData item)
        {
            metersDatas.Add(item);
        }

        public void Delete(MetersData item)
        {
           metersDatas.Remove(item);
        }

        public Task<List<MetersData>> GetAllAsync()
        {
           return  metersDatas.ToListAsync();
        }

        public Task<MetersData?> GetByIdAsync(int id)
        {
            return metersDatas.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public void Update(MetersData item)
        {
            metersDatas.Update(item);
        }
    }
}
