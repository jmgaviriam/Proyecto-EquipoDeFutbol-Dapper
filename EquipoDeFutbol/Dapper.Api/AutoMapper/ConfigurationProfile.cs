using AutoMapper;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;

namespace Dapper.Api.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<AgregarEquipo, Equipo>().ReverseMap();
            CreateMap<AgregarEntrenador, Entrenador>().ReverseMap();
            CreateMap<AgregarJugador, Jugador>().ReverseMap();
        }
    }
}
