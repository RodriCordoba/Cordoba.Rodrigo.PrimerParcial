using System;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.Indumentaria
{
    /// <summary>
    /// Clase que proporciona la lógica personalizada de conversión entre objetos de tipo Indumentaria y su representación JSON.
    /// </summary>
    public class IndumentariaConvertidor : JsonConverter<Indumentaria>
    {
        /// <summary>
        /// Lee un objeto de tipo Indumentaria a partir de su representación JSON.
        /// </summary>
        /// <param name="reader">El lector de JSON.</param>
        /// <param name="typeToConvert">El tipo de objeto que se va a convertir.</param>
        /// <param name="options">Opciones de serialización JSON.</param>
        /// <returns>El objeto de tipo Indumentaria.</returns>
        public override Indumentaria Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;
                string tipo = root.GetProperty("Tipo").GetString();

                Indumentaria indumentaria = tipo switch
                {
                    "Campera" => JsonSerializer.Deserialize<Campera>(root.GetRawText(), options),
                    "Remera" => JsonSerializer.Deserialize<Remera>(root.GetRawText(), options),
                    "Pantalon" => JsonSerializer.Deserialize<Pantalon>(root.GetRawText(), options),
                    _ => throw new NotSupportedException($"Tipo {tipo} no soportado")
                };
                return indumentaria;
            }
        }
        /// <summary>
        /// Escribe un objeto de tipo Indumentaria en su representación JSON.
        /// </summary>
        /// <param name="writer">El escritor de JSON.</param>
        /// <param name="value">El objeto de tipo Indumentaria a escribir.</param>
        /// <param name="options">Opciones de serialización JSON.</param>
        public override void Write(Utf8JsonWriter writer, Indumentaria value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case Campera campera:
                    writer.WriteStartObject();
                    writer.WriteString("Tipo", "Campera");
                    writer.WritePropertyName("Campera");
                    JsonSerializer.Serialize(writer, campera, options);
                    writer.WriteEndObject();
                    break;
                case Remera remera:
                    writer.WriteStartObject();
                    writer.WriteString("Tipo", "Remera");
                    writer.WritePropertyName("Remera");
                    JsonSerializer.Serialize(writer, remera, options);
                    writer.WriteEndObject();
                    break;
                case Pantalon pantalon:
                    writer.WriteStartObject();
                    writer.WriteString("Tipo", "Pantalon");
                    writer.WritePropertyName("Pantalon");
                    JsonSerializer.Serialize(writer, pantalon, options);
                    writer.WriteEndObject();
                    break;
                default:
                    throw new NotSupportedException($"Tipo {value.GetType()} no soportado");
            }
        }
    }
}
