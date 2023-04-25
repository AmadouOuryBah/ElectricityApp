
using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class RoomElectricalEquipementService : IRoomElectricalEquipementService
    {
        public readonly IGenericRepository<Renter> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public RoomElectricalEquipementService(IGenericRepository<RoomElectricalEquipement> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomElectricalEquipementDto> AddAsync(RoomElectricalEquipementDto item)
        {
            var roomMapped = _mapper.Map<Room>(item);

            _repository.Add(roomMapped);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RoomElectricalEquipementDto>(roomMapped);
        }

        public async  Task<string> DeleteAsync(int id)
        {
            var roomEkipement = await _repository.GetByIdAsync(id);

            _repository.Delete(roomEkipement);
            await _unitOfWork.SaveChangesAsync();

            return "room deleted ";
        }

        public async  Task<List<RoomElectricalEquipementDto>> GetAllAsync()
        {
            var roomEkipmnts = await _repository.GetAllAsync();

            return _mapper.Map<List<RoomDto>>(roomEkipmnts);
        }

        public async Task<RoomElectricalEquipementDto> GetById(int id)
        {
            var roomEkipmnt = await _repository.GetByIdAsync(id);

            return _mapper.Map<RoomElectricalEquipementDto>(roomEkipmnt);
        }

        public  async Task<RoomElectricalEquipementDto> UpdateAsync(RoomElectricalEquipementDto item)
        {
            var roomEkipmntFound = await _repository.GetByIdAsync(item.Id);

            roomEkipmntFound.RoomId = item.RoomId;
            roomEkipmntFound.ElectricalEquipementId = item.ElectricalEquipementId;
            roomEkipmntFound.WorkingTime = item.WorkingTime;
            
           
            _repository.Update(roomEkipmntFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RoomElectricalEquipementDto>(roomEkipmntFound);
        }
    }
}
