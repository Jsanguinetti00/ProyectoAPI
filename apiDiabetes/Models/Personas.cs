using System;
using System.Collections.Generic;

namespace apiDiabetes.Models
{
    public partial class Personas
    {
        public Personas()
        {
            Calendario7pasos = new HashSet<Calendario7pasos>();
            Citas = new HashSet<Citas>();
            Conferencias = new HashSet<Conferencias>();
            MedicionHb1c = new HashSet<MedicionHb1c>();
            MedicionMesual = new HashSet<MedicionMesual>();
            PesoTalla = new HashSet<PesoTalla>();
            PruebaBeck = new HashSet<PruebaBeck>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public int Anioscondiabetes { get; set; }
        public string ApellidoPater { get; set; }
        public string ApellidoMater { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public ICollection<Calendario7pasos> Calendario7pasos { get; set; }
        public ICollection<Citas> Citas { get; set; }
        public ICollection<Conferencias> Conferencias { get; set; }
        public ICollection<MedicionHb1c> MedicionHb1c { get; set; }
        public ICollection<MedicionMesual> MedicionMesual { get; set; }
        public ICollection<PesoTalla> PesoTalla { get; set; }
        public ICollection<PruebaBeck> PruebaBeck { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
