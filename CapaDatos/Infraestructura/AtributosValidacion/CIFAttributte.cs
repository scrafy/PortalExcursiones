using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Infraestructura.AtributosValidacion
{
    public sealed class CIFAttribute : ValidationAttribute
    {

        public override bool IsValid(object identificacion)
        {
            string valueToValid = (identificacion ?? string.Empty).ToString();

            if (String.IsNullOrEmpty(valueToValid))
                return true;

            return Valida_CIF(identificacion.ToString());
        }

        public bool Valida_CIF(string Numero)
        {
            //Valida el cif actual
            string[] letrasCodigo = { "J", "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            string LetraInicial = Numero[0].ToString();
            string DigitoControl = Numero[Numero.Length - 1].ToString();
            string n = Numero.ToString().Substring(1, Numero.Length - 2);
            int sumaPares = 0;
            int sumaImpares = 0;
            int sumaTotal = 0;
            int i = 0;
            bool retVal = false;

            // Recorrido por todos los dígitos del número
            // Recorrido por todos los dígitos del número
            for (i = 0; i < n.Length; i++)
            {
                int aux;
                Int32.TryParse(n[i].ToString(), out aux);

                if ((i + 1) % 2 == 0)
                {
                    // Si es una posición par, se suman los dígitos
                    sumaPares += aux;
                }
                else
                {
                    // Si es una posición impar, se multiplican los dígitos por 2
                    aux = aux * 2;

                    // se suman los dígitos de la suma
                    sumaImpares += SumaDigitos(aux);
                }
            }

            // Se suman los resultados de los números pares e impares
            sumaTotal += sumaPares + sumaImpares;

            // Se obtiene el dígito de las unidades
            Int32 unidades = sumaTotal % 10;

            // Si las unidades son distintas de 0, se restan de 10
            if (unidades != 0) unidades = 10 - unidades;

            switch (LetraInicial)
            {
                // Sólo números
                case "A":
                case "B":
                case "E":
                case "H":
                    retVal = DigitoControl == unidades.ToString();
                    break;

                // Sólo letras
                case "K":
                case "P":
                case "Q":
                case "S":
                    retVal = DigitoControl == letrasCodigo[unidades];
                    break;

                default:
                    retVal = (DigitoControl == unidades.ToString()) || (DigitoControl == letrasCodigo[unidades]);
                    break;
            }

            return retVal;

        }

        private Int32 SumaDigitos(Int32 digitos)
        {
            string sNumero = digitos.ToString();
            Int32 suma = 0;

            for (Int32 i = 0; i < sNumero.Length; i++)
            {
                Int32 aux;
                Int32.TryParse(sNumero[i].ToString(), out aux);
                suma += aux;
            }
            return suma;
        }
    }
}
