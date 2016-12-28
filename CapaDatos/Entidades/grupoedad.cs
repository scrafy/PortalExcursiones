using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CapaDatos.Properties;


namespace CapaDatos.Entidades
{
    [Table("grupoedad")]
    public partial class grupoedad
    {
        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required(ErrorMessageResourceName = "error51", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(100)]
        public string genero { get; set; }

        [Range(1,int.MaxValue,ErrorMessageResourceName = "error49", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public byte edaddesde { get; set; }

        [Range(1, int.MaxValue, ErrorMessageResourceName = "error50", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public byte edadhasta { get; set; }

        [Column(TypeName = "uint")]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "error43", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public long exact_id { get; set; }

        public virtual excursionactividad exact { get; set; }
    }
}
