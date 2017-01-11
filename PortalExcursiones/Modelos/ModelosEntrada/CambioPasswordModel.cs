using PortalExcursiones.Properties;
using System.ComponentModel.DataAnnotations;


namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class CambioPasswordModel
    {
        
        private string passantiguo;
        private string passnuevo;
        private string confpassnuevo;


        public CambioPasswordModel()
        {

        }

        [Required(ErrorMessageResourceName = "error1", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [RegularExpression("^[a-zA-Z0-9]{6,}$", ErrorMessageResourceName = "error2", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Passantiguo
        {
            get
            {
                return passantiguo;
            }

            set
            {
                passantiguo = value;
            }
        }

        [Required(ErrorMessageResourceName = "error3", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [RegularExpression("^[a-zA-Z0-9]{6,}$", ErrorMessageResourceName = "error4", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Passnuevo
        {
            get
            {
                return passnuevo;
            }

            set
            {
                passnuevo = value;
            }
        }

        [Required(ErrorMessageResourceName = "error33", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [RegularExpression("^[a-zA-Z0-9]{6,}$", ErrorMessageResourceName = "error32", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Confpassnuevo
        {
            get
            {
                return confpassnuevo;
            }

            set
            {
                confpassnuevo = value;
            }
        }
    }
}