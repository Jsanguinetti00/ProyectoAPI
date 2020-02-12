using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class PerfilModulos
    {
        public int IdPerfilModulos { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdModulo { get; set; }

        public Modulos IdModuloNavigation { get; set; }
        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
