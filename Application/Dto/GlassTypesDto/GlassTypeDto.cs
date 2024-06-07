using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.GlassTypesDto
{
    public class GlassTypeDto : IMap
    {

            public int GlassTypeId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<GlassType, GlassTypeDto>();
            }
    }
}
