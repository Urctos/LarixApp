using Application.Dto.DoorsDto;
using Application.Dto.GlassTypesDto;
using Application.Dto.HingesDto;
using Application.Dto.ImpregantionTypeDto;
using Application.Dto.WoodDto;
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
            services.AddScoped<IDoorService, DoorService>();
            return services;
        }        
    }
}
