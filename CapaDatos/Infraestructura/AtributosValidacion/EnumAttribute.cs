using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Infraestructura.AtributosValidacion
{
    public class EnumAttribute : ValidationAttribute
    {
        public override bool IsValid(object valor)
        {
            return true;
        }
    }
}
