


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
    public class ResourceService : IResourceService
    {

        public readonly IGenericRepository<Resource> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public ResourceService(IGenericRepository<Resource> electricityConsumptionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = electricityConsumptionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResourceDto> AddAsync(ResourceRequest electricity)
        {
            var electricityMapped = _mapper.Map<Resource>(electricity);

            _repository.Add(electricityMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ResourceDto>(electricityMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
            var renter = await _repository.GetByIdAsync(id);

            _repository.Delete(renter);
            _unitOfWork.SaveChangesAsync();

            return "deleted";
        }

        public async Task<List<ResourceDto>> GetAllAsync()
        {
            var elects = await _repository.GetAllAsync();

            return _mapper.Map<List<ResourceDto>>(elects);
        }

        public async  Task<ResourceDto> GetById(int id)
        {
            var elect = await _repository.GetByIdAsync(id);

            return _mapper.Map<ResourceDto>(elect);
        }

        public async Task<ResourceDto> UpdateAsync(ResourceDto resource)
        {
            var resourceFound = await _repository.GetByIdAsync(resource.Id);

            resource.Month = resource.Month;
            resource.Year = resource.Year;
            resource.Quantity = resource.Quantity;
            resource.ResourceType = resource.ResourceType;
            resource.BuildingId = resource.BuildingId;
            
            _repository.Update(resourceFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ResourceDto>(resourceFound);
        }
    }
}
