using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class DatosCita
    {
        public DatosCita()
        {
            Citas = new HashSet<Citas>();
        }

        public int IdDatoscita { get; set; }
        public int? Consultorio { get; set; }
        public string TelefonoEspecialista { get; set; }
        public string NombreEspecialista { get; set; }
        public int IdEspecialista { get; set; }

        public TipoEspecialista IdEspecialistaNavigation { get; set; }
        public ICollection<Citas> Citas { get; set; }
    }
}
