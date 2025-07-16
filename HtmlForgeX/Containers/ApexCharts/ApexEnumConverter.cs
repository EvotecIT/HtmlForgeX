using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Custom JSON converter that serializes enum values as lowercase strings.
/// </summary>
public class ApexEnumConverter<T> : JsonConverter<T> where T : struct, Enum {
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType != JsonTokenType.String) {
            throw new JsonException($"Expected string for enum {typeof(T).Name}");
        }

        var value = reader.GetString();
        if (Enum.TryParse<T>(value, true, out var result)) {
            return result;
        }

        throw new JsonException($"Unable to parse '{value}' as {typeof(T).Name}");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
        // Convert enum value to ApexCharts format
        var enumString = value.ToString();
        
        // For most enums, use lowercase
        var result = enumString.ToLowerInvariant();
        
        // Special cases for ApexCharts conventions
        if (typeof(T) == typeof(ApexCurve) && enumString == "Monotone") {
            result = "monotoneCubic";
        } else if (typeof(T) == typeof(ApexAxisType) && enumString == "Datetime") {
            result = "datetime";
        } else if (typeof(T) == typeof(ApexGradientType)) {
            if (enumString == "Diagonal1") result = "diagonal1";
            else if (enumString == "Diagonal2") result = "diagonal2";
        } else if (typeof(T) == typeof(ApexPatternStyle)) {
            if (enumString == "VerticalLines") result = "verticalLines";
            else if (enumString == "HorizontalLines") result = "horizontalLines";
            else if (enumString == "SlantedLines") result = "slantedLines";
        }
        
        writer.WriteStringValue(result);
    }
}