using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllAsync();
        Task<RoomDto> GetById(int id);
        Task<RoomDto> AddAsync(RoomRequest room);
        Task<RoomDto> UpdateAsync(RoomDto room);
        Task<string> DeleteAsync(int id);
        //Task<List<RoomElectricalEquipementEnergy>> GetEnergyConsumptionByRenter(int id);
    }
}
