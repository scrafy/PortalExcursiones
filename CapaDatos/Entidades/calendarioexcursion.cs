namespace CapaDatos.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("calendarioexcursion")]
    public partial class calendarioexcursion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public calendarioexcursion()
        {
            guias = new HashSet<calendarioexcursion_guia>();
            puntosrecogida = new HashSet<calendarioexcursion_puntorecogida>();
            reservas = new HashSet<reservaexcursionactividad>();
        }

        [Key]
        [Column(Order = 0, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime fecha { get; set; }

     
        public byte estadoexcursion_id { get; set; }

        public virtual estadoexcursion estadoexcursion { get; set; }

        public virtual excursionactividad excursionactividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calendarioexcursion_guia> guias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calendarioexcursion_puntorecogida> puntosrecogida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservaexcursionactividad> reservas { get; set; }
    }
}
