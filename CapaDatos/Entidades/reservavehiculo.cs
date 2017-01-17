using CapaDatos.Infraestructura.Json;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("reservavehiculo")]
    public partial class reservavehiculo
    {
        [Key]
        [Column(TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long reserva_id { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime fecha_entrega { get; set; }

        public byte numdias { get; set; }

        public byte numhoras { get; set; }

        [Column(TypeName = "uint")]
        public long vehiculo_id { get; set; }

        [Column(TypeName = "uint")]
        public long puntorecogida_id { get; set; }

        [Column(TypeName = "uint")]
        public long puntodevolucion_id { get; set; }

        public virtual recogidadevolucion puntorecogida { get; set; }

        public virtual recogidadevolucion puntodevolucion { get; set; }

        public virtual reserva reserva { get; set; }

        public virtual vehiculo vehiculo { get; set; }
    }
}
