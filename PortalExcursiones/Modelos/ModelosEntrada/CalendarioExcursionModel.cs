using PortalExcursiones.Infraestructura.AtributosValidacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class CalendarioExcursionModel
    {
        private DateTime desde;
        private DateTime hasta;
        private List<string> horarios;
        private List<string> dias;

        [FechaCalendario(ErrorMessage = "El campo fecha desde es requerido")]
        public DateTime Desde
        {
            get
            {
                return desde;
            }

            set
            {
                desde = value;
            }
        }

        [FechaCalendario(ErrorMessage = "El campo fecha hasta es requerido")]
        public DateTime Hasta
        {
            get
            {
                return hasta;
            }

            set
            {
                hasta = value;
            }
        }

        [Required(ErrorMessage = "El campo horarios es requerido")]
        [Horarios(ErrorMessage = "Alguna de las horas introducidas tiene un formato incorrecto")]
        public List<string> Horarios
        {
            get
            {
                return horarios;
            }

            set
            {
                horarios = value;
            }
        }

        [Required()]
        public List<string> Dias
        {
            get
            {
                return dias;
            }

            set
            {
                dias = value;
            }
        }

        public CalendarioExcursionModel() { }
    }
}