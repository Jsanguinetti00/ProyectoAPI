using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class MedicionMesual
    {
        public int IdMedicionMensual { get; set; }
        public DateTime FechaMedicionMensual { get; set; }
        public TimeSpan HoraMedicionMensual { get; set; }
        public string ResultadoMedicionMensual { get; set; }
        public int IdPersona { get; set; }

        public Personas IdPersonaNavigation { get; set; }
    }
}
