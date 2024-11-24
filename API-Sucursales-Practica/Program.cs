using API_Sucursales_Practica.Context;
using API_Sucursales_Practica.Repository;
using API_Sucursales_Practica.Repository.Interfaces;
using API_Sucursales_Practica.Services;
using API_Sucursales_Practica.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationContext>((options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
})); 

builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();
builder.Services.AddScoped<IConfiguracionRepository, ConfiguracionRepository>();
builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<IConfiguracionService, ConfiguracionService>();


builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())

);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
