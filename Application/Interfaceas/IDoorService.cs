using Application.Dto.DoorsDtos;
using Domain.Entities;


namespace Application.Interfaceas
{
    public interface IDoorService : IGenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>
    {
        Task<decimal> CalculateDoorPriceAsync(int doorId);
    }
}
