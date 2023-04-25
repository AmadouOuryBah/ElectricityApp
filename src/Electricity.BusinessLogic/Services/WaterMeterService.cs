
using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class WaterMeterService : IWaterMeterService
    {
        public readonly IGenericRepository<WaterMeter> _repository;
       
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public WaterMeterService(IGenericRepository<WaterMeter> repository, IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<WaterMeterDto> AddAsync(WaterMeterRequest item)
        {
            var waterMeterMapped = _mapper.Map<WaterMeter>(item);

            _repository.Add(waterMeterMapped);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<WaterMeterDto>(waterMeterMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
            var waterMeter = await _repository.GetByIdAsync(id);

            _repository.Delete(waterMeter);
            await _unitOfWork.SaveChangesAsync();

            return " deleted ";
        }

        public  async Task<List<WaterMeterDto>> GetAllAsync()
        {
            var waterMeters = await _repository.GetAllAsync();

            return _mapper.Map<List<WaterMeterDto>>(waterMeters);
        }

        public async Task<WaterMeterDto> GetById(int id)
        {
            var waterMeter = await _repository.GetByIdAsync(id);

            return _mapper.Map<WaterMeterDto>(waterMeter);
        }

        public async Task<WaterMeterDto> UpdateAsync(WaterMeterDto item)
        {
            var waterMeterFound = await _repository.GetByIdAsync(item.Id);

            waterMeterFound.Name = item.Name;
            waterMeterFound.FactoryNumber = item.FactoryNumber;

            _repository.Update(waterMeterFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<WaterMeterDto>(waterMeterFound);
        }
    }
}
