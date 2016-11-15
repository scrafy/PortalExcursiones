using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{

    [Table("calendarioexcursion_guia")]
    public partial class calendarioexcursion_guia
    {
        [Key]
        [Column(Order = 0, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime fecha { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string guia_id { get; set; }

       

        public virtual calendarioexcursion calendarioexcursion { get; set; }

        public virtual guia guia { get; set; }
    }
}
