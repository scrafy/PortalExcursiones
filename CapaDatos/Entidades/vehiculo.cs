using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("vehiculo")]
    public partial class vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vehiculo()
        {
            reservas = new HashSet<reservavehiculo>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string marca { get; set; }

        [Required]
        [StringLength(100)]
        public string modelo { get; set; }

        [StringLength(45)]
        public string matircula { get; set; }

        public decimal? kilometros { get; set; }

        [Required]
        [StringLength(100)]
        public string imagen { get; set; }

        public decimal preciopordia { get; set; }

        public decimal precioporhora { get; set; }

        public byte maxpasajeros { get; set; }

        [Column(TypeName = "uint")]
        public long alquiler_id { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(2)]
        public string permisorequerido { get; set; }

        public byte tipovehiculo_id { get; set; }

        public virtual alquilervehiculo alquilervehiculo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservavehiculo> reservas { get; set; }

        public virtual tipovehiculo tipovehiculo { get; set; }
    }
}
