using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.FacBackend.DTOs.TutorDto
{
    public class TutorCreateDto
    {
        public string? NombreTutor { get; set; }
        public string? ApellidoTutor { get; set; }
        public long? DniTutor { get; set; }
        public string? CelularDelTutor { get; set; }
        public string? EmailDelTutor { get; set; }
        public string? DireccionDelTutor { get; set; }
        public string? FotoDniFrontalTutor { get; set; }
        public string? FotoDniDorsalTutor { get; set; }
        public int IdAtleta { get; set; }
    }
}
