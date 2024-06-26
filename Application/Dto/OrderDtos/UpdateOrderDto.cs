using Application.Dto.OrderItemDtos;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.OrderDtos
{
    public class UpdateOrderDto : IMap
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal NetPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<UpdateOrderItemDto> OrderItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.NetPrice, opt => opt.MapFrom(src => src.NetPrice))
                .ForMember(dest => dest.VatRate, opt => opt.MapFrom(src => src.VatRate))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}
