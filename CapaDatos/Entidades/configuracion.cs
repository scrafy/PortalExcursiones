using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("configuracion")]
    public partial class configuracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public configuracion()
        {
            fotos = new HashSet<foto>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        public bool ocultarweb { get; set; }

        [StringLength(100)]
        public string video { get; set; }

        [StringLength(100)]
        public string tadvisor { get; set; }

        [Required]
        [StringLength(50)]
        public string lat { get; set; }

        [Required]
        [StringLength(50)]
        public string lng { get; set; }

        [Required]
        [StringLength(100)]
        public string logo { get; set; }

        [Required]
        public string proveedor_id { get; set; }

        public virtual alquilervehiculo alquilervehiculo { get; set; }

        public virtual proveedor proveedor { get; set; }

        public virtual excursionactividad excursionactividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<foto> fotos { get; set; }
    }
}
