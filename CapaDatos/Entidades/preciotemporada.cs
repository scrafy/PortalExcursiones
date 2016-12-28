using CapaDatos.Properties;
using Newtonsoft.Json;
using PortalExcursiones.CapaDatos.Infraestructura.AtributosValidacion;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("preciotemporada")]
    public partial class preciotemporada
    {
        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Column(TypeName = "date")]
        [Fecha(ErrorMessageResourceName = "error44",ErrorMessageResourceType = typeof(ErroresValidacion))]
        public DateTime desde { get; set; }

        [Column(TypeName = "date")]
        [Fecha(ErrorMessageResourceName = "error45", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public DateTime hasta { get; set; }

        public decimal pvpadulto { get; set; }
               
        public decimal pvpnino { get; set; }
               
        public decimal pvpjunior { get; set; }
                
        public decimal pvpsenior { get; set; }

        public decimal pvpinfante { get; set; }

        public decimal costeadulto { get; set; }
                
        public decimal costenino { get; set; }
                
        public decimal costeinfante { get; set; }
               
        public decimal costejunior{ get; set; }

        public decimal costesenior { get; set; }

        public decimal netoadulto { get; set; }

        public decimal netonino { get; set; }

        public decimal netoinfante { get; set; }

        public decimal netojunior { get; set; }

        public decimal netosenior { get; set; }

        public decimal costegrupo { get; set; }

        public decimal netogrupo { get; set; }

        public decimal pvpgrupo { get; set; }

        [Column(TypeName = "uint")]
        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error43", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public long exact_id { get; set; }

        [JsonIgnore]
        public virtual excursionactividad excursionactividad { get; set; }
    }
}
