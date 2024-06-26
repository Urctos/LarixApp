using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.WoodDtos
{
    public class CreateWoodDto : IMap
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWoodDto, Wood>();
        }
    }
}
