using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.FacBackend
{
    public class MadreDeAtleta
    {
        public int Id { get; set; }
        public int IdAtleta { get; set; }
        public string? NombreMadre { get; set; }
        public string? ApellidoMadre { get; set; }
        public long? DniMadre { get; set; }
        public string? CelularMadre { get; set; }
        public string? EmailMadre { get; set; }
        public string? DireccionMadre { get; set; }
        public string? FotoDniFrontalMadre { get; set; }
        public string? FotoDniDorsalMadre { get; set; }

        //Relacion
        public virtual List<Atleta> AtletaList { get; set; }
    }
}
