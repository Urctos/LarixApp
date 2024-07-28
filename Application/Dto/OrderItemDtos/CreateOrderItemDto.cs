using Application.Mappings;
using AutoMapper;
using Domain.Entities;


namespace Application.Dto.OrderItemDtos
{
    public class CreateOrderItemDto : IMap
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int DoorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderItemDto, OrderItem>()
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
               .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
               .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
               .ForMember(dest => dest.DoorId, opt => opt.MapFrom(src => src.DoorId));
        }
    }
}
