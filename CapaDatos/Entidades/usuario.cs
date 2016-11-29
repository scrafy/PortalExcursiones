using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace CapaDatos.Entidades
{
    [DataContract]
    public partial class usuario : IdentityUser
    {

        public usuario()
        {

        }

        public usuario(string username)
            :base(username)
        {

        }

        [Required(ErrorMessage = "Campo id requerido")]
        [StringLength(128)]
        [Key]
        [Column("id")]
        [DataMember(Name = "id")]
        public override string Id { get; set; }

        [Required(ErrorMessage = "Campo mail requerido")]
        [StringLength(60)]
        [Column("mail",TypeName ="varchar")]
        [Index(IsUnique =true)]
        [DataMember(Name = "mail")]
        public override string Email { get; set; }

        [Required(ErrorMessage = "Campo usuario requerido")]
        [StringLength(60)]
        [Column("username", TypeName = "varchar")]
        [Index(IsUnique = true)]
        [DataMember(Name = "usuario")]
        public override string UserName { get; set; }

        [Required(ErrorMessage = "Campo password requerido")]
        [Column("contrasena", TypeName = "text")]
        [DataMember(Name ="password")]
        public override string PasswordHash { get; set; }

        [Required(ErrorMessage = "Campo telefono requerido")]
        [StringLength(30)]
        [Column("telefono", TypeName = "varchar")]
        [DataMember(Name = "telefono")]
        public override string PhoneNumber { get; set; }

        [Required]
        [StringLength(45)]
        [DataMember(Name = "nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo primer apellido requerido")]
        [StringLength(45)]
        [DataMember(Name = "primerapellido")]
        public string primerapellido { get; set; }

        [Required]
        [StringLength(45)]
        [DataMember(Name = "segundoapellido")]
        public string segundoapellido { get; set; }


        [Required]
        [StringLength(255)]
        [DataMember(Name = "direccion1")]
        public string direccion1 { get; set; }

        [StringLength(255)]
        [DataMember(Name = "direccion2")]
        public string direccion2 { get; set; }

        [Column(TypeName = "uint")]
        [DataMember(Name = "localidad")]
        [Range(1, long.MaxValue, ErrorMessage = "Campo localidad requerido")]
        public long localidad_id { get; set; }




        public virtual cliente cliente { get; set; }

        public virtual colaborador colaborador { get; set; }

        public virtual guia guia { get; set; }

        public virtual localidad localidad { get; set; }

        public virtual proveedor proveedor { get; set; }

    }
}
