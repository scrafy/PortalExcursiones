using System;
using System.ComponentModel.DataAnnotations;


namespace PortalExcursiones.CapaDatos.Infraestructura.AtributosValidacion
{
    public class FechaAttribute : ValidationAttribute
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