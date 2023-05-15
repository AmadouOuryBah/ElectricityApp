

using Electricity.DataAccess.Entities;

namespace Electricity.DataAccess.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<User> LoginAsync(string username, string password);
    }
}
