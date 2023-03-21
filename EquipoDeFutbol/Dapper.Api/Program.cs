using AutoMapper.Data;
using Dapper.Api.AutoMapper;
using Dapper.CasoDeUso.CasosDeUso;
using Dapper.CasoDeUso.ViasDeAcceso;
using Dapper.CasoDeUso.ViasDeAcceso.Repositorio;
using Dapper.Infraestructura;
using Dapper.Infraestructura.ViasDeAcceso;
using Microsoft.AspNetCore.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));

builder.Services.AddScoped<IEquipoCasoDeUso, EquipoCasoDeUso>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();

builder.Services.AddScoped<IEntrenadorCasoDeUso, EntrenadorCasoDeUso>();
builder.Services.AddScoped<IRepositorioEntrenador, RepositorioEntrenador>();

builder.Services.AddScoped<IJugadorCasoDeUso, JugadorCasoDeUso>();
builder.Services.AddScoped<IRepositorioJugador, RepositorioJugador>();


builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();