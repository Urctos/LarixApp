using Application.Dto.DoorsDto;

namespace Application.Interfaceas
{
    public interface IDoorService
    {
        Task<IEnumerable<DoorDto>> GetAllDoorsAsync(int pageNumber, int pageSize);
        Task<int> GetAllDoorsCountAsync();
        Task<DoorDto> GetDoorByIdAsync(int id);

        Task<DoorDto> AddNewDoorAsync(CreateDoorDto product);

        Task UpdateDoorAsync(UpdateDoorDto updateProduct);

        Task DeleteDoorAsync(int id);
    }
}
