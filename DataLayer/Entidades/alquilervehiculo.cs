namespace CapaDatos.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("alquilervehiculo")]
    public partial class alquilervehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public alquilervehiculo()
        {
          
            recogidasdevoluciones = new HashSet<recogidadevolucion>();
            vehiculos = new HashSet<vehiculo>();
        }

        [Key]
        [Column(TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long alquiler_id { get; set; }


        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string observaciones { get; set; }

      

        public virtual configuracion configuracion { get; set; }

          

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recogidadevolucion> recogidasdevoluciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiculo> vehiculos { get; set; }
    }
}
