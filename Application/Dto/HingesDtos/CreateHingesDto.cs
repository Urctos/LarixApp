using Application.Mappings;
using AutoMapper;
using Domain.Entities;


namespace Application.Dto.HingesDtos
{
    public class CreateHingeDto : IMap
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerDescription { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHingeDto, Hinges>();
        }
    }
}
