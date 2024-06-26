using Application.Dto.DoorsDtos;
using Application.Dto.GlassTypesDtos;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.WoodDtos
{
    public class WoodDto : IMap
    {

        public int WoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Wood, WoodDto>();
        }
    }
}
