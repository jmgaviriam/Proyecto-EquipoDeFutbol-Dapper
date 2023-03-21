using AutoMapper;
using Dapper.CasoDeUso.ViasDeAcceso;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorEntrenador : ControllerBase
    {
        private readonly IEntrenadorCasoDeUso _entrenadorCasoDeUso;
        private readonly IMapper _mapper;

        public ControladorEntrenador(IEntrenadorCasoDeUso entrenadorCasoDeUso, IMapper mapper)
        {
            _entrenadorCasoDeUso = entrenadorCasoDeUso;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Entrenador>> ObtenerListaDeEntrenadores()
        {
            return await _entrenadorCasoDeUso.ObtenerListaDeEntrenadores();
        }

        [HttpGet("{id}")]
        public async Task<Entrenador> ObtenerEntrenadorPorId(int id)
        {
            return await _entrenadorCasoDeUso.ObtenerEntrenadorPorId(id);
        }

        [HttpPost]
        public async Task<AgregarEntrenador> AgregarEntrenador([FromBody] AgregarEntrenador entrenador)
        {
            return await _entrenadorCasoDeUso.AgregarEntrenador(_mapper.Map<AgregarEntrenador>(entrenador));
        }

    }
}
