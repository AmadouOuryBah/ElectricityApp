
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetById(int id);
        Task<UserDto> AddAsync(UserRequest user);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<string> DeleteAsync(int id);
        Task AuthenticateAsync(string username, string role);
        Task Register(UserRequest user);

        Task Login(UserRequest user);
    }
}
