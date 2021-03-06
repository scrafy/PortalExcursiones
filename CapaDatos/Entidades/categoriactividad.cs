using CapaDatos.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("categoriactividad")]
    public partial class categoriactividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categoriactividad()
        {
            excursionesactividades = new HashSet<excursionactividad>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte id { get; set; }

        [Required(ErrorMessageResourceName = "error10",ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<excursionactividad> excursionesactividades { get; set; }
    }
}
