using PortalExcursiones.Properties;
using System.ComponentModel.DataAnnotations;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class LoginModel
    {
        private string username;
        private string password;

        [Required(ErrorMessageResourceName = "error30", ErrorMessageResourceType = typeof(ErroresValidacion))]
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        [Required(ErrorMessageResourceName =  "error7", ErrorMessageResourceType = typeof(ErroresValidacion))]
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

        public LoginModel() { }
    }
}