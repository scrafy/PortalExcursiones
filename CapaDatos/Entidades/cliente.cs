using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CapaDatos.Properties;
using CapaDatos.Infraestructura.AtributosValidacion;

namespace CapaDatos.Entidades
{
    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            reservas = new HashSet<reserva>();
        }

        [Key]
        public string usuario_id { get; set; }

        [Required(ErrorMessageResourceName = "error15", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [DNI(ErrorMessageResourceName ="error22",ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(30)]
        public string numidentificacion { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string infadicional { get; set; }

        public virtual usuario usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reservas { get; set; }
    }
}
