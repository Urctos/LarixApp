using Application.Dto.DoorsDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaceas
{
    public interface IDoorService : IGenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>
    {
        Task<decimal> CalculateDoorPriceAsync(int doorId);
    }
}
