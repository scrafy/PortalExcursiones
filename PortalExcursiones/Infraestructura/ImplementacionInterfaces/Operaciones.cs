using PortalExcursiones.Infraestructura.LogicaComun;
using System;
using System.Configuration;


namespace PortalExcursiones.Infraestructura.ImplementacionInterfaces
{
    public abstract class Operaciones
    {
        protected Paginacion Paginacion(int total_reg,int pag_actual,int regxpag)
        {
            var total_registros = total_reg;
            var paginacion = new Paginacion()
            {
                Total_registros = total_reg,
                Total_paginas = (total_registros % regxpag == 0) ? total_registros / regxpag : (total_registros / regxpag) + 1,
                Regxpag = regxpag,
                Pag_actual = pag_actual == 0 ? 1 : pag_actual

            };
            return paginacion;
        }
    }
}