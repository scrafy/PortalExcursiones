namespace CapaDatos.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [Column(TypeName = "uint")]
        public long id { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        [Required]
        [StringLength(45)]
        public string primerapellido { get; set; }

        [Required]
        [StringLength(45)]
        public string segundoapellido { get; set; }

        [Required]
        [StringLength(60)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string direccion1 { get; set; }

        [StringLength(255)]
        public string direccion2 { get; set; }

        [Required]
        [StringLength(30)]
        public string telefono1 { get; set; }

        [StringLength(30)]
        public string telefono2 { get; set; }

        [Column(TypeName = "uint")]
        public long localidad_id { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual colaborador colaborador { get; set; }

        public virtual guia guia { get; set; }

        public virtual localidad localidad { get; set; }

        public virtual proveedor proveedor { get; set; }
    }
}
