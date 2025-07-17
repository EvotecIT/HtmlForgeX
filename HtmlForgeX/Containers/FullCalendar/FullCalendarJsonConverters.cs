using System.ComponentModel;
using System.Reflection;

namespace HtmlForgeX;

/// <summary>
/// Converts <see cref="DateTime"/> values to ISO-8601 date strings.
/// </summary>
public class Iso8601DateConverter : JsonConverter<DateTime> {
    /// <inheritdoc />
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        return DateTime.Parse(reader.GetString());
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd")); // "yyyy-MM-dd" format string represents an ISO 8601 date string
    }
}

/// <summary>
/// Converts enum values using their <see cref="DescriptionAttribute"/> when serializing.
/// </summary>
public class DescriptionEnumConverter<T> : JsonConverter<T> where T : Enum {
    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var enumString = reader.GetString();
        return ((T[])Enum.GetValues(typeof(T)))
            .First(enumValue => GetEnumDescription(enumValue) == enumString);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
        writer.WriteStringValue(GetEnumDescription(value));
    }

    private string GetEnumDescription(T value) {
        return value.GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>()
            .Description;
    }
}

/// <summary>
/// Handles serialization of <see cref="Dictionary{FullCalendarViewOption, FullCalendarView}"/> using description names.
/// </summary>
public class ViewOptionDictionaryConverter : JsonConverter<Dictionary<FullCalendarViewOption, FullCalendarView>> {
    /// <inheritdoc />
    public override Dictionary<FullCalendarViewOption, FullCalendarView> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = JsonSerializer.Deserialize<Dictionary<string, FullCalendarView>>(ref reader, options);
        var result = new Dictionary<FullCalendarViewOption, FullCalendarView>();

        foreach (var kvp in value) {
            var enumValue = ((FullCalendarViewOption[])Enum.GetValues(typeof(FullCalendarViewOption)))
                .First(e => GetEnumDescription(e) == kvp.Key);
            result[enumValue] = kvp.Value;
        }

        return result;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Dictionary<FullCalendarViewOption, FullCalendarView> value, JsonSerializerOptions options) {
        var newDict = value.ToDictionary(
            kvp => GetEnumDescription(kvp.Key),
            kvp => kvp.Value
        );

        JsonSerializer.Serialize(writer, newDict, options);
    }

    private string GetEnumDescription(FullCalendarViewOption value) {
        return value.GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>()
            .Description;
    }
}

/// <summary>
/// Serializes <see cref="FullCalendarToolbar"/> instances to JSON.
/// </summary>
public class FullCalendarToolbarConverter : JsonConverter<FullCalendarToolbar> {
    /// <inheritdoc />
    public override FullCalendarToolbar Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType != JsonTokenType.StartObject) {
            throw new JsonException();
        }

        var toolbar = new FullCalendarToolbar();

        while (reader.Read()) {
            if (reader.TokenType == JsonTokenType.EndObject) {
                return toolbar;
            }

            if (reader.TokenType != JsonTokenType.PropertyName) {
                throw new JsonException();
            }

            var propertyName = reader.GetString();
            reader.Read();

            var raw = reader.GetString() ?? string.Empty;
            var parts = raw.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var values = new List<FullCalendarToolbarOption>();

            foreach (var part in parts) {
                var option = ((FullCalendarToolbarOption[])Enum.GetValues(typeof(FullCalendarToolbarOption)))
                    .First(e => GetEnumDescription(e) == part);
                values.Add(option);
            }

            switch (propertyName) {
                case "left":
                    toolbar.LeftOptions = values;
                    break;
                case "center":
                    toolbar.CenterOptions = values;
                    break;
                case "right":
                    toolbar.RightOptions = values;
                    break;
                default:
                    // Skip unknown properties
                    break;
            }
        }

        throw new JsonException();
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, FullCalendarToolbar value, JsonSerializerOptions options) {
        writer.WriteStartObject();
        writer.WriteString("left", string.Join(",", value.LeftOptions.Select(o => GetEnumDescription(o))));
        writer.WriteString("center", string.Join(",", value.CenterOptions.Select(o => GetEnumDescription(o))));
        writer.WriteString("right", string.Join(",", value.RightOptions.Select(o => GetEnumDescription(o))));
        writer.WriteEndObject();
    }

    private string GetEnumDescription(FullCalendarToolbarOption value) {
        return value.GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>()
            .Description;
    }
}

/// <summary>
/// Writes <see cref="RGBColor"/> values as hexadecimal strings.
/// </summary>
public class RGBColorConverter : JsonConverter<RGBColor> {
    /// <inheritdoc />
    public override RGBColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, RGBColor value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToHex());
    }
}

/// <summary>
/// Allows embedding of raw JavaScript functions within JSON options.
/// </summary>
public class JavaScriptFunctionConverter : JsonConverter<string> {
    /// <inheritdoc />
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        return reader.GetString() ?? string.Empty;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) {
        writer.WriteRawValue(value, skipInputValidation: true);
    }
}
