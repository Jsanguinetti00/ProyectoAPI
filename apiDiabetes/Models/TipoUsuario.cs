using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            ElementoPermitido = new HashSet<ElementoPermitido>();
            PerfilModulos = new HashSet<PerfilModulos>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string NombreTipoUsuario { get; set; }

        public ICollection<ElementoPermitido> ElementoPermitido { get; set; }
        public ICollection<PerfilModulos> PerfilModulos { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
