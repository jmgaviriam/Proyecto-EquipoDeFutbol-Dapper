using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Dominio.Comandos
{
    public class AgregarEntrenador
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Pais { get; set; }
        public int EquipoId { get; set; }
    }
}
