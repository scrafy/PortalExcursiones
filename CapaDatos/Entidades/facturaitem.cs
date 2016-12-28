using CapaDatos.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("facturaitem")]
    public partial class facturaitem
    {
       
        public facturaitem()
        {
            excursiones = new HashSet<facturaitem_exact>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required(ErrorMessageResourceName = "error10", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(45)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        [Required(ErrorMessageResourceName = "error53", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string descripcion { get; set; }

        public virtual ICollection<facturaitem_exact> excursiones { get; set; }
    }
}
