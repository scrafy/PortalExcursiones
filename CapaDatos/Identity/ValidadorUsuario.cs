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
        private AdministradorUsuario administrador = null;

        public ValidadorUsuario(AdministradorUsuario _administrador) : base(_administrador)
        {
            administrador = _administrador;
        }

        public override async Task<IdentityResult> ValidateAsync(usuario item)
        {
            var errors = new List<string>();

            var usuario = Contexto.Crear().Users.Where(e => e.UserName == item.UserName || e.Email == item.Email).FirstOrDefault();
            if(usuario.UserName == item.UserName)
            {
                errors.Add(String.Format("El nombre de usuario {0} ya existe,por favor,elija otro diferente",item.UserName));
            }
            if (usuario.Email == item.Email)
            {
                errors.Add(String.Format("La dirección de correo {0} ya existe,por favor,elija otra diferente", item.Email));
            }
            
            return errors.Any() ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }
    }
}
