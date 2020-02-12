using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class PesoTalla
    {
        public int IdPesoTalla { get; set; }
        public DateTime FechaPesoTalla { get; set; }
        public double ResultadoPeso { get; set; }
        public double ResultadoTalla { get; set; }
        public int IdPersona { get; set; }

        public Personas IdPersonaNavigation { get; set; }
    }
}
