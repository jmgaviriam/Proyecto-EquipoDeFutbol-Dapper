using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Dominio.Entidades
{
    public class EquipoCompleto
    {
        public int Id { get; set; }
        public string NombreEquipo { get; set; }
        public string Ciudad { get; set; }

        public Entrenador Entrenador { get; set; }
        public List<Jugador> Jugadores { get; set; }

    }
}
