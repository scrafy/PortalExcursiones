namespace CapaDatos.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        public int cp { get; set; }

        [Column(TypeName = "uint")]
        public long provincia_id { get; set; }

        public virtual provincia provincia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recogidadevolucion> recogidasdevoluciones{ get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<puntorecogida> puntosrecogida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservaexcursionactividad> reservas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuarios { get; set; }
    }
}