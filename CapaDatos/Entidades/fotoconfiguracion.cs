using CapaDatos.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("fotoconfiguracion")]
    public partial class fotoconfiguracion
    {
        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required(ErrorMessageResourceName ="error47",ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(100)]
        public string url { get; set; }

        [Required(ErrorMessageResourceName = "error10", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(45)]
        public string nombre { get; set; }

        [Column(TypeName = "uint")]
        public long configuracion_id { get; set; }

        public virtual configuracion configuracion { get; set; }
    }
}
