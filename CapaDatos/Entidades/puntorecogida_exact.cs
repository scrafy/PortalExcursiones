using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("puntorecogida_exact")]
    public partial class puntorecogida_exact
    {
        [Key]
        [Column(Order = 0, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long punto_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string nota { get; set; }

        [ForeignKey("punto_id")]
        public virtual puntorecogida punto { get; set; }

        [ForeignKey("exact_id")]
        public virtual excursionactividad excursion_actividad { get; set; }
    }
}
