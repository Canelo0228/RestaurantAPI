namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveDto, ViewDto, Entity>
        where SaveDto : class
        where ViewDto : class
        where Entity : class
    {
        Task Add(SaveDto saveEntity);
        Task Update(SaveDto saveEntity, int id);
        Task Delete(int id);
        Task<ViewDto> GetByIdViewDto(int id);
        Task<List<ViewDto>> GetAllViewDto();
    }
}
