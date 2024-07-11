using Application.Dto.CustomerDtos;
using Application.Dto.DoorsDtos;
using Application.Dto.GlassTypesDtos;
using Application.Dto.HingesDtos;
using Application.Dto.ImpregantionTypeDtos;
using Application.Dto.OrderDtos;
using Application.Dto.OrderItemDtos;
using Application.Dto.WoodDtos;
using Application.Interfaceas;
using Application.Services;
using Domain.Entities;
using Domain.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddScoped<IDoorService, DoorService>();
            //services.AddScoped<IGlassTypeService, GlassTypeService>();

            services.AddScoped<PriceCalculator>();

            services.AddScoped(typeof(IGenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>), typeof(GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>));
            services.AddScoped(typeof(IGenericService<GlassType, GlassTypeDto, CreateGlassTypeDto, UpdateGlassTypeDto>), typeof(GenericService<GlassType, GlassTypeDto, CreateGlassTypeDto, UpdateGlassTypeDto>));
            services.AddScoped(typeof(IGenericService<Hinges, HingesDto, CreateHingeDto, UpdateHingesDto>), typeof(GenericService<Hinges, HingesDto, CreateHingeDto, UpdateHingesDto>));
            services.AddScoped(typeof(IGenericService<Wood, WoodDto, CreateWoodDto, UpdateWoodDto>), typeof(GenericService<Wood, WoodDto, CreateWoodDto, UpdateWoodDto>));
            services.AddScoped(typeof(IGenericService<ImpregnationType, ImpregnationTypeDto, CreateImpregnationTypeDto, UpdateImpregnationTypeDto>), typeof(GenericService<ImpregnationType, ImpregnationTypeDto, CreateImpregnationTypeDto, UpdateImpregnationTypeDto>));
            services.AddScoped(typeof(IGenericService<Customer, CustomerDto, CreateCustomerDto, UpdateCustomerDto>), typeof(GenericService<Customer, CustomerDto, CreateCustomerDto, UpdateCustomerDto>));
            services.AddScoped(typeof(IGenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto>), typeof(GenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto>));
            services.AddScoped(typeof(IGenericService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>), typeof(GenericService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>));
            
            services.AddScoped<IDoorService, DoorService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            
            return services;
        }        
    }
}
