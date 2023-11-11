using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.FacBackend
{
    public class PadreDeAtleta
    {
        public int Id { get; set; }
        public int IdAtleta { get; set; }
        public string? NombrePadre { get; set; }
        public string? ApellidoPadre { get; set; }
        public long? DniPadre { get; set; }
        public string? CelularPadre { get; set; }
        public string? EmailPadre { get; set; }
        public string? DireccionPadre { get; set; }
        public string? FotoDniFrontalPadre { get; set; }
        public string? FotoDniDorsalPadre { get; set; }

        //Relacion

        public virtual List<Atleta> AtletaList { get; set; }
    }
}
