using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PortalExcursiones.Infraestructura.AtributosValidacion
{
    public class HorariosAttribute : ValidationAttribute
    {
        public override bool IsValid(object valor)
        {
            if (valor == null)
                return true;
            List<string> horarios = (List<string>)valor;
            TimeSpan s = new TimeSpan();
            foreach(string hora in horarios)
            {
                if(!TimeSpan.TryParse(hora,out s))
                {
                    return false;
                }
            }
            return true;
        }
    }
}