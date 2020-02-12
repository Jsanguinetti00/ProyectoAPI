using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class Elementos
    {
        public Elementos()
        {
            ElementosPermisos = new HashSet<ElementosPermisos>();
        }

        public int IdElementos { get; set; }
        public string NomElemento { get; set; }
        public int IdModulo { get; set; }

        public Modulos IdModuloNavigation { get; set; }
        public ICollection<ElementosPermisos> ElementosPermisos { get; set; }
    }
}
