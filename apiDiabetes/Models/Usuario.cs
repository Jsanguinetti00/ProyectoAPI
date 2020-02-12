using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public int IdPersona { get; set; }
        public int IdTipoUsuario { get; set; }

        public Personas IdPersonaNavigation { get; set; }
        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
