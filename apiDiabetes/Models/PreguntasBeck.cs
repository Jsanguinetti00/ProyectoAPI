using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class PreguntasBeck
    {
        public PreguntasBeck()
        {
            PruebaBeck = new HashSet<PruebaBeck>();
        }

        public int IdPreguntasBeck { get; set; }
        public string NombrePreguntasBeck { get; set; }
        public int IdRespuestasBeck { get; set; }

        public RespuestasBeck IdRespuestasBeckNavigation { get; set; }
        public ICollection<PruebaBeck> PruebaBeck { get; set; }
    }
}
