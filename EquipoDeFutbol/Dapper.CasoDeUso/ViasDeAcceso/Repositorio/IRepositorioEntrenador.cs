using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;

namespace Dapper.CasoDeUso.ViasDeAcceso.Repositorio
{
    public interface IRepositorioEntrenador
    {
        Task<AgregarEntrenador> AgregarEntrenadorAsync(AgregarEntrenador entrenador);
        Task<List<Entrenador>> ObtenerListaDeEntrenadoresAsync();
        Task<Entrenador> ObtenerEntrenadorPorIdAsync(int id);
    }
}
