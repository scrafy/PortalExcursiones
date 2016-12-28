using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("idioma_exact")]
    public partial class idioma_exact
    {
        [Key]
        [Column(Order = 0, TypeName = "usmallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idioma_id { get; set; }

        [Key]
        [Column(Order = 1,TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }

        public bool guia { get; set; }

        public bool guia_escrita { get; set; }

        public bool audio_auricular { get; set; }

        public virtual idioma idioma { get; set; }

        public virtual excursionactividad excursion_actividad { get; set; }
    }
}
