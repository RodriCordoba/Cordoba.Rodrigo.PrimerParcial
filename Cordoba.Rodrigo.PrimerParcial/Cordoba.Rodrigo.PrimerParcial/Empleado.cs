using System.Text.Json.Serialization;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public class Empleado
    {
        [JsonPropertyName("apellido")]
        public string Apellido { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("legajo")]
        public int Legajo { get; set; }

        [JsonPropertyName("correo")]
        public string Correo { get; set; }

        [JsonPropertyName("clave")]
        public string Clave { get; set; }

        [JsonPropertyName("perfil")]
        public string Perfil { get; set; }
    }
}
