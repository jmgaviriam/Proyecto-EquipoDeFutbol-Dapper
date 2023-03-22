using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;

namespace Dapper.CasoDeUso.ViasDeAcceso
{
    public interface IEntrenadorCasoDeUso
    {
        Task<List<Entrenador>> ObtenerListaDeEntrenadores();
        Task<Entrenador> ObtenerEntrenadorPorId(int id);
        Task<AgregarEntrenador> AgregarEntrenador(AgregarEntrenador entrenador);
    }
}
