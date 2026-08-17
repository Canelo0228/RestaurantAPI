using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.User;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;

namespace RestaurantAPI.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetById(int id)
        {
            return _mapper.Map<UserDto>(
                await _userRepository.GetByIdAsync(id)
                );
        }
    }
}
