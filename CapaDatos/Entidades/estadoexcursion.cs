using CapaDatos.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("estadoexcursion")]
    public partial class estadoexcursion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estadoexcursion()
        {
            calendarioexcursion = new HashSet<calendarioexcursion>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte id { get; set; }

        [Required(ErrorMessageResourceName = "error10", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(45)]
        [Index(IsUnique = true)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calendarioexcursion> calendarioexcursion { get; set; }
    }
}
