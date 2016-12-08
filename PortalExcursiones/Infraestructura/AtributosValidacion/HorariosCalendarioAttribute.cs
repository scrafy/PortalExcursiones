using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PortalExcursiones.Properties;

namespace PortalExcursiones.Infraestructura.AtributosValidacion
{
    public class HorariosCalendarioAttribute : ValidationAttribute
    {
        public override bool IsValid(object valor)
        {
            List<string> horarios = (List<string>)valor;
            if (valor == null) return true;
            if(horarios.Count == 0)
            {
                this.ErrorMessage = ErroresValidacion.error11;
                return false;
            }
                  
            
            TimeSpan s = new TimeSpan();
            foreach(string hora in horarios)
            {
                if(!TimeSpan.TryParse(hora,out s))
                {
                    this.ErrorMessage = ErroresValidacion.error12;
                    return false;
                }
                if((s.Minutes!=30) && (s.Minutes!=0))
                {
                    this.ErrorMessage = ErroresValidacion.error12;
                    return false;
                }
               
            }
            return true;
        }
    }
}