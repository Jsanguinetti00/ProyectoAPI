using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class TipoEspecialista
    {
        public TipoEspecialista()
        {
            DatosCita = new HashSet<DatosCita>();
        }

        public int IdEspecialista { get; set; }
        public string NomTipoespecialista { get; set; }

        public ICollection<DatosCita> DatosCita { get; set; }
    }
}
