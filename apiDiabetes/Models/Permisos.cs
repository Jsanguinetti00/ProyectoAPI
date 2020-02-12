using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class Permisos
    {
        public Permisos()
        {
            ElementosPermisos = new HashSet<ElementosPermisos>();
        }

        public int IdPermisos { get; set; }
        public string NomPermisos { get; set; }

        public ICollection<ElementosPermisos> ElementosPermisos { get; set; }
    }
}
