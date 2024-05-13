

using Application.Interfaceas;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using WebAPI.Installers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.InstallServicesInAssembly(builder.Configuration);


var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}


app.Run();

