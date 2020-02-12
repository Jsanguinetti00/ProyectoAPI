using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class TipoCitas
    {
        public TipoCitas()
        {
            Citas = new HashSet<Citas>();
        }

        public int IdTipoCitas { get; set; }
        public string NiombreTipoCitas { get; set; }

        public ICollection<Citas> Citas { get; set; }
    }
}
