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
    public class JugadorCasoDeUso : IJugadorCasoDeUso
    {
        private readonly IRepositorioJugador _repositorioJugador;

        public JugadorCasoDeUso(IRepositorioJugador repositorioJugador)
        {
            _repositorioJugador = repositorioJugador;
        }

        public async Task<AgregarJugador> AgregarJugador(AgregarJugador agregarJugador)
        {
            return await _repositorioJugador.AgregarJugadorAsync(agregarJugador);
        }

        public async Task<List<Jugador>> ObtenerListaDeJugadores()
        {
            return await _repositorioJugador.ObtenerJugadoresAsync();
        }

        public async Task<Jugador> ObtenerJugadorPorId(int id)
        {
            return await _repositorioJugador.ObtenerJugadorPorIdAsync(id);
        }
    }
}
