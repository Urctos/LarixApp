using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Data;

namespace Application.Dto.DoorsDtos
{
    public class DoorDto : IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public int GlassTypeId { get; set; }
        public int WoodId { get; set; }
        public int ImpregnationTypeId { get; set; }
        public int HingesId { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Door, DoorDto>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.GlassTypeId, opt => opt.MapFrom(src => src.GlassTypeId))
                .ForMember(dest => dest.WoodId, opt => opt.MapFrom(src => src.WoodId))
                .ForMember(dest => dest.ImpregnationTypeId, opt => opt.MapFrom(src => src.ImpregnationTypeId))
                .ForMember(dest => dest.HingesId, opt => opt.MapFrom(src => src.HingesId)); 

            profile.CreateMap<DoorDto, Door>()

                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.GlassTypeId, opt => opt.MapFrom(src => src.GlassTypeId))
                .ForMember(dest => dest.WoodId, opt => opt.MapFrom(src => src.WoodId))
                .ForMember(dest => dest.ImpregnationTypeId, opt => opt.MapFrom(src => src.ImpregnationTypeId))
                .ForMember(dest => dest.HingesId, opt => opt.MapFrom(src => src.HingesId));

            profile.CreateMap<CreateDoorDto, Door>()
                .ForMember(dest => dest.GlassTypeId, opt => opt.MapFrom(src => src.GlassTypeId != 0 ? src.GlassTypeId : (int?)null))
                .ForMember(dest => dest.ImpregnationTypeId, opt => opt.MapFrom(src => src.ImpregnationTypeId != 0 ? src.ImpregnationTypeId : (int?)null))
                .ForMember(dest => dest.WoodId, opt => opt.MapFrom(src => src.WoodId))
                .ForMember(dest => dest.HingesId, opt => opt.MapFrom(src => src.HingesId));

            profile.CreateMap<DoorDto, UpdateDoorDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)); 
        }
    }
}
