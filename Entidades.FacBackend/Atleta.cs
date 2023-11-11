using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.FacBackend
{
    public class Atleta
    {
        public int Id { get; set; }
        public int? MadreAtletaId { get; set; }
        public int? PadreAtletaId { get; set; }
        public int? TutorAtletaId { get; set; }
        public string NombreAtleta { get; set; }
        public string ApellidoAtleta { get; set; }
        public string Nacionalidad { get; set; }
        public long DniAtleta { get; set; }
        public string? NumeroDePasaporte { get; set; }
        public string DireccionAtleta { get; set; }
        public string? EmailAtleta { get; set; }
        public DateTime FechaDeNacimientoAtleta { get; set; }
        public string? CelularAtleta { get; set; }
        public string Club { get; set; }
        public bool? ObraSocialAtleta { get; set; }
        public string? NumeroCarnetObraSocial { get; set; }
        public bool? PermisoDeViaje { get; set; }
        public bool? Beca { get; set; }
        public string FotoDniFrontalAtleta { get; set; }
        public string FotoDniDorsalAtleta { get; set; }
        public string FotoPasaporteFrontalAtleta { get; set; }
        public string FotoPasaporteDorsalAtleta { get; set; }

        //Relaciones
        public virtual MadreDeAtleta MadreAtleta { get; set; }
        public virtual PadreDeAtleta PadreAtleta { get; set; }
        public virtual TutorDeAtleta TutorAtleta { get; set; }

    }
}
