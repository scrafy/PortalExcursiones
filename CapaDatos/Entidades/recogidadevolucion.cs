using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("recogidadevolucion")]
    public partial class recogidadevolucion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recogidadevolucion()
        {
            recogidas = new HashSet<reservavehiculo>();
            devoluciones = new HashSet<reservavehiculo>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string lat { get; set; }

        [Required]
        [StringLength(50)]
        public string lng { get; set; }

        [Required]
        [StringLength(255)]
        public string direccion { get; set; }

        [Required]
        [StringLength(45)]
        public string telefono { get; set; }

        [Column(TypeName = "uint")]
        public long localidad_id { get; set; }

        [Column(TypeName = "uint")]
        public long alquiler_id { get; set; }

        public virtual alquilervehiculo alquilervehiculo { get; set; }

        public virtual localidad localidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservavehiculo> recogidas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservavehiculo> devoluciones { get; set; }
    }
}
