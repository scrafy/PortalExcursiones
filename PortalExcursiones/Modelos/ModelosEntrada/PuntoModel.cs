namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class PuntoModel
    {
        private long exact_id;
        private long punto_id;

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

        public long Punto_id
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
    }
}