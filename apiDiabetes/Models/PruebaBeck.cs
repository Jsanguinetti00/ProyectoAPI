using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class PruebaBeck
    {
        public PruebaBeck()
        {
            MedicionGlucosa = new HashSet<MedicionGlucosa>();
        }

        public int IdPruebaBeck { get; set; }
        public int IdPreguntasBeck { get; set; }
        public int IdPersona { get; set; }

        public Personas IdPersonaNavigation { get; set; }
        public PreguntasBeck IdPreguntasBeckNavigation { get; set; }
        public ICollection<MedicionGlucosa> MedicionGlucosa { get; set; }
    }
}
