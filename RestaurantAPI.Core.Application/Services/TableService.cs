using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Table;
using RestaurantAPI.Core.Application.Enums;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Services
{
    public class TableService : GenericService<SaveTableDto, TableDto, Table>, ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository, IMapper mapper) : base(tableRepository, mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<List<TableDto>> GetAllWithIncludesDto()
        {
            var tableList = await _tableRepository.GetAllWithIncludesAsync(new List<string> { "Orders" });

            return tableList.Select(table => new TableDto()
            {
                Id = table.Id,
                Capability = table.Capability,
                Description = table.Description,
                Status = Enum.TryParse<TableStatus>(table.Status, ignoreCase: true, out var status)
                    ? status.ToString()
                    : "Unknown"
            }).ToList();
        }

        public async Task<TableDto> ChangeStatus(int id, TableStatusDto status)
        {
            Table tableEntity = new()
            {
                Status = status.Status.ToString(),
            };

            await _tableRepository.UpdateAsync(tableEntity, id);
            var table = await _tableRepository.GetByIdAsync(id);
            return _mapper.Map<TableDto>(table);
        }
    }
}
