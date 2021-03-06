using CapaDatos.Properties;
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
            fotos = new HashSet<fotoconfiguracion>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required(ErrorMessageResourceName = "error10",ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string nombre { get; set; }

        public bool ocultarweb { get; set; }

        [StringLength(100)]
        public string video { get; set; }

        [StringLength(100)]
        public string tadvisor { get; set; }

        [Required(ErrorMessageResourceName = "error20", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(50)]
        public string lat { get; set; }

        [Required(ErrorMessageResourceName = "error21", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(50)]
        public string lng { get; set; }

        [StringLength(255)]
        [Required(ErrorMessageResourceName = "error48", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string direccion { get; set; }

        [Required(ErrorMessageResourceName = "error24", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(100)]
        public string logo { get; set; }

        [Range(1,double.MaxValue,ErrorMessageResourceName = "error35", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public decimal porcentaje { get; set; }

        [Required(ErrorMessageResourceName = "error25", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string proveedor_id { get; set; }

        [Required(ErrorMessageResourceName = "error14", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public long localidad_id { get; set; }

        public virtual alquilervehiculo alquilervehiculo { get; set; }

        public virtual proveedor proveedor { get; set; }

        public virtual excursionactividad excursionactividad { get; set; }

        public virtual localidad localidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fotoconfiguracion> fotos { get; set; }
    }
}
