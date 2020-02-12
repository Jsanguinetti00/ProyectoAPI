using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class ElementoPermitido
    {
        public int IdElementoPermitido { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdElementosPermisos { get; set; }

        public ElementosPermisos IdElementosPermisosNavigation { get; set; }
        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
