using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class RenovacionPasswordModel
    {
        private string userid;
        private string token;
        private string password;

        [Required(ErrorMessage = "El campo userid es requerido")]
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

        [Required(ErrorMessage = "El campo token es requerido")]
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

        [Required(ErrorMessage = "El campo password es requerido")]
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