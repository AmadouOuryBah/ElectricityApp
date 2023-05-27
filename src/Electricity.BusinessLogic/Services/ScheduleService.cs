using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class ScheduleService : IScheduleService
    {
        public readonly IGenericRepository<Schedule> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;


        public ScheduleService(IGenericRepository<Schedule> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
          
        }

        public async Task<ScheduleDto> AddAsync(ScheduleRequest scheduleRequest)
        {
            var scheduleMapped = _mapper.Map<Schedule>(scheduleRequest);

            _repository.Add(scheduleMapped);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ScheduleDto>(scheduleMapped);
        }
        public async  Task<string> DeleteAsync(int id)
        {
            var schedule = await _repository.GetByIdAsync(id);

            _repository.Delete(schedule);
            await _unitOfWork.SaveChangesAsync();

            return "deleted";
        }

        public async Task<List<ScheduleDto>> GetAllAsync()
        {
            var schedules = await _repository.GetAllAsync();

            return _mapper.Map<List<ScheduleDto>>(schedules);
        }

        public async Task<ScheduleDto> GetByIdAsync(int id)
        {
            var schedule = await _repository.GetByIdAsync(id);

            return _mapper.Map<ScheduleDto>(schedule);
            
        }

        public async  Task<ScheduleDto> UpdateAsync(ScheduleDto scheduleDto)
        {
            var scheduleFound = await _repository.GetByIdAsync(scheduleDto.Id);

            //a reecrider cette partie pour update
            _repository.Update(scheduleFound);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ScheduleDto>(scheduleFound);
        }

       
    }
}
