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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<usuario> manager, string authenticationType)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }


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
