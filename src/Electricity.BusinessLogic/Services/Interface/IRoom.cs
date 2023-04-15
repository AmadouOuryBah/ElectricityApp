using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IRoom
    {
        Task<List<RoomDto>> GetAllAsync();
        Task<RoomDto> GetById(int id);
        Task<RoomDto> AddAsync(RoomRequest room);
        Task<RoomDto> UpdateAsync(int id, RoomRequest room);
        Task<string> DeleteAsync(int id);
    }
}
