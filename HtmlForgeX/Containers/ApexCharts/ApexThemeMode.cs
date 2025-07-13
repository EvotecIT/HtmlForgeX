using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

[JsonConverter(typeof(ApexThemeModeConverter))]
public enum ApexThemeMode {
    Light,
    Dark
}

public class ApexThemeModeConverter : JsonConverter<ApexThemeMode> {
    public override ApexThemeMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value switch {
            "light" => ApexThemeMode.Light,
            "dark" => ApexThemeMode.Dark,
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, ApexThemeMode value, JsonSerializerOptions options) {
        var stringValue = value switch {
            ApexThemeMode.Light => "light",
            ApexThemeMode.Dark => "dark",
            _ => throw new JsonException()
        };
        writer.WriteStringValue(stringValue);
    }
}
