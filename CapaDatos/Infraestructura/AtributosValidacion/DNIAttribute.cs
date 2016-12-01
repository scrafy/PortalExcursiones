using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace CapaDatos.Infraestructura.AtributosValidacion
{
    public sealed class DNIAttribute : ValidationAttribute
    {
        private string correspondencia = "TRWAGMYFPDXBNJZSQVHLCKET";

        public override bool IsValid(object identificacion)
        {
            string valueToValid = (identificacion ?? string.Empty).ToString();

            if(!string.IsNullOrEmpty(valueToValid))
            {
                var nie = DeleteInvalidChars(valueToValid);
                var initialLetter = nie.FirstOrDefault().ToString();
                if(initialLetter.Contains("XYZ"))
                    return ValidarNIE(identificacion);
                else
                    return ValidarNIF(identificacion);
            }
            return true;
        }

        private bool ValidarNIF(object value)
        {
            string initialLetter = string.Empty;
            string controlDigit = string.Empty;
            int dniNumber;
            string valueToValid = (value ?? string.Empty).ToString();

            // Value is not null.
            if (!string.IsNullOrEmpty(valueToValid))
            {
                // The excess characters are deleted.
                string nif = DeleteInvalidChars(valueToValid);

                // Check NIF length.
                if (nif.Length != 9)
                    return false;

                // Check NIF format.
                if (!Regex.IsMatch(nif, @"[0-9]{8,10}[" + correspondencia + "]$"))
                    return false;

                initialLetter = string.Empty;
                Int32.TryParse(nif.Substring(0, 8), out dniNumber);
                controlDigit = nif.LastOrDefault().ToString();

                // Check letter.
                if (controlDigit != GetLetter(dniNumber))
                    return false;

            }

            return true;
        }
        
        private bool ValidarNIE(object value)
        {
            string initialLetter = string.Empty;
            string controlDigit = string.Empty;
            int dniNumber;
            string valueToValid = (value ?? string.Empty).ToString();

            // Value is not null.
            if (!string.IsNullOrEmpty(valueToValid))
            {
                // The excess characters are deleted.
                string nie = DeleteInvalidChars(valueToValid);

                // Check NIE length.
                if (nie.Length != 9 && nie.Length != 11)
                    return false;

                // Check NIE format.
                if (!Regex.IsMatch(nie, @"[K-MX-Z]\d{7}[" + correspondencia + "]$"))
                    return  false;

                initialLetter = nie.FirstOrDefault().ToString();
                Int32.TryParse(nie.Substring(1, 7), out dniNumber);
                controlDigit = nie.LastOrDefault().ToString();

                switch (initialLetter)
                {
                    case "X":
                        break;
                    case "Y":
                        dniNumber += 10000000;
                        break;
                    case "Z":
                        dniNumber += 20000000;
                        break;
                }

                // Check letter.
                if (controlDigit != GetLetter(dniNumber))
                    return false;

            }

            return true;
        }

        private string DeleteInvalidChars(string numero)
        {
            // All characters that are not numbers or letters.
            string chars = @"[^\w]";
            Regex regex = new Regex(chars);
            return regex.Replace(numero, string.Empty).ToUpper();
        }

        private string GetLetter(int numeroDNI)
        {
            int indice = numeroDNI % 23;
            return correspondencia[indice].ToString();
        }

       

    }
}
