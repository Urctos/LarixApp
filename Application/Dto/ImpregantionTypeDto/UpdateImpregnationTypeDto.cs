using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.ImpregantionTypeDto
{
    public class UpdateImpregnationTypeDto : IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerDescription { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateImpregnationTypeDto, ImpregnationType>();
        }
    }
}
