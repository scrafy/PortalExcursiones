using CapaDatos.Properties;
using System;
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
            idiomas = new HashSet<idioma_exact>();
            puntos_recogida = new HashSet<puntorecogida_exact>();
            grupoedades = new HashSet<grupoedad>();
            factura_items = new HashSet<facturaitem_exact>();
        }

        [Key]
        [Column(TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }

        public short duracion { get; set; }

        [Required(ErrorMessageResourceName = "error52", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(60)]
        public string tipoduracion { get; set; }

        [Range(1, Int16.MaxValue, ErrorMessageResourceName = "error27", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public short minpersonas { get; set; }

        [Range(1, Int16.MaxValue, ErrorMessageResourceName = "error28", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public short maxpersonas { get; set; }

        public decimal? descuento { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessageResourceName = "error29", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(65535)]
        public string queharas { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessageResourceName = "error33", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(65535)]
        public string queesperar { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessageResourceName = "error31", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(65535)]
        public string noincluye { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessageResourceName = "error32", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(65535)]
        public string antesdeir { get; set; }

        public bool esexcursion { get; set; }
               
        public bool secontabilizaninfantes { get; set; }

        public bool pickupservice { get; set; }

        [Column(TypeName = "uint")]
        [Range(1,Int16.MaxValue,ErrorMessageResourceName = "error30", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public long destino_id { get; set; }

        public byte? tipoexcursion_id { get; set; }

        public byte? tipoactividad_id { get; set; }


        public virtual categoriactividad categoriactividad { get; set; }

        public virtual categoriaexcursion categoriaexcursion { get; set; }

        public virtual configuracion configuracion { get; set; }

        public virtual destino destino { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calendarioexcursion> fechas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<excursion_contiene_item> items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<preciotemporada> precios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<idioma_exact> idiomas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupoedad> grupoedades { get; set; }

        public virtual ICollection<puntorecogida_exact> puntos_recogida { get; set; }

        public virtual ICollection<facturaitem_exact> factura_items { get; set; }


    }
}
