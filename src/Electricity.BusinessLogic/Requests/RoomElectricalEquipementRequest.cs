

namespace Electricity.BusinessLogic.Requests
{
    public class RoomElectricalEquipementRequest
    {
        Task<List<RoomElectricalEquipementDto>> GetAllAsync();
        Task<RoomElectricalEquipementDto> GetById(int id);
        Task<RoomElectricalEquipementDto> AddAsync(RoomElectricalEquipementRequest roomEkipmnt);
        Task<RoomElectricalEquipementDto> UpdateAsync(RoomElectricalEquipementRequest roomEkipmnt);
        Task<string> DeleteAsync(int id);
    }
}
