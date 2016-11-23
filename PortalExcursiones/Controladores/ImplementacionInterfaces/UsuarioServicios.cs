using CapaDatos.Entidades;
using PortalExcursiones.Controladores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace PortalExcursiones.Controladores.ImplementacionInterfaces
{
    public class UsuarioServicios : IOperacionesComunes<usuario>
    {
        public HttpResponseMessage Actualizar(usuario Entidad)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage BusquedaPorId(string id)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Crear(usuario Entidad)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Todos()
        {
            throw new NotImplementedException();
        }
    }
}