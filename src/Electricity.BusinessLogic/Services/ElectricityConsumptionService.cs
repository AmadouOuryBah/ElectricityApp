

using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories;
using Electricity.DataAccess.Repositories.Interface;
using System.Diagnostics.Metrics;

namespace Electricity.BusinessLogic.Services
{
    public class ElectricityConsumptionService : IElectricityConsumptionService
    {
        private readonly ElectricityConsumptionRepository  _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public ElectricityConsumptionService(ElectricityConsumptionRepository electricityConsumptionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = electricityConsumptionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DTO_s.ElectricityConsumptionDto> AddAsync(ElectricityConsumptionRequest electricity)
        {
            var electricityMapped = _mapper.Map<DataAccess.Entities.ElectricityConsumptionDto>(electricity);

            _repository.Add(electricityMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DTO_s.ElectricityConsumptionDto>(electricityMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
            var renter = await _repository.GetByIdAsync(id);

            _repository.Delete(renter);
            _unitOfWork.SaveChangesAsync();

            return "deleted";
        }

        public async Task<List<DTO_s.ElectricityConsumptionDto>> GetAllAsync()
        {
            var elects = await _repository.GetAllAsync();

            return _mapper.Map<List<DTO_s.ElectricityConsumptionDto>>(elects);
        }

        public async  Task<DTO_s.ElectricityConsumptionDto> GetById(int id)
        {
            var elect = await _repository.GetByIdAsync(id);

            return _mapper.Map<DTO_s.ElectricityConsumptionDto>(elect);
        }

        public async Task<DTO_s.ElectricityConsumptionDto> UpdateAsync(DTO_s.ElectricityConsumptionDto electricity)
        {
            var electFound = await _repository.GetByIdAsync(electricity.Id);

            electFound.Month = electricity.Month;
            electFound.Year = electricity.Year;
            electFound.Quantity = electricity.Quantity;
            electFound.Ressource = electricity.Ressource;
            electFound.BuildingId = electricity.BuildingId;
            
            _repository.Update(electFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DTO_s.ElectricityConsumptionDto>(electFound);
        }
    }
}
