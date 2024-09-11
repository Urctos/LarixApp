using Application.Interfaceas;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class GenericService<TEntity, TDto, TCreateDto, TUpdateDto> : IGenericService<TEntity, TDto, TCreateDto, TUpdateDto>
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        private readonly ILogger<GenericService<TEntity, TDto, TCreateDto, TUpdateDto>> _logger;

        public GenericService(IRepository<TEntity> repository, IMapper mapper, ILogger<GenericService<TEntity, TDto, TCreateDto, TUpdateDto>> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        {
            _logger.LogDebug("Fetching doors");
            _logger.LogInformation($"pageNumber: { pageNumber} | pageSize: {pageSize}");

            var entities = await _repository.GetAllAsync(pageNumber, pageSize, sortField, ascending, filterBy);
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<int> GetAllCountAsync(string filterBy)
        {
            return await _repository.GetAllCountAsync(filterBy);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> AddAsync(TCreateDto newDto)
        {
            //if (newDto is IHasName hasNameDto)
            //{
            //    if (string.IsNullOrWhiteSpace(hasNameDto.Name))
            //    {
            //        throw new ArgumentException("Name cannot be empty or null.", nameof(hasNameDto.Name));
            //    }

            //    if (hasNameDto.Name.Length < 3)
            //    {
            //        throw new ArgumentException("Name cannot be shorter than 3 characters.", nameof(hasNameDto.Name));
            //    }
            //}

            var entity = _mapper.Map<TEntity>(newDto);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(result);
        }

        public async Task UpdateAsync(TUpdateDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync((dto as dynamic).Id);
            var entity = _mapper.Map(dto, existingEntity);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
