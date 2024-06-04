using Application.Dto.DoorsDto;
using Application.Interfaceas;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class DoorService : IDoorService
    {
        private readonly IDoorRepository _doorRepository;
        private readonly IMapper _mapper;
        public DoorService(IDoorRepository doorRepository, IMapper mapper)
        {
            _doorRepository = doorRepository;
            _mapper = mapper;
        }

        public async Task <IEnumerable<DoorDto>> GetAllDoorsAsync(int pageNumber, int pageSize)
        {
            var windows = await _doorRepository.GetAllAsync( pageNumber, pageSize);
            return _mapper.Map<IEnumerable<DoorDto>>(windows);
        }

        public async Task<int> GetAllDoorsCountAsync()
        {
            return await _doorRepository.GetAllCountAsync();
        }


        public  async Task<DoorDto> GetDoorByIdAsync(int id)
        {
            var window = await _doorRepository.GetByIdAsync(id);
            return _mapper.Map<DoorDto>(window);
            
            
        }

        public async Task <DoorDto> AddNewDoorAsync(CreateDoorDto newDoor)
        {
            if(string.IsNullOrEmpty(newDoor.Name))
            {
                throw new Exception("Product can't have an empty title");
            }

            var door = _mapper.Map<Door>(newDoor);
            var result = await _doorRepository.AddAsync(door);
            return _mapper.Map<DoorDto>(result);

        }

        public async Task UpdateDoorAsync(UpdateDoorDto updateDoor)
        {
            var existingDoor = await _doorRepository.GetByIdAsync(updateDoor.Id);
            var door = _mapper.Map(updateDoor, existingDoor);
            await _doorRepository.UpdateAsync(door);
        }

        public async Task DeleteDoorAsync(int id)
        {
            var door = await _doorRepository.GetByIdAsync(id);
            await _doorRepository.DeleteAsync(door);
        }


    }
}
