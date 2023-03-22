using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.CasoDeUso.ViasDeAcceso;
using Dapper.CasoDeUso.ViasDeAcceso.Repositorio;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;
using Moq;

namespace Test.Infraestructura.TestJugador
{
    public class RepositorioJugadorPrueba
    {
        private readonly Mock<IRepositorioJugador> _mockRepositorioJugador;

        public RepositorioJugadorPrueba()
        {
            _mockRepositorioJugador = new();
        }


        [Fact]
        public async Task AgregarJugadorAsync()
        {
            // Arrange
            var agregarJugador = new AgregarJugador
            {
                Nombre = "Jugador 1",
                Apellido = "Apellido 1",
                Edad = 30,
                Posicion = "Delantero",
                NumeroCamiseta = 10,
                EquipoId = 1
            };

            _mockRepositorioJugador.Setup(x => x.AgregarJugadorAsync(agregarJugador)).ReturnsAsync(agregarJugador);

            // Act
            var resultado = await _mockRepositorioJugador.Object.AgregarJugadorAsync(agregarJugador);

            // Assert
            Assert.Equal(agregarJugador, resultado);
        }

        [Fact]
        public async Task ObtenerJugadoresAsync()
        {
            // Arrange
            var listaDeJugadores = new List<Jugador>
            {
                new Jugador
                {
                    Id = 1,
                    Nombre = "Jugador 1",
                    Apellido = "Apellido 1",
                    Edad = 30,
                    Posicion = "Delantero",
                    NumeroCamiseta = 10,
                    EquipoId = 1
                },
                new Jugador
                {
                    Id = 2,
                    Nombre = "Jugador 2",
                    Apellido = "Apellido 2",
                    Edad = 30,
                    Posicion = "Delantero",
                    NumeroCamiseta = 11,
                    EquipoId = 1
                },
                new Jugador
                {
                    Id = 3,
                    Nombre = "Jugador 3",
                    Apellido = "Apellido 3",
                    Edad = 30,
                    Posicion = "Delantero",
                    NumeroCamiseta = 12,
                    EquipoId = 1
                }
            };

            _mockRepositorioJugador.Setup(x => x.ObtenerJugadoresAsync()).ReturnsAsync(listaDeJugadores);

            // Act
            var resultado = await _mockRepositorioJugador.Object.ObtenerJugadoresAsync();

            // Assert
            Assert.Equal(3, resultado.Count);
        }



        [Fact]
        public async Task ObtenerJugadorPorIdAsync()
        {
            // Arrange
            var jugadores = new Jugador
            {
                Id = 1,
                Nombre = "Jugador 1",
                Apellido = "Apellido 1",
                Edad = 30,
                Posicion = "Delantero",
                NumeroCamiseta = 10,
                EquipoId = 1
            };

            _mockRepositorioJugador.Setup(x => x.ObtenerJugadorPorIdAsync(1)).ReturnsAsync(jugadores);

            // Act
            var resultado = await _mockRepositorioJugador.Object.ObtenerJugadorPorIdAsync(1);

            // Assert
            Assert.Equal(jugadores, resultado);

        }

    }
}


