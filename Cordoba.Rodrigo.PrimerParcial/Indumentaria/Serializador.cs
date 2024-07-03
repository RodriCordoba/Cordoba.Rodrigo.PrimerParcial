using System;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        /// <summary>
        /// Escribe un objeto de tipo Indumentaria en su representación JSON.
        /// </summary>
        /// <param name="writer">El escritor de JSON.</param>
        /// <param name="value">El objeto de tipo Indumentaria a escribir.</param>
        /// <param name="options">Opciones de serialización JSON.</param>
        public override void Write(Utf8JsonWriter writer, Indumentaria value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("Tipo", value.GetType().Name);
            writer.WriteString("Código", value.Codigo);
            writer.WriteNumber("Cantidad", value.Cantidad);

            switch (value)
            {
                case Campera campera:
                    writer.WriteBoolean("TieneCapucha", campera.TieneCapucha);
                    writer.WritePropertyName("Campera");
                    JsonSerializer.Serialize(writer, campera, options);
                    break;
                case Remera remera:
                    writer.WriteBoolean("TieneEstampado", remera.TieneEstampado);
                    writer.WritePropertyName("Remera");
                    JsonSerializer.Serialize(writer, remera, options);
                    break;
                case Pantalon pantalon:
                    writer.WriteBoolean("EsBermuda", pantalon.EsBermuda);
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
