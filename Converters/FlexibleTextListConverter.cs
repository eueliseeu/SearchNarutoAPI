using System.Text.Json;
using System.Text.Json.Serialization;

namespace SearchNarutoAPI.Converters;

public sealed class FlexibleTextListConverter : JsonConverter<List<string>>
{
    public override bool HandleNull => true;

    public override List<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var values = new List<string>();

        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                values.Add(reader.GetString()!);
                break;
            case JsonTokenType.StartArray:
                ReadArray(ref reader, values);
                break;
            case JsonTokenType.StartObject:
                ReadObject(ref reader, values);
                break;
            default:
                reader.Skip();
                break;
        }

        return values;
    }

    public override void Write(Utf8JsonWriter writer, List<string> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var item in value)
        {
            writer.WriteStringValue(item);
        }

        writer.WriteEndArray();
    }

    private static void ReadArray(ref Utf8JsonReader reader, List<string> values)
    {
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                values.Add(reader.GetString()!);
            }
            else
            {
                reader.Skip();
            }
        }
    }

    private static void ReadObject(ref Utf8JsonReader reader, List<string> values)
    {
        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            var key = reader.GetString();

            reader.Read();

            if (reader.TokenType == JsonTokenType.String)
            {
                values.Add($"{reader.GetString()} ({key})");
            }
            else
            {
                reader.Skip();
            }
        }
    }
}
