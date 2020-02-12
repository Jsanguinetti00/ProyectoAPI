using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class Citas
    {
        public int IdCitas { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }
        public int IdDatoscita { get; set; }
        public int IdTipoCitas { get; set; }
        public int IdPersona { get; set; }

        public DatosCita IdDatoscitaNavigation { get; set; }
        public Personas IdPersonaNavigation { get; set; }
        public TipoCitas IdTipoCitasNavigation { get; set; }
    }
}
