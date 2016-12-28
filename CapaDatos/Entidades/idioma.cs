using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("idioma")]
    public partial class idioma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public idioma()
        {
            idiomas = new HashSet<idioma_exact>();
        }

        [Column(TypeName = "usmallint")]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string lenguage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<idioma_exact> idiomas { get; set; }
    }
}
