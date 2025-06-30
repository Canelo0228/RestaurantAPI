using RestaurantAPI.Core.Application.Dtos.Table;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface ITableService : IGenericService<SaveTableDto, TableDto, Table>
    {
        Task<List<TableDto>> GetAllWithIncludesDto();
        Task<TableDto> ChangeStatus(int id, TableStatusDto status);
    }
}
