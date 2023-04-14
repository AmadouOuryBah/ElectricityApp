
namespace Electricity.DataAccess.Repositories.Interface
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
