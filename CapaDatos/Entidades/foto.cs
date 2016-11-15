using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("foto")]
    public partial class foto
    {
        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string url { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        [Column(TypeName = "uint")]
        public long configuracion_id { get; set; }

        public virtual configuracion configuracion { get; set; }
    }
}
