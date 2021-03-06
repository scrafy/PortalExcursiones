using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("excursion_contiene_item")]
    public partial class excursion_contiene_item
    {
        [Key]
        [Column(Order = 0, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long item_id { get; set; }

        public virtual excursionactividad excursionactividad { get; set; }

        public virtual item item { get; set; }
    }
}
