using AutoMapper;
using Electricity.BusinessLogic.DTO_s;

using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class ElectricityMeterService : IElectricityMeterService
    {

        public readonly IGenericRepository<ElectricityMeter> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public ElectricityMeterService(IGenericRepository<ElectricityMeter> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ElectricityMeterDto> AddAsync(ElectricityMeterRequest electrical)
        {
            var electricityMapped = _mapper.Map<ElectricityMeter>(electrical);

            _repository.Add(electricityMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ElectricityMeterDto>(electricityMapped);
        }

        public async Task DeleteAsync(int id)
        {
            var electricalMeter = await GetByIdAsync(id);

            _repository.Delete(electricalMeter);

            await _unitOfWork.SaveChangesAsync();           
        }

        private async Task<ElectricityMeter> GetByIdAsync(int id)
        {
            var electricityMeter = await _repository.GetByIdAsync(id);

            return electricityMeter;
        
        }

        public async Task<List<ElectricityMeterDto>> GetAllAsync()
        {
            var electricityMeters = await _repository.GetAllAsync();

            return _mapper.Map<List<ElectricityMeterDto>>(electricityMeters);
        }

        public async Task<ElectricityMeterDto> UpdateAsync( ElectricityMeterDto electricityMeter)
        {
            var electricityMeterFound = await GetByIdAsync(electricityMeter.Id);

            electricityMeterFound.Name = electricityMeter.Name;
            electricityMeterFound.FactoryNumber = electricityMeter.FactoryNumber;
           
            _repository.Update(electricityMeterFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ElectricityMeterDto>(electricityMeterFound);
        }

       public  async Task<ElectricityMeterDto> GetById(int id)
        {
            var electricityMeter = await GetByIdAsync(id);

            return _mapper.Map<ElectricityMeterDto>(electricityMeter);
        }
    }
}
