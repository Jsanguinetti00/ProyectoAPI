using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class Conferencias
    {
        public int IdConferencias { get; set; }
        public string NombreConferencia { get; set; }
        public DateTime FechaConferencias { get; set; }
        public TimeSpan HoraConferencias { get; set; }
        public int IdPersona { get; set; }

        public Personas IdPersonaNavigation { get; set; }
    }
}
