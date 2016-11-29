using Microsoft.AspNet.Identity;
using CapaDatos.Entidades;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;
using System.Web;

namespace CapaDatos.Identity
{
    public class ValidadorUsuario : UserValidator<usuario>
    {
        private AdministradorUsuario adminsitrador;

        public ValidadorUsuario(AdministradorUsuario _administrador) 
            : base(_administrador)
        {
            this.adminsitrador = _administrador;
        }

        public override async Task<IdentityResult> ValidateAsync(usuario item)
        {
            var errors = new List<string>();
            bool ispost = false;
            var usuario = await this.adminsitrador.FindByIdAsync(item.Id);
            if(usuario == null)
                ispost = true;
            var usuarios = new List<usuario>();
            if(ispost)
            {
                 usuarios = this.adminsitrador.Users.Where(e => e.UserName == item.UserName || e.Email == item.Email).ToList();
            }
            else
            {
                 usuarios = this.adminsitrador.Users.Where(e => (e.UserName == item.UserName || e.Email == item.Email) && e.Id != item.Id).ToList();
            }
            if (usuarios.Count() == 0)
            {
                return IdentityResult.Success;
            }
            if (usuarios.Where(e => e.UserName == item.UserName).FirstOrDefault() != null)
            {
                errors.Add(String.Format("El nombre de usuario {0} ya existe,por favor,elija otro diferente", item.UserName));
            }
            if (usuarios.Where(e => e.Email == item.Email).FirstOrDefault() != null)
            {
                errors.Add(String.Format("La dirección de correo {0} ya existe,por favor,elija otra diferente", item.Email));
            }
            return errors.Any() ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }
    }
}
