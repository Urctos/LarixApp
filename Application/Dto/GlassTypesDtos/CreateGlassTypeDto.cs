﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.GlassTypesDtos
{
    public class CreateGlassTypeDto : IMap
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGlassTypeDto, GlassType>();
        }
    }
}
