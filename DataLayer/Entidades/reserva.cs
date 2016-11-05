namespace CapaDatos.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

        [Column(TypeName = "uint")]
        public long cliente_id { get; set; }

        [Column(TypeName = "uint")]
        public long proveedor_id { get; set; }

        [Column(TypeName = "uint")]
        public long? colaborador_id { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual colaborador colaborador { get; set; }

        public virtual proveedor proveedor { get; set; }

        public virtual reservaexcursionactividad reservaexcursionactividad { get; set; }

        public virtual reservavehiculo reservavehiculo { get; set; }
    }
}
