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
        public readonly IGenericRepository<Room> _repository;
        public readonly IRoomRepository _roomRepository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;


        public RoomService(IGenericRepository<Room> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork,
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
           var room =  await _repository.GetByIdAsync(room.Id);

            _repository.Delete(room);
            _unitOfWork.SaveChangesAsync();
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
        /// finding energy consumed by each device situated in a  evry single room rented by a renter 
        /// </summary>
        /// <param name="renterName"></param>
        /// <returns></returns>
        //public async Task<List<EnergyDeviceResultDto>> GetEnergyConsumptionByRenter(string renterName)
        //{
        //   var rooms =  await _roomRepository.GetRoomsAsync(renterName);
        //    List<EnergyDeviceResultDto> electricalsPerRoom = new();

        //   foreach(var room in rooms)
        //   {
        //        var energy = new EnergyDeviceResultDto();
        //        energy.RoomName = room.NumberOfRoom;
        //        energy.RenterName = room.Renter.Name;
        //        energy.ElectricalMeters = new List<ElectricityMeterDto>();
        //        int c = 0;
        //        foreach (var elec in room.ElectricalMeters)
        //        {
        //            energy.ElectricalMeters[c].Name = elec.Name;
        //            energy.ElectricalMeters[c].Coefficient = elec.Coefficient; //Creer un nouvel objet avec total comme propriete
        //            energy.ElectricalMeters[c].NumberOfDevice = elec.NumberOfDevice;
        //            energy.ElectricalMeters[c].Power = elec.Power;
        //            energy.ElectricalMeters[c].Time = elec.Time;

        //            energy.EnergyCumsumed = energy.ElectricalMeters[c].Coefficient
        //                                     * energy.ElectricalMeters[c].NumberOfDevice
        //                                     * energy.ElectricalMeters[c].Power 
        //                                     * energy.ElectricalMeters[c].Time;

        //            electricalsPerRoom.Add(energy);
        //            c++;
        //        }
        //    }

        //    return electricalsPerRoom;
        //}


        public async Task<RoomDto> UpdateAsync(RoomDto room)
        {
            var roomFound = await _repository.GetByIdAsync(room.Id);

            roomFound.Name = room.Name;
            roomFound.Floor = room.Floor;
            roomFound.TotalWorkers = room.TotalWorkers;
            roomFound.RoomArea = room.RoomArea;
            roomFound.BuildingId = room.BuildingId;
            roomFound.RenterId = room.RenterId;

            _repository.Update(roomFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RoomDto>(roomFound);

        }
    }
}
