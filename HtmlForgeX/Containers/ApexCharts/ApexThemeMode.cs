using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Theme modes supported by ApexCharts.
/// </summary>
[JsonConverter(typeof(ApexThemeModeConverter))]
public enum ApexThemeMode {
    /// <summary>Light theme mode.</summary>
    Light,
    /// <summary>Dark theme mode.</summary>
    Dark
}

/// <summary>
/// JSON converter used to serialize <see cref="ApexThemeMode"/> values.
/// </summary>
public class ApexThemeModeConverter : JsonConverter<ApexThemeMode> {
    /// <inheritdoc />
    public override ApexThemeMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value switch {
            "light" => ApexThemeMode.Light,
            "dark" => ApexThemeMode.Dark,
            _ => throw new JsonException()
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, ApexThemeMode value, JsonSerializerOptions options) {
        var stringValue = value switch {
            ApexThemeMode.Light => "light",
            ApexThemeMode.Dark => "dark",
            _ => throw new JsonException()
        };
        writer.WriteStringValue(stringValue);
    }
}