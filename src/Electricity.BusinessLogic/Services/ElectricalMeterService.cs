using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Exceptions;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class ElectricalMeterService : IElectricalMeter
    {

        public readonly IGenericRepository<ElectricalMeter> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public ElectricalMeterService(IGenericRepository<ElectricalMeter> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ElectricalMeterDto> AddAsync(ElectricalMeterRequest electrical)
        {
            var electricalMapped = _mapper.Map<ElectricalMeter>(electrical);

            _repository.Add(electricalMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ElectricalMeterDto>(electricalMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
            var electricalMeter = await GetByIdAsync(id);
            _repository.Delete(electricalMeter);
            await _unitOfWork.SaveChangesAsync();

            return "electricalMeter has been deleted";
        }

        private async Task<ElectricalMeter> GetByIdAsync(int id)
        {
            var electricalMeter = await _repository.GetByIdAsync(id);

            if (electricalMeter is not null)
                return electricalMeter;
            //Todo: don't handle your exception like in the api here you will use a component(view )
            //and you will handle it in the controller!!!

            throw new NotFoundException("electricalMeter with this id does not exist");
        }

        public async Task<List<ElectricalMeterDto>> GetAllAsync()
        {
            var electricalMeters = await _repository.GetAllAsync();

            return _mapper.Map<List<ElectricalMeterDto>>(electricalMeters);
        }

        public async Task<ElectricalMeterDto> UpdateAsync(int id, ElectricalMeterRequest electrical)
        {
            var electricalMeterFound = await GetByIdAsync(id);

            electricalMeterFound.Name = electrical.Name;
            electricalMeterFound.NumberOfDevice = electrical.NumberOfDevice;
            electricalMeterFound.Power = electrical.Power;
            electrical.RoomId = electrical.RoomId;
    
            _repository.Update(electricalMeterFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ElectricalMeterDto>(electricalMeterFound);
        }
    }
}
