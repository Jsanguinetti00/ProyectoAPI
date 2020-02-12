using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class Modulos
    {
        public Modulos()
        {
            Elementos = new HashSet<Elementos>();
            PerfilModulos = new HashSet<PerfilModulos>();
        }

        public int IdModulo { get; set; }
        public string NomModulo { get; set; }
        public string DesModulo { get; set; }

        public ICollection<Elementos> Elementos { get; set; }
        public ICollection<PerfilModulos> PerfilModulos { get; set; }
    }
}
