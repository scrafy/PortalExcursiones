namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class ReservaExcursionActividadModel
    {
       
        private byte numadultos;

        private byte numninos;

        private byte numinfantes;

        private byte numjuniors;

        private byte numseniors;

        private string direccion;

        private string nombrehotel;

        private string observaciones;

        private int localidad_id;

        private long calendario_id;

        private string colaborador_id;

        private string cliente_id;

        private long? punto_id;

        private long exact_id;

        public byte Numadultos
        {
            get
            {
                return numadultos;
            }

            set
            {
                numadultos = value;
            }
        }

        public byte Numninos
        {
            get
            {
                return numninos;
            }

            set
            {
                numninos = value;
            }
        }

        public byte Numinfantes
        {
            get
            {
                return numinfantes;
            }

            set
            {
                numinfantes = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Nombrehotel
        {
            get
            {
                return nombrehotel;
            }

            set
            {
                nombrehotel = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public int Localidad_id
        {
            get
            {
                return localidad_id;
            }

            set
            {
                localidad_id = value;
            }
        }

        public string Colaborador_id
        {
            get
            {
                return colaborador_id;
            }

            set
            {
                colaborador_id = value;
            }
        }

        public string Cliente_id
        {
            get
            {
                return cliente_id;
            }

            set
            {
                cliente_id = value;
            }
        }

        public long? Punto_id
        {
            get
            {
                return punto_id;
            }

            set
            {
                punto_id = value;
            }
        }

        public long Calendario_id
        {
            get
            {
                return calendario_id;
            }

            set
            {
                calendario_id = value;
            }
        }

        public byte Numjuniors
        {
            get
            {
                return numjuniors;
            }

            set
            {
                numjuniors = value;
            }
        }

        public byte Numseniors
        {
            get
            {
                return numseniors;
            }

            set
            {
                numseniors = value;
            }
        }

        public long Exact_id
        {
            get
            {
                return exact_id;
            }

            set
            {
                exact_id = value;
            }
        }
    }
}