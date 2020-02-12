using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class Calendario7pasos
    {
        public int IdCalendario7pasos { get; set; }
        public TimeSpan HoraCaledario { get; set; }
        public DateTime FechaCalendario7pasos { get; set; }
        public int IdTipoActividad { get; set; }
        public int IdPersona { get; set; }

        public Personas IdPersonaNavigation { get; set; }
        public TipoActividad IdTipoActividadNavigation { get; set; }
    }
}
