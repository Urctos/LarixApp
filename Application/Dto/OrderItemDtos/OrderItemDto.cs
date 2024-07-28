using Application.Dto.DoorsDtos;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;


namespace Application.Dto.OrderItemDtos
{
    public class OrderItemDto : IMap
    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int DoorId { get; set; }
        public DoorDto Door { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.DoorId, opt => opt.MapFrom(src => src.DoorId))
                .ForMember(dest => dest.Door, opt => opt.MapFrom(src => src.Door));
        }
    }
}
