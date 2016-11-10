using System.Collections.Generic;
using System.Web.Http.ModelBinding;


namespace PortalExcursiones.Modelos.ModelosSalida.Errores
{
    public class ErrorValidacionFormulario
    {
        private List<string> errores = new List<string>();

        public ErrorValidacionFormulario(ModelStateDictionary modelstate)
        {
           
            foreach (ModelState m in modelstate.Values)
            {
                foreach (ModelError e in m.Errors)
                {
                    this.errores.Add(e.ErrorMessage);
                }
            }
           
        }

        public List<string> Errores
        {
            get
            {
                return errores;
            }

            set
            {
                errores = value;
            }
        }

    }
}