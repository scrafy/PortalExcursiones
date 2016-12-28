using CapaDatos.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("facturaitem_exact")]
    public partial class facturaitem_exact
    {
        [Key]
        [Column(Order = 0,TypeName ="uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long item_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long exact_id { get; set; }
        
        public virtual excursionactividad exact { get; set; }

        public virtual facturaitem item { get; set; }

    }
}
