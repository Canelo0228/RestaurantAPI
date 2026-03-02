using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Table;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Entities;
using System.Linq.Expressions;

namespace RestaurantAPI.Core.Application.Services
{
    public class TableService : GenericService<SaveTableDto, TableDto, Table>, ITableService
    {
        private readonly ITableRepository _repository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository, IMapper mapper) : base(tableRepository, mapper)
        {
            _repository = tableRepository;
            _mapper = mapper;
        }

        public override async Task<TableDto> AddAsync(SaveTableDto dto)
        {
            var tableEntity = _mapper.Map<Table>(dto);
            tableEntity.StatusId = 1;
            await _repository.AddAsync(tableEntity);
            return _mapper.Map<TableDto>(tableEntity);
        }

        public async Task<List<TableDto>> GetAllWithIncludesDto()
        {
            var tables = await _repository.GetAllWithIncludesAsync(new List<Expression<Func<Table, object>>>
            {
                t => t.Orders,
                t => t.TableStatus
            });

            return _mapper.Map<List<TableDto>>(tables);
        }

        public async Task<TableDto> ChangeStatus(int id, TableStatusDto status)
        {
            if (status.Status < 1 || status.Status > 3)
            {
                throw new Exception("Status not valid.");
            }
            
            Table tableEntity = await _repository.GetByIdAsync(id);
            if (tableEntity == null) return null;
            
            tableEntity.StatusId = status.Status;
            await _repository.UpdateAsync(tableEntity, id);

            return _mapper.Map<TableDto>(tableEntity);
        }
    }
}