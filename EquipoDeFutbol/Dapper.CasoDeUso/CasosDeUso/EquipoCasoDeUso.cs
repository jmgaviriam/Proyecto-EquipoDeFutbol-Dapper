using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.CasoDeUso.ViasDeAcceso;
using Dapper.CasoDeUso.ViasDeAcceso.Repositorio;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;

namespace Dapper.CasoDeUso.CasosDeUso
{
    public class EquipoCasoDeUso : IEquipoCasoDeUso
    {
        private readonly IRepositorioEquipo _repositorioEquipo;
        public EquipoCasoDeUso(IRepositorioEquipo repositorioEquipo)
        {
            _repositorioEquipo = repositorioEquipo;
        }

        public async Task<AgregarEquipo> AgregarEquipo(AgregarEquipo equipo)
        {
            return await _repositorioEquipo.AgregarEquipoAsync(equipo);
        }

        public async Task<List<Equipo>> ObtenerListaDeEquipos()
        {
            return await _repositorioEquipo.ObtenerListaDeEquiposAsync();
        }

        public async Task<Equipo> ObtenerEquipoPorId(int id)
        {
            return await _repositorioEquipo.ObtenerEquipoPorIdAsync(id);
        }
    }
}
