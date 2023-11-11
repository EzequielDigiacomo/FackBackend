using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.FacBackend
{
    public class TutorDeAtleta
    {
        public int Id { get; set; }
        public int IdAtleta { get; set; }
        public string? NombreTutor { get; set; }
        public string? ApellidoTutor { get; set; }
        public long? DniTutor { get; set; }
        public string? CelularTutor { get; set; }
        public string? EmailTutor { get; set; }
        public string? DireccionTutor { get; set; }
        public string? FotoDniFrontalTutor { get; set; }
        public string? FotoDniDorsalTutor { get; set; }

        //Relacion
        public virtual List<Atleta> AtletaList { get; set; }
    }
}
