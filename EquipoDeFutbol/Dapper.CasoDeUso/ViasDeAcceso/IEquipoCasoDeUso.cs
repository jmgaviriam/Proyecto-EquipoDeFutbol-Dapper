using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;

namespace Dapper.CasoDeUso.ViasDeAcceso
{
    public interface IEquipoCasoDeUso
    {
        Task<AgregarEquipo> AgregarEquipo(AgregarEquipo equipo);

        Task<List<Equipo>> ObtenerListaDeEquipos();
        Task<Equipo> ObtenerEquipoPorId(int id);
        Task<EquipoCompleto> ObtenerEquipoCompletoPorId(int id);
    }
}
