using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;


namespace Electricity.BusinessLogic.Services
{
    public class UserService : IUserService, IUserRepository
    {
        public readonly IGenericRepository<User> _userRepository;
        public readonly IUserRepository _userLoginRepository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;


        public UserService(IGenericRepository<User> userRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userLoginRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userLoginRepository = userLoginRepository;
        }
        public async Task<UserDto> AddAsync(UserRequest user)
        {

            var userMapped = _mapper.Map<User>(user);
            _userRepository.Add(userMapped);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserDto>(userMapped);
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public Task<UserDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginAsync(string username, string password)
        {
            return _userLoginRepository.LoginAsync(username, password);
        }

        public Task<UserDto> UpdateAsync(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
