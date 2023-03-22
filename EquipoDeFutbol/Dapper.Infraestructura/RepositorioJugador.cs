using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Dapper.CasoDeUso.ViasDeAcceso.Repositorio;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;
using Dapper.Infraestructura.ViasDeAcceso;

namespace Dapper.Infraestructura
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string nombreTabla = "Jugador";

        public RepositorioJugador(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<AgregarJugador> AgregarJugadorAsync(AgregarJugador jugador)
        {

            Guard.Against.Null(jugador, nameof(jugador));
            Guard.Against.NullOrEmpty(jugador.Nombre, nameof(jugador.Nombre));
            Guard.Against.NullOrEmpty(jugador.Apellido, nameof(jugador.Apellido));
            Guard.Against.OutOfRange(jugador.Edad, nameof(jugador.Edad), 18, 99);
            Guard.Against.NullOrEmpty(jugador.Posicion, nameof(jugador.Posicion));
            Guard.Against.OutOfRange(jugador.NumeroCamiseta, nameof(jugador.NumeroCamiseta), 1, 99);
            Guard.Against.NegativeOrZero(jugador.EquipoId, nameof(jugador.EquipoId));

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var agregarJugador = new
            {
                nombre = jugador.Nombre,
                apellido = jugador.Apellido,
                edad = jugador.Edad,
                posicion = jugador.Posicion,
                numeroCamiseta = jugador.NumeroCamiseta,
                equipoId = jugador.EquipoId
            };
            string sqlQuery =
                $"INSERT INTO {nombreTabla} (Nombre, Apellido, Edad, Posicion, NumeroCamiseta, EquipoId) VALUES (@nombre, @apellido, @edad, @posicion, @numeroCamiseta, @equipoId)";
            var result = await connection.ExecuteAsync(sqlQuery, agregarJugador);
            return jugador;
        }

        public async Task<List<Jugador>> ObtenerJugadoresAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            Guard.Against.Null(connection, nameof(connection));
            string sqlQuery = $"SELECT * FROM {nombreTabla}";

            var resultado = await connection.QueryAsync<Jugador>(sqlQuery);
            Guard.Against.Null(resultado, nameof(resultado));
            return resultado.ToList();
        }

        public async Task<Jugador> ObtenerJugadorPorIdAsync(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            Guard.Against.Null(connection, nameof(connection));

            string sqlQuery = $"SELECT * FROM {nombreTabla} WHERE Id = @id";
            var resultado = await connection.QueryFirstOrDefaultAsync<Jugador>(sqlQuery, new { id });
            Guard.Against.Null(resultado, nameof(resultado));
            return resultado;
        }

    }
}
