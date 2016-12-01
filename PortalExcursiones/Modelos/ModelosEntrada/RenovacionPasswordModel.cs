using PortalExcursiones.Properties;
using System.ComponentModel.DataAnnotations;


namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class RenovacionPasswordModel
    {
        private string userid;
        private string token;
        private string password;

        [Required(ErrorMessageResourceName = "error5", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Userid
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        [Required(ErrorMessageResourceName = "error6", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Token
        {
            get
            {
                return token;
            }

            set
            {
                token = value;
            }
        }

        [Required(ErrorMessageResourceName = "error7", ErrorMessageResourceType = typeof(ErroresValidacion))]
        [RegularExpression("^[a-zA-Z0-9]{6,}$", ErrorMessageResourceName = "error8", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public RenovacionPasswordModel()
        {

        }

       
    }
}