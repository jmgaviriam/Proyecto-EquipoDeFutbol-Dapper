using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Dominio.Entidades
{
    public class Jugador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud del apellido debe estar entre 2 y 50 caracteres")]
        public string Apellido { get; set; }

        [Range(18, 99, ErrorMessage = "La edad debe estar entre 18 y 99")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "La posición es requerida")]
        public string Posicion { get; set; }

        [Range(1, 99, ErrorMessage = "El número de camiseta debe estar entre 1 y 99")]
        public int NumeroCamiseta { get; set; }

        public int EquipoId { get; set; }
    }

}
