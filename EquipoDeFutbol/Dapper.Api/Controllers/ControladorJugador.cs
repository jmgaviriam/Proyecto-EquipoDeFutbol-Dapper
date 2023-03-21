using AutoMapper;
using Dapper.CasoDeUso.ViasDeAcceso;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorJugador : ControllerBase
    {
        private readonly IJugadorCasoDeUso _jugadorCasoDeUso;
        private readonly IMapper _mapper;

        public ControladorJugador(IJugadorCasoDeUso jugadorCasoDeUso, IMapper mapper)
        {
            _jugadorCasoDeUso = jugadorCasoDeUso;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Jugador>> ObtenerListaDeJugadores()
        {
            return await _jugadorCasoDeUso.ObtenerListaDeJugadores();
        }

        [HttpGet("{id}")]
        public async Task<Jugador> ObtenerJugadorPorId(int id)
        {
            return await _jugadorCasoDeUso.ObtenerJugadorPorId(id);
        }

        [HttpPost]
        public async Task<AgregarJugador> AgregarJugador([FromBody] AgregarJugador jugador)
        {
            return await _jugadorCasoDeUso.AgregarJugador(_mapper.Map<AgregarJugador>(jugador));
        }
    }
}
