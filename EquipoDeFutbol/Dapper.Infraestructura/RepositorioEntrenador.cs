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
            string sqlQuery = $"SELECT * FROM {nombreTabla}";
            var resultado = await connection.QueryAsync<Entrenador>(sqlQuery);
            connection.Close();
            return resultado.ToList();

        }

        public async Task<Entrenador> ObtenerEntrenadorPorIdAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {nombreTabla} WHERE Id = @id";
            var resultado = await connection.QueryFirstOrDefaultAsync<Entrenador>(sqlQuery, new { id });
            connection.Close();
            return resultado;
        }
    }

}
