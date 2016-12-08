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

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error34", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal pvpadulto { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error35", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal pvpnino { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error36", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal pvpinfante { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error37", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal costeadulto { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error38", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal costenino { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error39", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal costeinfante { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error40", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal netoadulto { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error41", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal netonino { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error42", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal netoinfante { get; set; }

        [Column(TypeName = "uint")]
        [Range(1, Int64.MaxValue, ErrorMessageResourceName = "error43", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public long exact_id { get; set; }

        [JsonIgnore]
        public virtual excursionactividad excursionactividad { get; set; }
    }
}
