using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.WoodDto
{
    public class CreateWoodDto : IMap
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double WoodPrice { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWoodDto, Wood>();
        }
    }
}
