using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class ScheduleRepository : IGenericRepository<Schedule>
    {
        private readonly DbSet<Schedule> _schedules;

        public ScheduleRepository(ApplicationContext context)
        {
            _schedules = context.Set<Schedule>();
        }
        public void Add(Schedule item)
        {
            _schedules.Add(item);
        }

        public void Delete(Schedule item)
        {
            _schedules.Remove(item);
        }

        public Task<List<Schedule>> GetAllAsync()
        {
           return _schedules.Include(e => e.Room)
                .ThenInclude(b => b.Building).ToListAsync();

        }

        public Task<Schedule> GetByIdAsync(int id)
        {
            return _schedules.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Schedule item)
        {
            _schedules.Update(item);
        }
    }
}
