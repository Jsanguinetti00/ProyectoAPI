using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class RespuestasBeck
    {
        public RespuestasBeck()
        {
            PreguntasBeck = new HashSet<PreguntasBeck>();
        }

        public int IdRespuestasBeck { get; set; }
        public string NombreRespuestasBeck { get; set; }

        public ICollection<PreguntasBeck> PreguntasBeck { get; set; }
    }
}
