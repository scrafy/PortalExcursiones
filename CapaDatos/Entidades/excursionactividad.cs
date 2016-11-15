using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
   
    [Table("excursionactividad")]
    public partial class excursionactividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public excursionactividad()
        {
            fechas = new HashSet<calendarioexcursion>();
            items = new HashSet<excursion_contiene_item>();
            precios = new HashSet<preciotemporada>();
        }

        [Key]
        [Column(TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }

        public short duracion { get; set; }

        public short minpersonas { get; set; }

        public short maxpersonas { get; set; }

        public decimal? descuento { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string queharas { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string queesperar { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string noincluye { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string antesdeir { get; set; }

        public bool esexcursion { get; set; }
               
        public bool secontabilizaninfantes { get; set; }

        public bool pickupservice { get; set; }

        [Column(TypeName = "uint")]
        public long destino_id { get; set; }

        public byte? tipoexcursion_id { get; set; }

        public byte? tipoactividad_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calendarioexcursion> fechas { get; set; }

        public virtual categoriactividad categoriactividad { get; set; }

        public virtual categoriaexcursion categoriaexcursion { get; set; }

        public virtual configuracion configuracion { get; set; }

        public virtual destino destino { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<excursion_contiene_item> items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<preciotemporada> precios { get; set; }
    }
}
