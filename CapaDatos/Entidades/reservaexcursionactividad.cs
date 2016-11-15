using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("reservaexcursionactividad")]
    public partial class reservaexcursionactividad
    {
        [Key]
        [Column(TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long reserva_id { get; set; }

        public byte numadultos { get; set; }

        public byte numninos { get; set; }

        public byte numinfantes { get; set; }

        [StringLength(255)]
        public string direccion { get; set; }

        [StringLength(45)]
        public string nombrehotel { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string observaciones { get; set; }

        [Column(TypeName = "uint")]
        public long? localidad_id { get; set; }

        public DateTime fecha { get; set; }

        [Column(TypeName = "uint")]
        public long exact_id { get; set; }

        public virtual calendarioexcursion calendarioexcursion { get; set; }

        public virtual localidad localidad { get; set; }

        public virtual reserva reserva { get; set; }
    }
}
