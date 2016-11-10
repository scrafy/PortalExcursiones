namespace CapaDatos.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("proveedor")]
    public partial class proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proveedor()
        {
            configuraciones = new HashSet<configuracion>();
            reservas = new HashSet<reserva>();
        }

        [Key]
        [Column(TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long usuario_id { get; set; }

        [Required]
        [StringLength(45)]
        public string nombreempresa { get; set; }

        [Required]
        [StringLength(45)]
        public string cif { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string observaciones { get; set; }

        [Required]
        [StringLength(60)]
        public string lat { get; set; }

        [Required]
        [StringLength(60)]
        public string lng { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<configuracion> configuraciones { get; set; }

        public virtual usuario usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reservas { get; set; }
    }
}
