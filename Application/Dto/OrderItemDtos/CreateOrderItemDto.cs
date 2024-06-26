using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.OrderItemDtos
{
    public class CreateOrderItemDto : IMap
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderItemDto, OrderItem>()
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
               .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
               .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
               .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId));
        }
    }
}
