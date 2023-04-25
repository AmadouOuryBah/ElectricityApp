using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Exceptions;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class ElectricalEquipementService : IElectricityEquipement
    {

        public readonly IGenericRepository<ElectricalEquipment> _genericRepository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public ElectricalEquipementService(IGenericRepository<ElectricalEquipment> genericRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ElectricalEquipementDto> AddAsync(ElectricalEquipementRequest electricalEquipmnt)
        {
            var deviceMapped = _mapper.Map<ElectricalEquipment>(electricalEquipmnt);

            _genericRepository.Add(deviceMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ElectricalEquipementDto>(deviceMapped);

        }

        public async Task<string> DeleteAsync(int id)
        {
            var device = await GetByIdAsync(id);
            _genericRepository.Delete(device);
            await _unitOfWork.SaveChangesAsync();

            return "device has been deleted";
        }

        public async Task<List<ElectricalEquipementDto>> GetAllAsync()
        {
            var devices = await _genericRepository.GetAllAsync();

            return _mapper.Map<List<ElectricalEquipementDto>>(devices);
        }

        public async Task<ElectricalEquipementDto> UpdateAsync(int id, ElectricalEquipementRequest electriqEquimnt)
        {
            var deviceFound = await GetByIdAsync(id);

            deviceFound.Name = electriqEquimnt.Name;
            deviceFound.Power = electriqEquimnt.Power;
            deviceFound.Coefficient = electriqEquimnt.Coefficient;

            _genericRepository.Update(deviceFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ElectricalEquipementDto>(deviceFound);
        }

        private async Task<ElectricalEquipment> GetByIdAsync(int id)
        {
            var deviceFound = await _genericRepository.GetByIdAsync(id);

            if (deviceFound is not null)
                return deviceFound;

            throw new NotFoundException("electricalEquipment with this id does not exist");
        }
    }

   
    
}
