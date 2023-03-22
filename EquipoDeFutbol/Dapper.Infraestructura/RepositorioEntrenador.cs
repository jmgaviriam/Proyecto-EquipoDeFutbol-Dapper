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
    public class RepositorioEntrenador : IRepositorioEntrenador
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string nombreTabla = "Entrenador";

        public RepositorioEntrenador(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<AgregarEntrenador> AgregarEntrenadorAsync(AgregarEntrenador entrenador)
        {
            Guard.Against.Null(entrenador, nameof(entrenador));
            Guard.Against.NullOrWhiteSpace(entrenador.Nombre, nameof(entrenador.Nombre));
            Guard.Against.NullOrWhiteSpace(entrenador.Apellido, nameof(entrenador.Apellido));
            Guard.Against.OutOfRange(entrenador.Edad, nameof(entrenador.Edad), 18, 100);
            Guard.Against.NullOrWhiteSpace(entrenador.Pais, nameof(entrenador.Pais));
            Guard.Against.OutOfRange(entrenador.EquipoId, nameof(entrenador.EquipoId), 1, int.MaxValue);


            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var agregarEntrenador = new
            {
                nombre = entrenador.Nombre,
                apellido = entrenador.Apellido,
                edad = entrenador.Edad,
                pais = entrenador.Pais,
                equipoId = entrenador.EquipoId
            };
            string sqlQuery = $"INSERT INTO {nombreTabla} (Nombre, Apellido, Edad, Pais, EquipoId) VALUES (@nombre, @apellido, @edad, @pais, @equipoId)";
            var resultado = await connection.ExecuteAsync(sqlQuery, agregarEntrenador);
            return entrenador;

        }

        public async Task<List<Entrenador>> ObtenerListaDeEntrenadoresAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            Guard.Against.Null(connection, nameof(connection));

            string sqlQuery = $"SELECT * FROM {nombreTabla}";
            var resultado = await connection.QueryAsync<Entrenador>(sqlQuery);
            Guard.Against.Null(resultado, nameof(resultado));

            connection.Close();
            return resultado.ToList();

        }

        public async Task<Entrenador> ObtenerEntrenadorPorIdAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            Guard.Against.Null(connection, nameof(connection));

            string sqlQuery = $"SELECT * FROM {nombreTabla} WHERE Id = @id";
            var resultado = await connection.QueryFirstOrDefaultAsync<Entrenador>(sqlQuery, new { id });

            Guard.Against.Null(resultado, nameof(resultado));

            connection.Close();
            return resultado;
        }
    }

}
