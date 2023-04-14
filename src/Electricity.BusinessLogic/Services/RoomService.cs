using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class RoomService : IRoom
    {
        public readonly IGenericRepository<Room> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public RoomService(IGenericRepository<Room> repository,
           IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<RoomDto> AddAsync(RoomRequest room)
        {
            var RoomMapped = _mapper.Map<Room>(room);

            _repository.Add(RoomMapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RoomDto>(RoomMapped);
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var rooms = await _repository.GetAllAsync();

            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetById(int id)
        {
           var  room = await _repository.GetByIdAsync(id);

            return _mapper.Map<RoomDto>(room);
        }

        public Task<RoomDto> UpdateAsync(int id, RoomRequest room)
        {
            throw new NotImplementedException();
        }
    }
}
