using CapaDatos.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("destino")]
    public partial class destino
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public destino()
        {
            excursionesactividades = new HashSet<excursionactividad>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required(ErrorMessageResourceName = "error10", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<excursionactividad> excursionesactividades { get; set; }
    }
}
