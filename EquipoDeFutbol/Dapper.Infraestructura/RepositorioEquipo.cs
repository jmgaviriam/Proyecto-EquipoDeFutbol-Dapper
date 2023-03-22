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
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string nombreTabla = "Equipo";

        public RepositorioEquipo(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<AgregarEquipo> AgregarEquipoAsync(AgregarEquipo equipo)
        {
            Guard.Against.Null(equipo, nameof(equipo));
            Guard.Against.NullOrWhiteSpace(equipo.NombreEquipo, nameof(equipo.NombreEquipo));
            Guard.Against.NullOrWhiteSpace(equipo.Ciudad, nameof(equipo.Ciudad));
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var agregarEquipo = new
            {
                nombre = equipo.NombreEquipo,
                ciudad = equipo.Ciudad,
            };
            string sqlQuery = $"INSERT INTO {nombreTabla} (NombreEquipo, Ciudad) VALUES (@nombre, @ciudad)";
            var resultado = await connection.ExecuteAsync(sqlQuery, agregarEquipo);
            return equipo;
        }


        public async Task<List<Equipo>> ObtenerListaDeEquiposAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            Guard.Against.Null(connection, nameof(connection));

            string sqlQuery = $"SELECT * FROM {nombreTabla}";
            var resultado = await connection.QueryAsync<Equipo>(sqlQuery);
            connection.Close();
            return resultado.ToList();

        }


        public async Task<Equipo> ObtenerEquipoPorIdAsync(int id)
        {

            Guard.Against.NegativeOrZero(id, nameof(id));
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            Guard.Against.Null(connection, nameof(connection));

            string sqlQuery = $"SELECT * FROM {nombreTabla} WHERE Id = @id";
            var resultado = await connection.QueryFirstOrDefaultAsync<Equipo>(sqlQuery, new { id });
            connection.Close();
            return resultado;
        }

        public async Task<EquipoCompleto> ObtenerEquipoCompletoPorIdAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var equipoQuery = $"SELECT * FROM {nombreTabla} WHERE Id = @id";
            var entrenadorQuery = $"SELECT * FROM Entrenador WHERE EquipoID = @id";
            var jugadoresQuery = $"SELECT * FROM Jugador WHERE EquipoID = @id";
            var multiQuery = $"{equipoQuery};{entrenadorQuery};{jugadoresQuery}";

            using (var multi = await connection.QueryMultipleAsync(multiQuery, new { id }))
            {
                var equipo = await multi.ReadFirstOrDefaultAsync<Equipo>();
                Guard.Against.Null(equipo, nameof(equipo));

                var entrenador = await multi.ReadFirstOrDefaultAsync<Entrenador>();
                var jugadores = (await multi.ReadAsync<Jugador>()).ToList();

                return new EquipoCompleto
                {
                    Id = equipo.Id,
                    NombreEquipo = equipo.NombreEquipo,
                    Ciudad = equipo.Ciudad,
                    Entrenador = entrenador,
                    Jugadores = jugadores
                };
            }
        }

    }
}
