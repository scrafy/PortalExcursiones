namespace CapaDatos.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("preciotemporada")]
    public partial class preciotemporada
    {
        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Column(TypeName = "date")]
        public DateTime desde { get; set; }

        [Column(TypeName = "date")]
        public DateTime hasta { get; set; }

        public decimal pvpadulto { get; set; }

        public decimal pvpnino { get; set; }

        public decimal pvpinfante { get; set; }

        public decimal costeadulto { get; set; }

        public decimal costenino { get; set; }

        public decimal costeinfante { get; set; }

        public decimal netoadulto { get; set; }

        public decimal netonino { get; set; }

        public decimal netoinfante { get; set; }

        [Column(TypeName = "uint")]
        public long exact_id { get; set; }

        public virtual excursionactividad excursionactividad { get; set; }
    }
}
