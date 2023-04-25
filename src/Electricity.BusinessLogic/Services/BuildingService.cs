using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class BuildingService : IBuildingService
    {
        public readonly IGenericRepository<Building> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public BuildingService(IGenericRepository<Building> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BuildingDto> AddAsync(BuildingRequest building)
        {
            var buildingMapped = _mapper.Map<Building>(building);

            _repository.Add(buildingMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BuildingDto>(buildingMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<BuildingDto>> GetAllAsync()

        {
            var buildings = await _repository.GetAllAsync();

            return _mapper.Map<List<BuildingDto>>(buildings);
        }

        public async Task<BuildingDto> GetById(int id)
        {
           var buildingFound = await _repository.GetByIdAsync(id);

            return _mapper.Map<BuildingDto>(buildingFound);
        }

        public async Task<BuildingDto> UpdateAsync(BuildingDto building)
        {
            var buildingFound = await _repository.GetByIdAsync(building.Id);

            buildingFound.Name = building.Name;
            buildingFound.Address = building.Address;
            buildingFound.City = building.City;
            buildingFound.ElectricityMeterId = building.ElectricityMeterId;
            buildingFound.HeatMeterId = building.HeatMeterId;
            buildingFound.WaterMeterId = building.WaterMeterId;
            buildingFound.BuildingArea = building.BuildingArea;


            ;
            _repository.Update(buildingFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BuildingDto>(buildingFound);
        }
    }
}
