using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dapper.Dominio.Entidades
{
    public class Entrenador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "La longitud del apellido debe estar entre 2 y 50 caracteres")]
        public string Apellido { get; set; }

        [Range(18, 99, ErrorMessage = "La edad debe estar entre 18 y 99")]
        public int Edad { get; set; }

        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "El país debe contener solo letras")]
        public string Pais { get; set; }

        public int EquipoId { get; set; }
    }
}







