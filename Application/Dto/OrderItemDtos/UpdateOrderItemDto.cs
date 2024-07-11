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
    public class UpdateOrderItemDto : IMap
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int DoorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderItemDto, OrderItem>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
               .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
               .ForMember(dest => dest.DoorId, opt => opt.MapFrom(src => src.DoorId));
        }
    }
}
