

using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.DataAccess.Entities;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IRoomElectricalEquipementService
    {
        Task<List<RoomElectricalEquipementDto>> GetAllAsync();
        Task<RoomElectricalEquipementDto> AddAsync(RoomElectricalEquipementRequest item);
        Task<RoomElectricalEquipementDto> UpdateAsync( RoomElectricalEquipementDto item);
        Task<string> DeleteAsync(int id);
    }
}
