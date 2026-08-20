using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.User;
using RestaurantAPI.Core.Application.Helpers;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Entities;

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

        public async Task<RegisterResponse> AddAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(request.Name);
            
           if (existingUser != null)
                throw new Exception("User already exists");

            User user = _mapper.Map<User>(request);
           
            user.Role = "Waiter";
            user.Password = PasswordHasher.HashPassword(request.Password);

            await _userRepository.AddAsync(user);

            return _mapper.Map<RegisterResponse>(user);
        }

        public async Task<UserDto> GetById(int id)
        {
            return _mapper.Map<UserDto>(
                await _userRepository.GetByIdAsync(id)
                );
        }
    }
}
