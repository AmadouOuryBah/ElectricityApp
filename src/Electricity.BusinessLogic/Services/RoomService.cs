using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class RoomService : IRoomService
    {
        public readonly IRoomRepository _repository;
        public readonly IRoomRepository _roomRepository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;


        public RoomService(IRoomRepository repository,
           IMapper mapper,
           IUnitOfWork unitOfWork
,
           IRoomRepository roomRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _roomRepository = roomRepository;
        }

        public async Task<RoomDto> AddAsync(RoomRequest room)
        {
            var RoomMapped = _mapper.Map<Room>(room);

            _repository.Add(RoomMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RoomDto>(RoomMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
           var room =  await _repository.GetByIdAsync(id);

            _repository.Delete(room);
           await  _unitOfWork.SaveChangesAsync();
           
            return "room deleted ";
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var rooms = await _repository.GetAllAsync();

            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetById(int id)
        {
           var  room = await _repository.GetByIdAsync(id);

            return _mapper.Map<RoomDto>(room);
        }

      


        /// <summary>
        /// finding energy consumed by each device situated in a evry single room rented by a renter 
        /// </summary>
        /// <param name = "renterName" ></ param >
        /// < returns ></ returns >
        //public async Task<List<RoomElectricalEquipementEnergy>> GetEnergyConsumptionByRenter(int id)
        //{
        //    var rooms = await _roomRepository.GetByRenterAsync(id);
        //    List<RoomElectricalEquipementEnergy> roomElectricalEquipementEnergies = new();

        //    foreach (var room in rooms)
        //    {
        //        var roomDeviceEnergy = new RoomElectricalEquipementEnergy();

        //        roomDeviceEnergy.Name = room.Name;
        //        roomDeviceEnergy.Renter = room.Renter.Name;

        //        roomDeviceEnergy.RoomElectricalEquipements = new List<RoomElectricalEquipementDto>();
        //        int c = 0;

        //        foreach (var elec in roomDeviceEnergy.RoomElectricalEquipements)
        //        {
        //            roomDeviceEnergy.RoomElectricalEquipements[c].ElectricalEquipement.Name = elec.ElectricalEquipement.Name;
        //            roomDeviceEnergy.RoomElectricalEquipements[c].ElectricalEquipement.Coefficient = elec.ElectricalEquipement.Coefficient; 

        //            roomDeviceEnergy.RoomElectricalEquipements[c].ElectricalEquipement.Power = elec.ElectricalEquipement.Power;


        //            roomDeviceEnergy.EnergyConsumed = roomDeviceEnergy.RoomElectricalEquipements[c].ElectricalEquipement.Coefficient
        //                                               * roomDeviceEnergy.RoomElectricalEquipements[c].ElectricalEquipement.Power;



        //            roomElectricalEquipementEnergies.Add(roomDeviceEnergy);
        //            c++;
        //        }
        //    }

        //    return roomElectricalEquipementEnergies ;
        //}



        public async Task<RoomDto> UpdateAsync(RoomDto room)
        {
            var roomFound = await _repository.GetByIdAsync(room.Id);

            roomFound.Name = room.Name;
            roomFound.TotalWorkers = room.TotalWorkers;
            roomFound.RoomArea = room.RoomArea;
            roomFound.BuildingId = room.BuildingId;
            roomFound.RenterId = room.RenterId;
            roomFound.ScheduleId = room.ScheduleId;

            _repository.Update(roomFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RoomDto>(roomFound);

        }
    }
}
