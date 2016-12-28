namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class IdiomaExActModel
    {
        private int idioma_id;
        private long exact_id;
        private bool guia;
        private bool guia_escrita;
        private bool audio_auricular;

        public int Idioma_id
        {
            get
            {
                return idioma_id;
            }

            set
            {
                idioma_id = value;
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

        public bool Guia
        {
            get
            {
                return guia;
            }

            set
            {
                guia = value;
            }
        }

        public bool Guia_escrita
        {
            get
            {
                return guia_escrita;
            }

            set
            {
                guia_escrita = value;
            }
        }

        public bool Audio_auricular
        {
            get
            {
                return audio_auricular;
            }

            set
            {
                audio_auricular = value;
            }
        }
    }
}