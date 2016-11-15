using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("calendarioexcursion_puntorecogida")]
    public partial class calendarioexcursion_puntorecogida
    {
        [Key]
        [Column(Order = 0, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime fecha { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long puntorecogida_id { get; set; }

        public TimeSpan hora { get; set; }

        public virtual calendarioexcursion calendarioexcursion { get; set; }

        public virtual puntorecogida puntorecogida { get; set; }
    }
}
