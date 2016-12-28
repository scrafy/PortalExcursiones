using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PortalExcursiones.Properties;

namespace PortalExcursiones.Infraestructura.AtributosValidacion
{
    public class HoraAttribute : ValidationAttribute
    {
        public override bool IsValid(object valor)
        {
            DateTime fecha = (DateTime)valor;
            TimeSpan s = new TimeSpan(fecha.Ticks);
            if ((s.Minutes != 30) && (s.Minutes != 0))
            {
                return false;
            }
            return true;
        }
    }
}