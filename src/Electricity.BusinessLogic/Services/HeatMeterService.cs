using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public  class HeatMeterService : IHeatMeterService
    {
        public readonly IGenericRepository<HeatMeter> _repository;

        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public HeatMeterService(IGenericRepository<HeatMeter> repository, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<HeatMeterDto> AddAsync(HeatMeterRequest heatMeter)
        {
            var heatMeterMapped = _mapper.Map<HeatMeter>(heatMeter);

            _repository.Add(heatMeterMapped);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<HeatMeterDto>(heatMeterMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
            var heatMeter = await _repository.GetByIdAsync(id);

            _repository.Delete(heatMeter);
            await _unitOfWork.SaveChangesAsync();

            return " deleted ";
        }

        public async Task<List<HeatMeterDto>> GetAllAsync()
        {
            var heatMeters = await _repository.GetAllAsync();

            return _mapper.Map<List<HeatMeterDto>>(heatMeters);
        }

        public async  Task<HeatMeterDto> GetById(int id)
        {
            var heatMeter = await _repository.GetByIdAsync(id);

            return _mapper.Map<HeatMeterDto>(heatMeter);
        }

        public async Task<HeatMeterDto> UpdateAsync(HeatMeterDto heatMeter)
        {
            var heatMeterFound = await _repository.GetByIdAsync(heatMeter.Id);

            heatMeterFound.Name = heatMeter.Name;
            heatMeterFound.FactoryNumber = heatMeter.FactoryNumber;

            _repository.Update(heatMeterFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<HeatMeterDto>(heatMeterFound);
        }
    }
}
