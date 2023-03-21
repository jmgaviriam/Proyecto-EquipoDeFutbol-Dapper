using AutoMapper;
using Dapper.CasoDeUso.ViasDeAcceso;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorEquipo : ControllerBase
    {
        private readonly IEquipoCasoDeUso _equipoCasoDeUso;
        private readonly IMapper _mapper;

        public ControladorEquipo(IEquipoCasoDeUso equipoCasoDeUso, IMapper mapper)
        {
            _equipoCasoDeUso = equipoCasoDeUso;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Equipo>> ObtenerListaDeEquipos()
        {
            return await _equipoCasoDeUso.ObtenerListaDeEquipos();
        }

        [HttpGet("{id}")]
        public async Task<Equipo> ObtenerEquipoPorId(int id)
        {
            return await _equipoCasoDeUso.ObtenerEquipoPorId(id);
        }

        [HttpPost]
        public async Task<AgregarEquipo> AgregarEquipo([FromBody] AgregarEquipo equipo)
        {
            return await _equipoCasoDeUso.AgregarEquipo(_mapper.Map<AgregarEquipo>(equipo));
        }
    }
}
