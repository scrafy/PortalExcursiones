using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Infraestructura
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class ValidacionContrasenaAttribute : ValidationAttribute
    {
        public ValidacionContrasenaAttribute()
        { }
    }
}
