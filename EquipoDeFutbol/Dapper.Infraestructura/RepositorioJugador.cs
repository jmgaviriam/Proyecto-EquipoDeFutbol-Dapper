using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string sqlQuery = $"SELECT * FROM {nombreTabla}";
            var result = await connection.QueryAsync<Jugador>(sqlQuery);
            return result.ToList();
        }

        public async Task<Jugador> ObtenerJugadorPorIdAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {nombreTabla} WHERE Id = @id";
            var result = await connection.QueryFirstOrDefaultAsync<Jugador>(sqlQuery, new { id });
            return result;
        }

    }
}
