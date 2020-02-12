using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class MedicionGlucosa
    {
        public int IdMedicionGlucosa { get; set; }
        public DateTime FechaMedicionGlucosa { get; set; }
        public TimeSpan HoraMedicionGlucosa { get; set; }
        public double ResultadoMedicionGlucosa { get; set; }
        public int IdPruebaBeck { get; set; }

        public PruebaBeck IdPruebaBeckNavigation { get; set; }
    }
}
