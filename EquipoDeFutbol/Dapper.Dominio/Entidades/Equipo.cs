using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Dominio.Entidades
{
    public class Equipo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del equipo es requerido.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud del nombre del equipo debe estar entre 2 y 50 caracteres.")]
        public string NombreEquipo { get; set; }

        [Required(ErrorMessage = "La ciudad del equipo es requerida.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud de la ciudad debe estar entre 2 y 50 caracteres.")]
        public string Ciudad { get; set; }
    }

}
