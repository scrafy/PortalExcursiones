using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CapaDatos.Entidades
{
    [Table("clavevalor")]
    public class clavevalor
    {
        [Key]
        public string clave { get; set; }
        public string valor { get; set; }
    }
}
