using PortalExcursiones.Modelos.ModelosEntrada;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace PortalExcursiones.Infraestructura.Interfaces
{
    public interface IOperacionesUsuario
    {
        HttpResponseMessage Login(LoginModel login,ModelStateDictionary modelo);
        HttpResponseMessage Logout();
        HttpResponseMessage CambiarPassword(CambioPasswordModel password, ModelStateDictionary modelo);
        HttpResponseMessage ObtenerTokenReseteoPassword(string email);
        HttpResponseMessage RenovarPassword(RenovacionPasswordModel datos, ModelStateDictionary modelo);
        HttpResponseMessage CambiarIdioma(string idioma);
        HttpResponseMessage AnadirRol(RolModel datos);
        HttpResponseMessage EliminarRol(RolModel datos);
    }
}
