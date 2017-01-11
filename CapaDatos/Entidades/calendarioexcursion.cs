using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("calendarioexcursion")]
    public partial class calendarioexcursion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public calendarioexcursion()
        {
           reservas = new HashSet<reservaexcursionactividad>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

       
        [Column(TypeName = "uint")]
        public long exact_id { get; set; }

            
        public DateTime fecha { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string motivoanulacion { get; set; }


        public byte estadoexcursion_id { get; set; }

        public virtual estadoexcursion estadoexcursion { get; set; }

        public virtual excursionactividad excursionactividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservaexcursionactividad> reservas { get; set; }
    }
}
