using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.DoorsDtos
{
    public class UpdateDoorDto : IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDoorDto, Door>();
        }
    }
}
