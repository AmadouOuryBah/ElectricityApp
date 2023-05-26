using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess.Repositories
{
    public class UserRepository : IGenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationContext context)
        {
            _users = context.Set<User>();
        }


        public void Add(User item)
        {
            _users.Add(item);
        }

        public void Delete(User item)
        {
            _users.Remove(item);
        }

        public Task<List<User>> GetAllAsync()
        {
           return  _users.ToListAsync();
        }

        public Task<User?> GetByIdAsync(int id)
        {

          return  _users.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<User?> LoginAsync(string username, string password)
        {
           return  _users.Include(user => user.Role)
                         .Where(user => user.Username == username && user.Password == password)
                         .FirstOrDefaultAsync();
        }

        public void Update(User item)
        {
            _users.Update(item);
        }
    }
}
