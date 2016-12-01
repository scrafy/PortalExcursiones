using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CapaDatos.Properties;

namespace CapaDatos.Identity
{
    public class ValidadorPassword : IIdentityValidator<string>
    {
        
        public ValidadorPassword()
        {

        }

        public Task<IdentityResult> ValidateAsync(string item)
        {
            var errors = new List<string>();
            if (String.IsNullOrEmpty(item))
            {
                errors.Add(ErroresValidacion.error7);
                return Task.FromResult<IdentityResult>(IdentityResult.Failed(errors.ToArray()));
            }
            if(!Regex.IsMatch(item, "^[a-zA-Z0-9]{6,}$"))
            {
                errors.Add(ErroresValidacion.error8);
                return Task.FromResult<IdentityResult>(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult<IdentityResult>(IdentityResult.Success);
        }
    }
}
