using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("reserva")]
    public partial class reserva
    {
        [Column(TypeName = "uint")]
        public long id { get; set; }

        public DateTime fechatransaccion { get; set; }

        public decimal precio { get; set; }

        [Required]
        [StringLength(100)]
        public string factura { get; set; }

        [Required]
        public string cliente_id { get; set; }

        [Required]
        public string proveedor_id { get; set; }

        public string colaborador_id { get; set; }

        public string codigoqr { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual colaborador colaborador { get; set; }

        public virtual proveedor proveedor { get; set; }

        public virtual reservaexcursionactividad reservaexcursionactividad { get; set; }

        public virtual reservavehiculo reservavehiculo { get; set; }
    }
}
