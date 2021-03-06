using CapaDatos.Infraestructura.AtributosValidacion;
using CapaDatos.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("proveedor")]
    public partial class proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proveedor()
        {
            configuraciones = new HashSet<configuracion>();
            reservas = new HashSet<reserva>();
            facturaitems = new HashSet<facturaitem>();
            puntosrecogida = new HashSet<puntorecogida>();
        }

        [Key]
        public string usuario_id { get; set; }

        [Required(ErrorMessageResourceName = "error18", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(45)]
        public string nombreempresa { get; set; }

        [Required(ErrorMessageResourceName = "error19", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(45)]
        [Index(IsUnique = true)]
        [CIF(ErrorMessageResourceName = "error23", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string cif { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string observaciones { get; set; }

        [Required(ErrorMessageResourceName = "error20", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(60)]
        public string lat { get; set; }

        [Required(ErrorMessageResourceName = "error21", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(60)]
        public string lng { get; set; }

        public bool emailfactura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<configuracion> configuraciones { get; set; }

        public virtual usuario usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reservas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<facturaitem> facturaitems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<puntorecogida> puntosrecogida { get; set; }
    }
}
