﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateProductDto : IMap
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public GlassType GlassType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, Product>();
        }
    }
}
