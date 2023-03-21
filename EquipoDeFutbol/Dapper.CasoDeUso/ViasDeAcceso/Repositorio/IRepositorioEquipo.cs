using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;

namespace Dapper.CasoDeUso.ViasDeAcceso.Repositorio
{
    public interface IRepositorioEquipo
    {
        Task<AgregarEquipo> AgregarEquipoAsync(AgregarEquipo equipo);
        Task<List<Equipo>> ObtenerListaDeEquiposAsync();
        Task<Equipo> ObtenerEquipoPorIdAsync(int id);
        Task<EquipoCompleto> ObtenerEquipoCompletoPorIdAsync(int id);
    }
}
