using Application.Dto.CustomerDtos;
using Application.Dto.OrderItemDtos;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.OrderDtos
{
    public class OrderDto : IMap
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal NetPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.NetPrice, opt => opt.MapFrom(src => src.NetPrice))
                .ForMember(dest => dest.VatRate, opt => opt.MapFrom(src => src.VatRate))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}
