using Application.Dto.DoorsDto;
using Application.Interfaceas;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenericService<TEntity, TDto, TCreateDto, TUpdateDto> : IGenericService<TEntity, TDto, TCreateDto, TUpdateDto>
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var entities = await _repository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<int> GetAllCountAsync()
        {
            return await _repository.GetAllCountAsync();
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> AddAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
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
