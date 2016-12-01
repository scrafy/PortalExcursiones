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
using CapaDatos.Properties;

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

        [Required(ErrorMessageResourceName = "error2",ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(128)]
        [Key]
        [Column("id")]
        [DataMember(Name = "id")]
        public override string Id { get; set; }

        [Required(ErrorMessageResourceName = "error3", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [RegularExpression("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessageResourceName = "error4", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(60)]
        [Column("mail",TypeName ="varchar")]
        [Index(IsUnique =true)]
        [DataMember(Name = "email")]
        public override string Email { get; set; }

        [Required(ErrorMessageResourceName = "error5", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [RegularExpression("^[a-zA-Z0-9]{6,}$", ErrorMessageResourceName = "error6", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(60)]
        [Column("username", TypeName = "varchar")]
        [Index(IsUnique = true)]
        [DataMember(Name = "usuario")]
        public override string UserName { get; set; }

        //se valida a través del AdministradorUsuario
        [Column("contrasena", TypeName = "text")]
        [DataMember(Name ="password")]
        public override string PasswordHash { get; set; }

        [Required(ErrorMessageResourceName = "error9", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(30)]
        [Column("telefono", TypeName = "varchar")]
        [DataMember(Name = "telefono")]
        public override string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceName = "error10", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(45)]
        [DataMember(Name = "nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessageResourceName = "error11", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(45)]
        [DataMember(Name = "primerapellido")]
        public string primerapellido { get; set; }

        [Required(ErrorMessageResourceName = "error12", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(45)]
        [DataMember(Name = "segundoapellido")]
        public string segundoapellido { get; set; }


        [Required(ErrorMessageResourceName = "error13", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [StringLength(255)]
        [DataMember(Name = "direccion1")]
        public string direccion1 { get; set; }

        [StringLength(255)]
        [DataMember(Name = "direccion2")]
        public string direccion2 { get; set; }

        [Column(TypeName = "uint")]
        [DataMember(Name = "localidad")]
        [Range(1, long.MaxValue, ErrorMessageResourceName = "error14", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public long localidad_id { get; set; }




        public virtual cliente cliente { get; set; }

        public virtual colaborador colaborador { get; set; }

        public virtual guia guia { get; set; }

        public virtual localidad localidad { get; set; }

        public virtual proveedor proveedor { get; set; }

    }
}
