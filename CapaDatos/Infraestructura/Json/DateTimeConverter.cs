using Newtonsoft.Json.Converters;


namespace CapaDatos.Infraestructura.Json
{
    public class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            DateTimeFormat = "dd-MM-yyyy HH:mm:ss";
        }
    }


}
