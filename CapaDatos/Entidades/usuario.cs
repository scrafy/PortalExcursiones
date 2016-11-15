using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CapaDatos.Entidades
{
    
    public partial class usuario : IdentityUser
    {

        public usuario()
        {

        }

        public usuario(string username)
            :base(username)
        {

        }

        [Required]
        [StringLength(60)]
        [Column("mail",TypeName ="varchar")]
        [Index(IsUnique =true)]
        public override string Email { get; set; }

        [Required]
        [StringLength(60)]
        [Column("username", TypeName = "varchar")]
        [Index(IsUnique = true)]
        public override string UserName { get; set; }

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
        [StringLength(255)]
        public string direccion1 { get; set; }

        [StringLength(255)]
        public string direccion2 { get; set; }

        [Column(TypeName = "uint")]
        public long localidad_id { get; set; }




        public virtual cliente cliente { get; set; }

        public virtual colaborador colaborador { get; set; }

        public virtual guia guia { get; set; }

        public virtual localidad localidad { get; set; }

        public virtual proveedor proveedor { get; set; }

    }
}
