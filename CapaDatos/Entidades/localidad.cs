using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{

    [Table("localidad")]
    public partial class localidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public localidad()
        {
            recogidasdevoluciones = new HashSet<recogidadevolucion>();
            puntosrecogida = new HashSet<puntorecogida>();
            reservas = new HashSet<reservaexcursionactividad>();
            usuarios = new HashSet<usuario>();
            configuraciones = new HashSet<configuracion>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required]
        [StringLength(45)]
        [Index(IsUnique = true)]
        public string nombre { get; set; }

        public int cp { get; set; }

        [Column(TypeName = "uint")]
        
        public long provincia_id { get; set; }

        [ForeignKey("provincia_id")]
        public virtual provincia provincia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recogidadevolucion> recogidasdevoluciones{ get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<puntorecogida> puntosrecogida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservaexcursionactividad> reservas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<configuracion> configuraciones { get; set; }
    }
}
