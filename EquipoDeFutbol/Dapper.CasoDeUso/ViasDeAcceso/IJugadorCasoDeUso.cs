using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;

namespace Dapper.CasoDeUso.ViasDeAcceso
{
    public interface IJugadorCasoDeUso
    {
        Task<List<Jugador>> ObtenerListaDeJugadores();
        Task<Jugador> ObtenerJugadorPorId(int id);
        Task<AgregarJugador> AgregarJugador(AgregarJugador jugador);
    }
}
