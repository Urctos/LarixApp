using Application.Dto.DoorsDtos;
using Application.Interfaceas;
using AutoMapper;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace Application.Services
{
    public class DoorService : GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>, IDoorService
    {
        private readonly IPriceCalculator _priceCalculator;
        private readonly IMapper _mapper;
        private readonly IRepository<Door> _repository;



        public DoorService(IRepository<Door> repository, IMapper mapper, IPriceCalculator priceCalculator, ILogger<DoorService> logger)
            : base(repository, mapper, logger)
        {
            _repository = repository;
            _mapper = mapper;
            _priceCalculator = priceCalculator;
            
        }

        public async Task<decimal> CalculateDoorPriceAsync(int doorId)
        {
            var doorDto = await GetByIdAsync(doorId);
            if (doorDto == null)
            {
                throw new ArgumentException($"Door with ID {doorId} not found.");
            }

            var door = _mapper.Map<Door>(doorDto);

            return await _priceCalculator.CalculatePriceAsync(door);
        }
    }
}
