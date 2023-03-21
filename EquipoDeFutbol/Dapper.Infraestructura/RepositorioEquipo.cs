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
            string sqlQuery = $"SELECT * FROM {nombreTabla}";
            var resultado = await connection.QueryAsync<Equipo>(sqlQuery);
            connection.Close();
            return resultado.ToList();

        }

        public async Task<Equipo> ObtenerEquipoPorIdAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {nombreTabla} WHERE Id = @id";
            var resultado = await connection.QueryFirstOrDefaultAsync<Equipo>(sqlQuery, new { id });
            connection.Close();
            return resultado;
        }
    }
}
