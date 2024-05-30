using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.GlassTypesDto
{

    public class UpdateGlassTypeDto : IMap
    {
        public int GlassTypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGlassTypeDto, GlassType>();
        }
    }
}
