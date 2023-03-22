using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.CasoDeUso.ViasDeAcceso.Repositorio;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;
using Dapper.Infraestructura;
using Dapper.Infraestructura.ViasDeAcceso;
using Moq;

namespace Test.Infraestructura.TestEntrenador
{
    public class RepositorioEntrenadorPrueba
    {
        private readonly Mock<IRepositorioEntrenador> _mockRepositorioEntrenador;
        public RepositorioEntrenadorPrueba()
        {
            _mockRepositorioEntrenador = new();
        }

        [Fact]
        public async Task AgregarEntrenadorAsync()
        {
            // Arrange
            var agregarEntrenador = new AgregarEntrenador
            {
                Nombre = "Juan",
                Apellido = "Perez",
                Edad = 30,
                Pais = "Argentina",
                EquipoId = 1
            };

            var entrenador = new AgregarEntrenador
            {
                Nombre = "Juan",
                Apellido = "Perez",
                Edad = 30,
                Pais = "Argentina",
                EquipoId = 1
            };

            _mockRepositorioEntrenador.Setup(x => x.AgregarEntrenadorAsync(agregarEntrenador)).ReturnsAsync(entrenador);

            // Act
            var resultado = await _mockRepositorioEntrenador.Object.AgregarEntrenadorAsync(agregarEntrenador);

            // Assert
            Assert.Equal(entrenador, resultado);
        }

        [Fact]
        public async Task ObtenerEntrenadorPorIdAsync()
        {
            // Arrange
            var entrenador = new Entrenador
            {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Perez",
                Edad = 30,
                Pais = "Argentina",
                EquipoId = 1
            };

            _mockRepositorioEntrenador.Setup(x => x.ObtenerEntrenadorPorIdAsync(1)).ReturnsAsync(entrenador);

            // Act
            var resultado = await _mockRepositorioEntrenador.Object.ObtenerEntrenadorPorIdAsync(1);

            // Assert
            Assert.Equal(entrenador, resultado);
        }

        [Fact]
        public async Task ObtenerListaDeEntrenadoresAsync()
        {
            // Arrange
            var entrenadores = new List<Entrenador>
            {
                new Entrenador
                {
                    Id = 1,
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Edad = 30,
                    Pais = "Argentina",
                    EquipoId = 1
                },
                new Entrenador
                {
                    Id = 2,
                    Nombre = "Pedro",
                    Apellido = "Gomez",
                    Edad = 35,
                    Pais = "Argentina",
                    EquipoId = 2
                }
            };

            _mockRepositorioEntrenador.Setup(x => x.ObtenerListaDeEntrenadoresAsync()).ReturnsAsync(entrenadores);

            // Act
            var resultado = await _mockRepositorioEntrenador.Object.ObtenerListaDeEntrenadoresAsync();

            // Assert
            Assert.Equal(entrenadores, resultado);
        }
    }
}
