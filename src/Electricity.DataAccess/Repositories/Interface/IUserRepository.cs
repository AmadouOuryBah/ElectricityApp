

namespace Electricity.DataAccess.Repositories.Interface
{
    public interface IUser
    {
        public Task<User> LoginAsync(string username, string password);
    }
}
