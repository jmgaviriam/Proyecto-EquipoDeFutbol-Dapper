using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.CasoDeUso.ViasDeAcceso.Repositorio;
using Dapper.Dominio.Comandos;
using Dapper.Dominio.Entidades;
using Moq;

namespace Test.Infraestructura.TestEquipo
{
    public class RepositorioEquipoPrueba
    {
        private readonly Mock<IRepositorioEquipo> _mockRepositorioEquipo;
        public RepositorioEquipoPrueba()
        {
            _mockRepositorioEquipo = new();
        }

        [Fact]
        public async Task ObtenerEquipoPorIdAsync()
        {
            //Arrange
            var equipo = new Equipo
            {
                Id = 1,
                NombreEquipo = "Equipo 1",
                Ciudad = "Ciudad 1",
            };

            _mockRepositorioEquipo.Setup(x => x.ObtenerEquipoPorIdAsync(1)).ReturnsAsync(equipo);

            //Act
            var resultado = await _mockRepositorioEquipo.Object.ObtenerEquipoPorIdAsync(1);

            //Assert
            Assert.Equal(equipo, resultado);
        }

        [Fact]
        public async Task AgregarEquipoAsync()
        {
            //Arrange
            var equipo = new AgregarEquipo
            {
                NombreEquipo = "Equipo 1",
                Ciudad = "Ciudad 1",
            };

            _mockRepositorioEquipo.Setup(x => x.AgregarEquipoAsync(equipo)).ReturnsAsync(equipo);

            //Act
            var resultado = await _mockRepositorioEquipo.Object.AgregarEquipoAsync(equipo);

            //Assert
            Assert.Equal(equipo, resultado);
        }

        [Fact]
        public async Task ObtenerListaDeEquiposAsync()
        {
            //Arrange
            var listaEquipos = new List<Equipo>
            {
                new Equipo
                {
                    Id = 1,
                    NombreEquipo = "Equipo 1",
                    Ciudad = "Ciudad 1",
                },
                new Equipo
                {
                    Id = 2,
                    NombreEquipo = "Equipo 2",
                    Ciudad = "Ciudad 2",
                },
                new Equipo
                {
                    Id = 3,
                    NombreEquipo = "Equipo 3",
                    Ciudad = "Ciudad 3",
                },
            };

            _mockRepositorioEquipo.Setup(x => x.ObtenerListaDeEquiposAsync()).ReturnsAsync(listaEquipos);

            //Act
            var resultado = await _mockRepositorioEquipo.Object.ObtenerListaDeEquiposAsync();

            //Assert
            Assert.Equal(listaEquipos, resultado);
        }


        [Fact]
        public async Task ObtenerEquipoCompletoPorIdAsync()
        {
            //Arrange
            var equipo = new EquipoCompleto
            {
                Id = 1,
                NombreEquipo = "Equipo 1",
                Ciudad = "Ciudad 1",
                Entrenador = new Entrenador
                {
                    Id = 1,
                    Nombre = "Entrenador 1",
                    Apellido = "Apellido 1",
                    Edad = 10,
                    Pais = "Pais 1",
                    EquipoId = 1,
                },
                Jugadores = new List<Jugador>
                {
                    new Jugador
                    {
                        Id = 1,
                        Nombre = "Jugador 1",
                        Apellido = "Apellido 1",
                        Edad = 10,
                        Posicion = "Posicion 1",
                        NumeroCamiseta = 1,
                        EquipoId = 1,
                    },
                    new Jugador
                    {
                        Id = 2,
                        Nombre = "Jugador 2",
                        Apellido = "Apellido 2",
                        Edad = 10,
                        Posicion = "Posicion 1",
                        NumeroCamiseta = 2,
                        EquipoId = 1,
                    },
                    new Jugador
                    {
                        Id = 3,
                        Nombre = "Jugador 3",
                        Apellido = "Apellido 3",
                        Edad = 10,
                        Posicion = "Posicion 1",
                        NumeroCamiseta = 3,
                        EquipoId = 1,
                    },
                }
            };

            _mockRepositorioEquipo.Setup(x => x.ObtenerEquipoCompletoPorIdAsync(1)).ReturnsAsync(equipo);

            //Act
            var resultado = await _mockRepositorioEquipo.Object.ObtenerEquipoCompletoPorIdAsync(1);

            //Assert
            Assert.Equal(equipo, resultado);
        }
    }
}
