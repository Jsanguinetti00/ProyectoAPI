using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class TipoActividad
    {
        public TipoActividad()
        {
            Calendario7pasos = new HashSet<Calendario7pasos>();
        }

        public int IdTipoActividad { get; set; }
        public string NombreTipoActividad { get; set; }

        public ICollection<Calendario7pasos> Calendario7pasos { get; set; }
    }
}
