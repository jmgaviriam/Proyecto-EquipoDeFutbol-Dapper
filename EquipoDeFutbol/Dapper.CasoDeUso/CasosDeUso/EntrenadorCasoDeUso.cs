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
    public class EntrenadorCasoDeUso : IEntrenadorCasoDeUso
    {
        private readonly IRepositorioEntrenador _repositorioEntrenador;
        public EntrenadorCasoDeUso(IRepositorioEntrenador repositorioEntrenador)
        {
            _repositorioEntrenador = repositorioEntrenador;
        }
        public async Task<AgregarEntrenador> AgregarEntrenador(AgregarEntrenador entrenador)
        {
            return await _repositorioEntrenador.AgregarEntrenadorAsync(entrenador);
        }

        public async Task<List<Entrenador>> ObtenerListaDeEntrenadores()
        {
            return await _repositorioEntrenador.ObtenerListaDeEntrenadoresAsync();
        }

        public async Task<Entrenador> ObtenerEntrenadorPorId(int id)
        {
            return await _repositorioEntrenador.ObtenerEntrenadorPorIdAsync(id);
        }
    }
}
