using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Infraestructura.AtributosValidacion
{
    public class FechaCalendarioAttribute : ValidationAttribute
    {
        public override bool IsValid(object valor)
        {
            DateTime s = DateTime.Parse(valor.ToString());
            if (s.Year == 1)
            {
                return false;
            }
            return true;
        }
    }
}