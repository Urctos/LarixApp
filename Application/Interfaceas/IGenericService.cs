namespace Application.Interfaceas
{
    public interface IGenericService<TEntity, TDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
        Task<int> GetAllCountAsync(string filterBy);
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> AddAsync(TCreateDto dto);
        Task UpdateAsync(TUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
