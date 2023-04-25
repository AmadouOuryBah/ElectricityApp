
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;

namespace Electricity.BusinessLogic.Services
{
    public  class MetersDataService : IMetersDataService
    {
        public readonly IGenericRepository<MetersData> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public MetersDataService(IGenericRepository<MetersData> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork; 
        }

        public async  Task<MetersDataDto> AddAsync(MetersDataRequest metersData)
        {
            var dataMapped = _mapper.Map<MetersData>(metersData);

            _repository.Add(dataMapped);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<MetersDataDto>(dataMapped);
        }

        public async Task<string> DeleteAsync(int id)
        {
            var meterData = await _repository.GetByIdAync(id);

            _repository.Delete(meterData);
            _unitOfWork.SaveChangesAsync();

            return "deleted";

        }

        public async Task<List<MetersDataDto>> GetAllAsync()
        {
            var metersDatas = await _repository.GetAllAsync();

            return _mapper.Map<List<MetersDataDto>>(metersDatas);
        }

        public async  Task<MetersDataDto> GetById(int id)
        {
            var meterData = await _repository.GetByIdAsync(id);

            return _mapper.Map<MetersDataDto>(meterData);
        }

        public async  Task<MetersDataDto> UpdateAsync(MetersDataDto metersData)
        {
            var dataFound = await _repository.GetByIdAsync(metersData.Id);

            dataFound.MeterId = metersData.MeterId;
            dataFound.Date = metersData.Date;
            dataFound.Indication = metersData.Indication;

            _repository.Update(dataFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<MetersDataDto>(dataFound);
        }
    }
}
