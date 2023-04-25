

using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IRoomElectricalEquipementService
    {
        Task<List<RoomElectricalEquipementDto>> GetAllAsync();
        Task<RoomElectricalEquipementDto> GetById(int id);
        Task<RoomDto> AddAsync(RoomElectricalEquipementRequest item);
        Task<RoomElectricalEquipementDto> UpdateAsync(RoomElectricalEquipementDto item);
        Task<string> DeleteAsync(int id);
    }
}
