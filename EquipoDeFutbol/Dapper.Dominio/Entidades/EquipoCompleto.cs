using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Dominio.Entidades
{

    public class EquipoCompleto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del equipo es requerido.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud del nombre del equipo debe estar entre 2 y 50 caracteres.")]
        public string NombreEquipo { get; set; }

        [Required(ErrorMessage = "La ciudad del equipo es requerida.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud de la ciudad del equipo debe estar entre 2 y 50 caracteres.")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El entrenador es requerido.")]
        public Entrenador Entrenador { get; set; }

        [Required(ErrorMessage = "Debe haber al menos un jugador en el equipo.")]
        public List<Jugador> Jugadores { get; set; }
    }

}
