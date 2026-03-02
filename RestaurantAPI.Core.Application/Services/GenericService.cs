using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;

namespace RestaurantAPI.Core.Application.Services
{
    public class GenericService<SaveDto, ViewDto, T> : IGenericService<SaveDto, ViewDto, T>
        where SaveDto : class
        where ViewDto : class
        where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<ViewDto> AddAsync(SaveDto saveDto)
        {
            var entity = _mapper.Map<T>(saveDto);
            await _repository.AddAsync(entity);
            return _mapper.Map<ViewDto>(entity);
        }

        public virtual async Task UpdateAsync(SaveDto dto, int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) return;

            _mapper.Map(dto, entity);

            await _repository.UpdateAsync(entity, id);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<ViewDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ViewDto>(entity);
        }

        public virtual async Task<List<ViewDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ViewDto>>(entities);
        }
    }
}
