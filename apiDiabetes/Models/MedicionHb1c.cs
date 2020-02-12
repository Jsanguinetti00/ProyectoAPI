using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class MedicionHb1c
    {
        public int IdMedicionHb1c { get; set; }
        public DateTime FechaMedicionHb1c { get; set; }
        public TimeSpan HoraMedicionHb1c { get; set; }
        public string ResutadoMedicionHb1c { get; set; }
        public int IdPersona { get; set; }

        public Personas IdPersonaNavigation { get; set; }
    }
}
