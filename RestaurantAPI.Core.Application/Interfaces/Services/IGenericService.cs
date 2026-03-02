namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveDto, ViewDto, T>
        where SaveDto : class
        where ViewDto : class
        where T : class
    {
        Task<ViewDto> AddAsync(SaveDto saveDto);
        Task UpdateAsync(SaveDto saveDto, int id);
        Task DeleteAsync(int id);
        Task<ViewDto> GetByIdAsync(int id);
        Task<List<ViewDto>> GetAllAsync();
    }
}
