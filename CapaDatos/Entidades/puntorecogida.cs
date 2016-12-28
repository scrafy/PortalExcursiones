using CapaDatos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos.Entidades
{
    [Table("puntorecogida")]
    public partial class puntorecogida
    {
       
        public puntorecogida()
        {
            configuraciones = new HashSet<puntorecogida_exact>();
            reservas = new HashSet<reservaexcursionactividad>();
        }

        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required(ErrorMessageResourceName = "error10", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(255)]
        [Index(IsUnique = true)]
        public string nombre { get; set; }

        [Required(ErrorMessageResourceName = "error20", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(50)]
        public string lat { get; set; }

        [Required(ErrorMessageResourceName = "error21", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(50)]
        public string lng { get; set; }

        [Required(ErrorMessageResourceName = "error46", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(255)]
        public string direccion { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string descripcion { get; set; }

        [Column(TypeName = "uint")]
        [Range(1,Int64.MaxValue,ErrorMessageResourceName = "error14", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public long localidad_id { get; set; }

        public virtual localidad localidad { get; set; }

        public virtual ICollection<puntorecogida_exact> configuraciones { get; set; }

        public virtual ICollection<reservaexcursionactividad> reservas { get; set; }
    }
}
