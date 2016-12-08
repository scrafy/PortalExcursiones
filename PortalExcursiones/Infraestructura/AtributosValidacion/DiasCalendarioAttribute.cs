using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PortalExcursiones.Infraestructura.Enumeraciones;
using PortalExcursiones.Properties;

namespace PortalExcursiones.Infraestructura.AtributosValidacion
{
    public class DiasCalendarioAttribute : ValidationAttribute
    {
        public override bool IsValid(object valor)
        {
            List<string> dias = (List<string>)valor;
            if (valor == null) return true;
            if(dias.Count == 0)
            {
                this.ErrorMessage = ErroresValidacion.error9;
                return false;
            }
            List<string> listadias = new List<string>(Enum.GetNames(typeof(DiasSemana)));
            foreach(var dia in dias)
            {
                if(!listadias.Contains(dia))
                {
                    this.ErrorMessage = ErroresValidacion.error10;
                    return false;
                }
            }
            return true;

        }
    }
}