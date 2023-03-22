using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;

namespace Dapper.CasoDeUso.ViasDeAcceso.Repositorio
{
    public interface IRepositorioJugador
    {
        Task<AgregarJugador> AgregarJugadorAsync(AgregarJugador agregarJugador);
        Task<List<Jugador>> ObtenerJugadoresAsync();
        Task<Jugador> ObtenerJugadorPorIdAsync(int id);
    }
}
