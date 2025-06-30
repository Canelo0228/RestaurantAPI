using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;

namespace RestaurantAPI.Core.Application.Services
{
    public class GenericService<SaveDto, ViewDto, Entity> : IGenericService<SaveDto, ViewDto, Entity>
        where SaveDto : class
        where ViewDto : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task Add(SaveDto saveEntity)
        {
            Entity entity = _mapper.Map<Entity>(saveEntity);
            await _repository.AddAsync(entity);
        }

        public virtual async Task Update(SaveDto saveEntity, int id)
        {
            Entity entity = _mapper.Map<Entity>(saveEntity);
            await _repository.UpdateAsync(entity, id);
        }

        public virtual async Task Delete(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<ViewDto> GetByIdViewDto(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ViewDto>(entity);
        }

        public virtual async Task<List<ViewDto>> GetAllViewDto()
        {
            List<Entity> entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ViewDto>>(entities);
        }
    }
}
