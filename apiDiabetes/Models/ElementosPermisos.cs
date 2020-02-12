using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class ElementosPermisos
    {
        public ElementosPermisos()
        {
            ElementoPermitido = new HashSet<ElementoPermitido>();
        }

        public int IdElementosPermisos { get; set; }
        public int IdElementos { get; set; }
        public int IdPermisos { get; set; }

        public Elementos IdElementosNavigation { get; set; }
        public Permisos IdPermisosNavigation { get; set; }
        public ICollection<ElementoPermitido> ElementoPermitido { get; set; }
    }
}
