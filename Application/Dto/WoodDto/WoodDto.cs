using Application.Dto.DoorsDto;
using Application.Dto.GlassTypesDto;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.WoodDto
{
    public class WoodDto : IMap
    {

        public int WoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double WoodPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Wood, WoodDto>();
        }
    }
}
