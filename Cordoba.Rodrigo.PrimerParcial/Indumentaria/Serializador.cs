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
        public override Indumentaria Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;
                string tipo = root.GetProperty("Tipo").GetString();
                string codigo = root.GetProperty("Código").GetString();
                int cantidad = root.GetProperty("Cantidad").GetInt32();

                Indumentaria indumentaria = tipo switch
                {
                    "Campera" => JsonSerializer.Deserialize<Campera>(root.GetRawText(), options),
                    "Remera" => JsonSerializer.Deserialize<Remera>(root.GetRawText(), options),
                    "Pantalon" => JsonSerializer.Deserialize<Pantalon>(root.GetRawText(), options),
                    _ => throw new NotSupportedException($"Tipo {tipo} no soportado")
                };

                indumentaria.Codigo = codigo;
                indumentaria.Cantidad = cantidad;

                return indumentaria;
            }
        }

        public override void Write(Utf8JsonWriter writer, Indumentaria value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("Tipo", value.GetType().Name);
            writer.WriteString("Código", value.Codigo);
            writer.WriteNumber("Cantidad", value.Cantidad);

            switch (value)
            {
                case Campera campera:
                    writer.WritePropertyName("Campera");
                    JsonSerializer.Serialize(writer, campera, options);
                    break;
                case Remera remera:
                    writer.WritePropertyName("Remera");
                    JsonSerializer.Serialize(writer, remera, options);
                    break;
                case Pantalon pantalon:
                    writer.WritePropertyName("Pantalon");
                    JsonSerializer.Serialize(writer, pantalon, options);
                    break;
                default:
                    throw new NotSupportedException($"Tipo {value.GetType()} no soportado");
            }

            writer.WriteEndObject();
        }
    }
}
