using System.ComponentModel;
using System.Reflection;

namespace HtmlForgeX;

public class Iso8601DateConverter : JsonConverter<DateTime> {
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        return DateTime.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd")); // "yyyy-MM-dd" format string represents an ISO 8601 date string
    }
}

public class DescriptionEnumConverter<T> : JsonConverter<T> where T : Enum {
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var enumString = reader.GetString();
        return ((T[])Enum.GetValues(typeof(T)))
            .First(enumValue => GetEnumDescription(enumValue) == enumString);
    }

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

public class ViewOptionDictionaryConverter : JsonConverter<Dictionary<FullCalendarViewOption, FullCalendarView>> {
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

public class FullCalendarToolbarConverter : JsonConverter<FullCalendarToolbar> {
    public override FullCalendarToolbar Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        throw new NotImplementedException();
    }

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

public class RGBColorConverter : JsonConverter<RGBColor> {
    public override RGBColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, RGBColor value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToHex());
    }
}

public class JavaScriptFunctionConverter : JsonConverter<string> {
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        return reader.GetString() ?? string.Empty;
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) {
        writer.WriteRawValue(value, skipInputValidation: true);
    }
}
