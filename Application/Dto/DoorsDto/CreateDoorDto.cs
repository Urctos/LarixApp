﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.DoorsDto
{
    public class CreateDoorDto : IMap
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public decimal Price { get; set; }
        public int GlassTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDoorDto, Door>();
        }
    }
}
